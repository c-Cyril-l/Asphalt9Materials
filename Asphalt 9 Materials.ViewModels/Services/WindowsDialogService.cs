using Asphalt_9_Materials.ViewModel.Services.Interfaces;
using Microsoft.Win32;
using System;
using System.Windows;

namespace Asphalt_9_Materials.ViewModel.Services
{
    public class WindowsDialogService : IDialogService

    {
        /// <summary>
        /// OpenFileDialog implementation.
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="multiSelect">Multiselect</param>
        /// <param name="title">Dialog title</param>
        /// <returns>The File path that has been chosen by the user.</returns>
        public string OpenFileDialog(string filter, bool multiSelect, string title)
        {

            var ofd = new OpenFileDialog()
            {
                Filter = filter,
                Multiselect = multiSelect,
                Title = title
            };

            if (ofd.ShowDialog() != true)
                return null;

            return ofd.FileName;
        }

        /// <summary>
        /// SaveFileDialog implementation.
        /// </summary>
        /// <param name="filter">filter</param>
        /// <param name="dialogTitle">Dialog title</param>
        /// <param name="overWritePrompt">Overwrite prompt</param>
        /// <param name="fileName">Filename</param>
        /// <param name="initialDirectory">Initial Directory of the dialog</param>
        /// <returns>Whether the dialog result is successful.</returns>
        public Tuple<bool, string, string> SaveFileDialog(string filter, string title, string fileName,
            bool overWritePrompt = true, string initialDirectory = null)
        {
            var sfd = new SaveFileDialog()
            {
                Filter = filter,
                Title = title,
                InitialDirectory = initialDirectory,
                OverwritePrompt = overWritePrompt,
                FileName = fileName
            };

            if (sfd.ShowDialog() == true)
                return new Tuple<bool, string, string>(true, sfd.FileName, sfd.FileName);

            return new Tuple<bool, string, string>(false, null, null);

        }

        /// <summary>
        /// MessageBox showing implementation.
        /// </summary>
        /// <param name="message">Message to show.</param>
        /// <param name="caption">MessageBox title.</param>
        /// <param name="messageBoxButton">MessageBox Buttons.</param>
        /// <param name="messageBoxIcon">MessageBox Icon.</param>
        public void ShowMessageBox(string message, string caption, MessageBoxButton messageBoxButton = MessageBoxButton.OK, MessageBoxImage messageBoxIcon = MessageBoxImage.Information)
        {
            MessageBox.Show(message, caption, messageBoxButton, messageBoxIcon);
        }
    }
}
