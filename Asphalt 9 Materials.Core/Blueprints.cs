using Helpers.Utilities;

namespace Asphalt_9_Materials.Core
{
    public class Blueprint : ObservableObject
    {

        #region Declarations

        private int? _fifthStar;

        private int? _firstStar;

        private int? _fourthStar;

        private int? _secondStar;

        private int? _sixthStar;

        private int? _thirdStar;

        #endregion

        #region Properties

        /// <summary>
        /// Blueprints required for 5th star.
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
        /// Blueprints required for 1st star.
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
        /// Blueprints required for 4th star.
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
        /// Blueprints required for 2nd star.
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
        /// Blueprints required for 6th star.
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
        /// Blueprints required for 3rd star.
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

        /// <summary>
        /// Blueprints required at total.
        /// </summary>
        public int? Total => (FirstStar ?? 0) +
            (SecondStar ?? 0) +
            (ThirdStar ?? 0) +
            (FourthStar ?? 0) +
            (FifthStar ?? 0) +
            (SixthStar ?? 0);

        #endregion

    }
}
