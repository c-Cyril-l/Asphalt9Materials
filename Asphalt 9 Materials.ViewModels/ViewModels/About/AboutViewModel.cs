using Asphalt_9_Materials.ViewModel.Services.Interfaces;
using Helpers.Utilities;
using System.Diagnostics;

namespace Asphalt_9_Materials.ViewModel.ViewModels.About
{
    public class AboutViewModel : IPageService
    {
        #region Constructor

        public AboutViewModel()
        {
            // Initializing commands.
            InitializeCommands();
        }

        #endregion

        #region IPage Implementation

        public string Name => string.Empty;

        #endregion

        #region Commands

        #region Declarations
        public RelayCommand SendingMailCommand { get; private set; }

        public RelayCommand FacebookContactCommand { get; private set; }

        public RelayCommand GithubLinkCommand { get; private set; }

        #endregion

        #region Initialize Commands

        private void InitializeCommands()
        {
            SendingMailCommand = new RelayCommand(SendingMail);
            FacebookContactCommand = new RelayCommand(FacebookContact);
            GithubLinkCommand = new RelayCommand(GithubProjectPage);
        }

        #endregion

        #endregion

        #region Methods


        private static void FacebookContact(object obj)
        {
            Process.Start("https://www.facebook.com/CryilDouglas");
        }

        private static void SendingMail(object obj)
        {
            Process.Start("mailto:cyrildouglas07@gmail.com");
        }

        private static void GithubProjectPage(object obj)
        {
            Process.Start("https://github.com/c-Cyril-l/Asphalt9Materials");
        }

        #endregion

    }
}
