/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:BootstrapWPFApplication.UI"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using BootstrapWPFApplication.Core.UnitOfWork;
using BootstrapWPFApplication.Core.Utility;
using BootstrapWPFApplication.Infrastructure;
using BootstrapWPFApplication.Infrastructure.UnitOfWork;
using BootstrapWPFApplication.Infrastructure.Utility.NLogger;
using BootstrapWPFApplication.UI.Services;
using CommonServiceLocator;
using Unity;
using Unity.Lifetime;
using Unity.ServiceLocation;

namespace BootstrapWPFApplication.UI.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            IUnityContainer container = new UnityContainer();


            #region UniofWork and Db context
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            //container.RegisterType<ApplicationDbContext, >();
            #endregion

            #region Repositories
            // register repositories
            #endregion

            #region DB Services

            #endregion

            #region ApplicationServices
            container.RegisterType<IDialogService, DialogService>();
            container.RegisterType<ILogger, AppLogger>(new ExternallyControlledLifetimeManager());
            #endregion

            #region ViewModel
            // register your viewModels
            container.RegisterType<MainViewModel>();
            #endregion

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}