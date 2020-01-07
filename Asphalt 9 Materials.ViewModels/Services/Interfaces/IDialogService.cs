using System;
using System.Windows;

namespace Asphalt_9_Materials.ViewModel.Services.Interfaces
{
    public interface IDialogService
    {

        /// <summary>
        /// OpenFileDialog.
        /// </summary> 
        /// <param name="filePath">The File path that comes from user selection.</param>
        /// <returns>file path</returns>
        string OpenFileDialog(string filePath, bool multiSelect, string dialogTitle);

        /// <summary>
        /// SaveFileDialog.
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="dialogTitle">Dialog title</param>
        /// <param name="overWritePrompt">Overwrite prompt</param>
        /// <param name="initialDirectory">Initial Directory of the dialog</param>
        /// <returns>Whether the dialog result is successful as well as file path and filename.</returns>
        Tuple<bool, string, string> SaveFileDialog(string filter, string dialogTitle, string fileName, bool overWritePrompt, string initialDirectory);

        /// <summary>
        /// MessageBox Text.
        /// </summary>
        /// <param name="message">Message to show.</param>
        /// <param name="caption">Title of the message box.</param>
        /// <param name="messageBoxButton">MessageBox button.</param>
        /// <param name="messageBoxIcon">MessageBox icon.</param>
        void ShowMessageBox(string message, string caption, MessageBoxButton messageBoxButton, MessageBoxImage messageBoxIcon);

    }
}
