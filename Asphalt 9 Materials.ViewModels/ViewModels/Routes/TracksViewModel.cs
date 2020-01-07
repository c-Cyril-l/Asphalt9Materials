using Asphalt_9_Materials.ViewModel.Services.Interfaces;
using Helpers.Utilities;
using System;
using System.Collections.ObjectModel;

namespace Asphalt_9_Materials.ViewModel.ViewModels.Routes
{
    public class TracksViewModel : ObservableObject, IPageService
    {

        #region Declarations

        private string _routeName;

        #endregion

        #region Constructor

        public TracksViewModel()
        {
            // Initializing route list.
            RouteCollection = new ObservableCollection<Tuple<string, string, int, string>>();

            // Initializing route name.
            _routeName = string.Empty;
        }

        #endregion

        #region IPage Implementation

        public string Name => string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// City Name.
        /// </summary>
        public string RouteName
        {
            get => _routeName;
            set
            {
                _routeName = value;
                RaisePropertyChanged(nameof(RouteName));
            }
        }

        /// <summary>
        /// Collection of the routes.
        /// </summary>
        public ObservableCollection<Tuple<string, string, int, string>> RouteCollection { get; set; }

        #endregion

    }
}
