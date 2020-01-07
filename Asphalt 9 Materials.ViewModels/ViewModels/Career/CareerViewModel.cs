using Asphalt_9_Materials.ViewModel.Services.Interfaces;
using Helpers.Utilities;
using System.Collections.ObjectModel;

namespace Asphalt_9_Materials.ViewModel.ViewModels.Career
{
    public class CareerViewModel : ObservableObject, IPageService
    {

        #region Constructor

        public CareerViewModel()
        {
            // Initializing career collection.
            CareerCollection = new ObservableCollection<Core.Career>();
        }

        #endregion

        #region Properties

        public ObservableCollection<Core.Career> CareerCollection { get; set; }

        #endregion

        #region IPage Implementation

        public string Name => string.Empty;

        #endregion
    }
}
