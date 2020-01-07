using Helpers.Utilities;

namespace Asphalt_9_Materials.Core
{
    public class Career : ObservableObject
    {

        private int _chapter;

        private int? _credits;

        private string _mode;

        private int? _race;

        private int? _rank;

        private int? _reputation;

        private string _season;

        private string _time;

        private string _track;

        /// <summary>
        /// The Race chapter.
        /// </summary>
        public int Chapter
        {
            get => _chapter;
            set
            {
                _chapter = value;
                RaisePropertyChanged(nameof(Chapter));
            }
        }

        /// <summary>
        /// Credits given by completing the race.
        /// </summary>
        public int? Credits
        {
            get => _credits;
            set
            {
                _credits = value;
                RaisePropertyChanged(nameof(Credits));
            }
        }

        /// <summary>
        /// Race mode.
        /// </summary>
        public string Mode
        {
            get => _mode;
            set
            {
                _mode = value;
                RaisePropertyChanged(nameof(Mode));
            }
        }

        /// <summary>
        /// The Race.
        /// </summary>
        public int? Race
        {
            get => _race;
            set
            {
                _race = value;
                RaisePropertyChanged(nameof(Race));
            }
        }

        /// <summary>
        /// Required rank for the race.
        /// </summary>
        public int? Rank
        {
            get => _rank;
            set
            {
                _rank = value;
                RaisePropertyChanged(nameof(Chapter));
            }
        }

        /// <summary>
        /// Reputation given by completing the race.
        /// </summary>
        public int? Reputation
        {
            get => _reputation;
            set
            {
                _reputation = value;
                RaisePropertyChanged(nameof(Reputation));
            }
        }

        /// <summary>
        /// Season where the race located.
        /// </summary>
        public string Season
        {
            get => _season;
            set
            {
                _season = value;
                RaisePropertyChanged(nameof(Season));
            }
        }

        /// <summary>
        /// Race time.
        /// </summary>
        public string Time
        {
            get => _time;
            set
            {
                _time = value;
                RaisePropertyChanged(nameof(Time));
            }
        }

        /// <summary>
        /// Race Track
        /// </summary>
        public string Track
        {
            get => _track;
            set
            {
                _track = value;
                RaisePropertyChanged(nameof(Track));
            }
        }


    }
}
