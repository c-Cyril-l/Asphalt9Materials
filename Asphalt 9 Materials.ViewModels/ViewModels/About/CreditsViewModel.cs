using Asphalt_9_Materials.ViewModel.Services.Interfaces;
using Helpers.Utilities;
using System.Diagnostics;

namespace Asphalt_9_Materials.ViewModel.ViewModels.About
{
    public class CreditsViewModel : IPageService
    {

        #region Constructor
        public CreditsViewModel()
        {
            // Initializing commands.
            InitializeCommands();
        }
        #endregion

        #region IPage Implementation

        public string Name => string.Empty;

        #endregion

        #region Methods

        private bool CanOpenLink(object sender)
        {
            return (sender != null) && sender.ToString().ToLower().StartsWith(@"https://");
        }

        private void OpenLink(object sender)
        {
            Process.Start(sender.ToString());
        }

        #endregion

        #region Commands

        #region Declarations

        public RelayCommand OpenLinkCommand { get; private set; }

        #endregion


        #region Initialize Commands

        private void InitializeCommands()
        {
            OpenLinkCommand = new RelayCommand(OpenLink, CanOpenLink);
        }

        #endregion


        #endregion

    }
}
