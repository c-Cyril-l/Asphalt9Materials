using Asphalt_9_Materials.ViewModel.Services.Interfaces;
using Helpers.Utilities;
using System.Collections.ObjectModel;

namespace Asphalt_9_Materials.ViewModel.ViewModels.AvailableCars
{
    public class CarsPageViewModel : ObservableObject, IPageService
    {

        #region Constructor

        public CarsPageViewModel()
        {
            // Initializing card list.
            CardCollection = new ObservableCollection<CarCardViewModel>();
        }

        #endregion

        #region Properties

        public ObservableCollection<CarCardViewModel> CardCollection { get; private set; }

        #endregion

        #region IPage Implementation

        public string Name => string.Empty;

        #endregion

    }
}
