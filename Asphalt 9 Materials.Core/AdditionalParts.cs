using Helpers.Utilities;

namespace Asphalt_9_Materials.Core
{
    public class AdditionalParts : ObservableObject
    {
        #region Declarations

        private int? _epicCost;

        private int? _epicQuantity;

        private int? _rareCost;

        private int? _rareQuantity;

        private int? _uncommonCost;

        private int? _uncommonQuantity;

        #endregion

        #region Properties

        /// <summary>
        /// Car Epic Cost (Single 1/4)
        /// </summary>
        public int? EpicCost
        {
            get => _epicCost;
            set
            {
                _epicCost = value;
                RaisePropertyChanged(nameof(EpicCost));
            }
        }

        /// <summary>
        /// Car Epic Part (Single /1/4)
        /// </summary>
        public int? EpicQuantity
        {
            get => _epicQuantity;
            set
            {
                _epicQuantity = value;
                RaisePropertyChanged(nameof(EpicQuantity));
            }
        }

        /// <summary>
        /// Car Total Epic Cost
        /// </summary>
        public int? EpicTotalCost => (EpicCost ?? 0) * (EpicQuantity ?? 0);


        /// <summary>
        /// Car Rare Cost (Single 1/4)
        /// </summary>
        public int? RareCost
        {
            get => _rareCost;
            set
            {
                _rareCost = value;
                RaisePropertyChanged(nameof(RareCost));
            }
        }

        /// <summary>
        /// Car Rare Part (Single 1/4)
        /// </summary>
        public int? RareQuantity
        {
            get => _rareQuantity;
            set
            {
                _rareQuantity = value;
                RaisePropertyChanged(nameof(RareQuantity));
            }
        }

        /// <summary>
        /// Car Total Rare Cost
        /// </summary>
        public int? RareTotalCost => (RareCost ?? 0) * (RareQuantity ?? 0);

        /// <summary>
        /// Car Uncommon Cost (Single 1/4)
        /// </summary>

        public int? UncommonCost
        {
            get => _uncommonCost;
            set
            {
                _uncommonCost = value;
                RaisePropertyChanged(nameof(UncommonCost));
            }
        }

        /// <summary>
        /// Car Uncommon Part (Single 1/4)
        /// </summary>
        public int? UncommonQuantity
        {
            get => _uncommonQuantity;
            set
            {
                _uncommonQuantity = value;
                RaisePropertyChanged(nameof(UncommonQuantity));
            }
        }

        /// <summary>
        /// Car Total Uncommon Cost
        /// </summary>
        public int? UncommonTotalCost => (UncommonCost ?? 0) * (UncommonQuantity ?? 0);

        #endregion

    }
}
