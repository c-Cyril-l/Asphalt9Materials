using Helpers.Utilities;

namespace Asphalt_9_Materials.Core
{
    public class Upgrades : ObservableObject
    {

        #region Declarations

        private int? _stage0;

        private int? _stage1;

        private int? _stage10;

        private int? _stage11;

        private int? _stage12;

        private int? _stage2;

        private int? _stage3;

        private int? _stage4;

        private int? _stage5;

        private int? _stage6;

        private int? _stage7;

        private int? _stage8;

        private int? _stage9;

        #endregion

        #region Properties

        /// <summary>
        /// 1st Stage Upgrade Cost Single
        /// </summary>
        public int? Stage0
        {
            get => _stage0;
            set
            {
                _stage0 = value;
                RaisePropertyChanged(nameof(Stage0));
            }
        }

        /// <summary>
        /// 2nd Stage Upgrade Cost Single
        /// </summary>
        public int? Stage1
        {
            get => _stage1;
            set
            {
                _stage1 = value;
                RaisePropertyChanged(nameof(Stage1));
            }
        }

        /// <summary>
        /// 11th Stage Upgrade Cost Single
        /// </summary>
        public int? Stage10
        {
            get => _stage10;
            set
            {
                _stage10 = value;
                RaisePropertyChanged(nameof(Stage10));
            }
        }

        /// <summary>
        /// 12th Stage Upgrade Cost Single
        /// </summary>
        public int? Stage11
        {
            get => _stage11;
            set
            {
                _stage11 = value;
                RaisePropertyChanged(nameof(Stage11));
            }
        }

        /// <summary>
        /// 13th Stage Upgrade Cost Single
        /// </summary>
        public int? Stage12
        {
            get => _stage12;
            set
            {
                _stage12 = value;
                RaisePropertyChanged(nameof(Stage12));
            }
        }

        /// <summary>
        /// 3rd Stage Upgrade Cost Single
        /// </summary>
        public int? Stage2
        {
            get => _stage2;
            set
            {
                _stage2 = value;
                RaisePropertyChanged(nameof(Stage2));
            }
        }

        /// <summary>
        /// 4th Stage Upgrade Cost Single
        /// </summary>
        public int? Stage3
        {
            get => _stage3;
            set
            {
                _stage3 = value;
                RaisePropertyChanged(nameof(Stage3));
            }
        }

        /// <summary>
        /// 5th Stage Upgrade Cost Single
        /// </summary>
        public int? Stage4
        {
            get => _stage4;
            set
            {
                _stage4 = value;
                RaisePropertyChanged(nameof(Stage4));
            }
        }

        /// <summary>
        /// 6th Stage Upgrade Cost Single
        /// </summary>
        public int? Stage5
        {
            get => _stage5;
            set
            {
                _stage5 = value;
                RaisePropertyChanged(nameof(Stage5));
            }
        }

        /// <summary>
        /// 7th Stage Upgrade Cost Single
        /// </summary>
        public int? Stage6
        {
            get => _stage6;
            set
            {
                _stage6 = value;
                RaisePropertyChanged(nameof(Stage6));
            }
        }

        /// <summary>
        /// 8th Stage Upgrade Cost Single
        /// </summary>
        public int? Stage7
        {
            get => _stage7;
            set
            {
                _stage7 = value;
                RaisePropertyChanged(nameof(Stage7));
            }
        }

        /// <summary>
        /// 9th Stage Upgrade Cost Single
        /// </summary>
        public int? Stage8
        {
            get => _stage8;
            set
            {
                _stage8 = value;
                RaisePropertyChanged(nameof(Stage8));
            }
        }

        /// <summary>
        /// 10th Stage Upgrade Cost Single
        /// </summary>
        public int? Stage9
        {
            get => _stage9;
            set
            {
                _stage9 = value;
                RaisePropertyChanged(nameof(Stage9));
            }
        }

        /// <summary>
        /// Total Upgrade Cost Of The Car
        /// </summary>
        public int? TotalStagesCost =>
            ((Stage0 ?? 0) * 4) + ((Stage1 ?? 0) * 4) +
            ((Stage2 ?? 0) * 4) + ((Stage3 ?? 0) * 4) +
            ((Stage4 ?? 0) * 4) + ((Stage5 ?? 0) * 4) +
            ((Stage6 ?? 0) * 4) + ((Stage7 ?? 0) * 4) +
            ((Stage8 ?? 0) * 4) + ((Stage9 ?? 0) * 4) +
            ((Stage10 ?? 0) * 4) + ((Stage11 ?? 0) * 4) +
            ((Stage12 ?? 0) * 4);

        #endregion

    }
}
