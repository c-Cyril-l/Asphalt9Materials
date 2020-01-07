using Helpers.Utilities;
using System.Linq;

namespace Asphalt_9_Materials.Core
{
    public class Ranks : ObservableObject
    {
        #region Declarations

        private int? _fifthStar;

        private int? _firstStar;

        private int? _fourthStar;

        private int? _secondStar;

        private int? _sixthStar;

        private int? _stock;

        private int? _thirdStar;

        #endregion

        #region Properties
        
        /// <summary>
        /// 5th Star Rank
        /// </summary>
        public int? FifthStar
        {
            get => _fifthStar;
            set
            {
                _fifthStar = value;
                RaisePropertyChanged(nameof(FifthStar));
            }
        }

        /// <summary>
        /// 1st Star Rank
        /// </summary>
        public int? FirstStar
        {
            get => _firstStar;
            set
            {
                _firstStar = value;
                RaisePropertyChanged(nameof(FirstStar));
            }
        }

        /// <summary>
        /// 4th Star Rank
        /// </summary>
        public int? FourthStar
        {
            get => _fourthStar;
            set
            {
                _fourthStar = value;
                RaisePropertyChanged(nameof(FourthStar));
            }
        }

        /// <summary>
        /// Max Rank
        /// </summary>
        public int? Max =>
           new[] { (Stock ?? 0), (FirstStar ?? 0), (SecondStar ?? 0),
               (ThirdStar ?? 0), (FourthStar ?? 0), (FifthStar ?? 0),
               (SixthStar ?? 0) }.Max();

        /// <summary>
        /// 2nd Star Rank
        /// </summary>
        public int? SecondStar
        {
            get => _secondStar;
            set
            {
                _secondStar = value;
                RaisePropertyChanged(nameof(SecondStar));
            }
        }

        /// <summary>
        /// 6th Star Rank
        /// </summary>
        public int? SixthStar
        {
            get => _sixthStar;
            set
            {
                _sixthStar = value;
                RaisePropertyChanged(nameof(SixthStar));
            }
        }

        /// <summary>
        /// Stock Rank
        /// </summary>
        public int? Stock
        {
            get => _stock;
            set
            {
                _stock = value;
                RaisePropertyChanged(nameof(Stock));
            }
        }

        /// <summary>
        /// 3rd Star Rank
        /// </summary>
        public int? ThirdStar
        {
            get => _thirdStar;
            set
            {
                _thirdStar = value;
                RaisePropertyChanged(nameof(ThirdStar));
            }
        }


        #endregion
        
    }
}
