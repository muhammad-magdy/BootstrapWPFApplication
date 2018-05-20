using BootstrapWPFApplication.Infrastructure.Utility.NLogger;
using BootstrapWPFApplication.Resources;
using BootstrapWPFApplication.UI.Services;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace BootstrapWPFApplication.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var dialogService = ServiceLocator.Current.GetInstance<IDialogService>();
            AppLogger.Instance.Log(e.Exception);
            dialogService.ShowMessageDialog(Resource.Error, Resource.GeneralExceptionMessage);
            e.Handled = true;
        }
    }
}
