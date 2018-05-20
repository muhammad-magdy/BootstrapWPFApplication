using BootstrapWPFApplication.Core.Utility;
using BootstrapWPFApplication.Infrastructure.Utility.NLogger;
using GalaSoft.MvvmLight;

namespace BootstrapWPFApplication.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ILogger _Applogger;
        public MainViewModel(ILogger appLogger)
        {
            _Applogger = appLogger;
        }
    }
}