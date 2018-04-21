using System;

namespace BootstrapWPFApplication.UI.Services
{
    public interface IDialogService
    {
        void ShowConfirmDialog(string title, string message, Action<bool?> action);

        bool ShowConfirmDialog(string title, string message);

        void ShowMessageDialog(string title, string message);

        string OpenFileDialog(string fileFilters = "", string fileExtension = "", string initialDirectory = "");

        string SaveFileDialog(string fileFilters = "", string fileExtension = "", string initialDirectory = "",
            string fileName = "");
    }
}
