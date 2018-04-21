using System;
using System.Windows;

namespace BootstrapWPFApplication.UI.Services
{
    public class DialogService : IDialogService
    {
        public string OpenFileDialog(string fileFilters = "", string fileExtension = "", string initialDirectory = "")
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            if (!string.IsNullOrEmpty(fileExtension))
                dlg.DefaultExt = fileExtension;

            if (!string.IsNullOrEmpty(fileFilters))
                dlg.Filter = fileFilters;

            if (!string.IsNullOrEmpty(initialDirectory))
                dlg.InitialDirectory = initialDirectory;


            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                return dlg.FileName;
            }
            return string.Empty;
        }
        
        public string SaveFileDialog(string fileFilters = "", string fileExtension = "", string initialDirectory = "", string fileName = "")
        {
            string ouputFileName = string.Empty;


            Application.Current.Dispatcher.Invoke(() =>
            {
                // Create OpenFileDialog
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

                if (!string.IsNullOrEmpty(fileExtension))
                    dlg.DefaultExt = fileExtension;

                if (!string.IsNullOrEmpty(fileFilters))
                    dlg.Filter = fileFilters;

                if (!string.IsNullOrEmpty(initialDirectory))
                    dlg.InitialDirectory = initialDirectory;

                if (!string.IsNullOrEmpty(fileName))
                    dlg.FileName = fileName;

                // Display OpenFileDialog by calling ShowDialog method
                Nullable<bool> result = dlg.ShowDialog(Application.Current.MainWindow);

                // Get the selected file name and display in a TextBox
                if (result == true)
                    ouputFileName = dlg.FileName;

            });

            return ouputFileName;
        }

        public bool ShowConfirmDialog(string title, string message)
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.YesNo);
            return result == MessageBoxResult.Yes;
        }

        public void ShowConfirmDialog(string title, string message, Action<bool?> action)
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.YesNo);
            action(result == MessageBoxResult.Yes);
        }

        public void ShowMessageDialog(string title, string message)
        {
            MessageBox.Show(message, title);
        }
    }
}
