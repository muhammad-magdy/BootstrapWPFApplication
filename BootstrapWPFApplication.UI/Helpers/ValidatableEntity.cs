using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BootstrapWPFApplication.UI.Helpers
{
    public class ValidatableEntity : INotifyDataErrorInfo, INotifyPropertyChanged, IEditableObject
    {
        #region DataErrorInfo
        private ConcurrentDictionary<string, List<string>> _errors = new ConcurrentDictionary<string, List<string>>();

        public ConcurrentDictionary<string, List<string>> Errors
        {
            get { return _errors; }
        }

        public bool CanValidate { get; set; }

        public event System.EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public void OnErrorsChanged(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return;

            var handler = ErrorsChanged;
            if (handler != null)
                handler(this, new DataErrorsChangedEventArgs(propertyName));
        }
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return null;

            List<string> errorsForName;
            _errors.TryGetValue(propertyName, out errorsForName);
            return errorsForName;
        }

        public bool HasErrors
        {
            get { return _errors.Any(kv => kv.Value != null && kv.Value.Count > 0); }
        }
        public Task ValidateAsync()
        {
            return Task.Run(() => Validate());
        }

        private object _lock = new object();
        public void Validate()
        {
            lock (_lock)
            {
                var validationContext = new ValidationContext(this, null, null);
                var validationResults = new List<ValidationResult>();
                Validator.TryValidateObject(this, validationContext, validationResults, true);

                foreach (var kv in _errors.ToList())
                {
                    if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                    {
                        List<string> outLi;
                        _errors.TryRemove(kv.Key, out outLi);
                        OnErrorsChanged(kv.Key);
                    }
                }

                var q = from r in validationResults
                        from m in r.MemberNames
                        group r by m into g
                        select g;

                foreach (var prop in q)
                {
                    var messages = prop.Select(r => r.ErrorMessage).ToList();

                    if (_errors.ContainsKey(prop.Key))
                    {
                        List<string> outLi;
                        _errors.TryRemove(prop.Key, out outLi);
                    }
                    _errors.TryAdd(prop.Key, messages);
                    OnErrorsChanged(prop.Key);
                }
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        #endregion

        #region Editableobject
        private Hashtable props = null;
        /// <summary>
        /// Set object in edit mode and save current values
        /// </summary>
        public void BeginEdit()
        {
            //enumerate properties
            PropertyInfo[] properties = (this.GetType()).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            props = new Hashtable(properties.Length - 1);
            for (int i = 0; i < properties.Length; i++)
            {
                //check if there is set accessors
                if (null != properties[i].GetSetMethod())
                {
                    object value = properties[i].GetValue(this, null);
                    props.Add(properties[i].Name, value);
                }
            }
        }

        /// <summary>
        /// Reject changes made to object since method BeginEdit() was called
        /// </summary>
        public void CancelEdit()
        {
            if (props != null)
            {
                //restore old values
                PropertyInfo[] properties = (this.GetType()).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                for (int i = 0; i < properties.Length; i++)
                {
                    //check if there is set accessors
                    if (null != properties[i].GetSetMethod())
                    {
                        object value = props[properties[i].Name];
                        properties[i].SetValue(this, value, null);
                    }
                }
            }
        }

        /// <summary>
        /// Commit changes in object since method BeginEdit() was called
        /// </summary>
        public void EndEdit()
        {
            //delete current values            
            props = null;
            BeginEdit();
        }
        #endregion
    }
}
