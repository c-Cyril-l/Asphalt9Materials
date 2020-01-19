using Asphalt_9_Materials.Core;
using Helpers.Utilities;
using System.ComponentModel;
using System.Linq;

namespace Asphalt_9_Materials.ViewModel.Validation
{
    public class CarValidation : ObservableObject, IDataErrorInfo
    {
        #region Methods

        /// <summary>
        /// Clearing every single property.
        /// </summary>
        public void ClearProperties()
        {
            Refill = string.Empty;
            RefillDetection = string.Empty;

            EpicCost = string.Empty;
            RareCost = string.Empty;
            UncommonCost = string.Empty;

            FirstStar = string.Empty;
            SecondStar = string.Empty;
            ThirdStar = string.Empty;
            FourthStar = string.Empty;
            FifthStar = string.Empty;
            SixthStar = string.Empty;

            StockRank = string.Empty;
            FirstStarRank = string.Empty;
            SecondStarRank = string.Empty;
            ThirdStarRank = string.Empty;
            FourthStarRank = string.Empty;
            FifthStarRank = string.Empty;
            SixthStarRank = string.Empty;

            Stage0 = string.Empty;
            Stage1 = string.Empty;
            Stage2 = string.Empty;
            Stage3 = string.Empty;
            Stage4 = string.Empty;
            Stage5 = string.Empty;
            Stage6 = string.Empty;
            Stage7 = string.Empty;
            Stage8 = string.Empty;
            Stage9 = string.Empty;
            Stage10 = string.Empty;
            Stage11 = string.Empty;
            Stage12 = string.Empty;

            StockTopSpeed = string.Empty;
            StockAcceleration = string.Empty;
            StockHandling = string.Empty;
            StockNitro = string.Empty;
            MaxTopSpeed = string.Empty;
            MaxAcceleration = string.Empty;
            MaxHandling = string.Empty;
            MaxNitro = string.Empty;



        }

        #endregion

        #region Overridable Properties

        /// <summary>
        /// Car to override.
        /// </summary>
        public virtual Car Car { get; set; }

        #endregion

        #region Declarations

        private string _refill;
        private string _refillDetection;

        private string _epicCost;
        private string _rareCost;
        private string _unCommonCost;

        private string _firstStar;
        private string _secondStar;
        private string _thirdStar;
        private string _fourthStar;
        private string _fifthStar;
        private string _sixthStar;

        private string _stockRank;
        private string _firstStarRank;
        private string _secondStarRank;
        private string _thirdStarRank;
        private string _fourthStarRank;
        private string _fifthStarRank;
        private string _sixthStarRank;

        private string _stage0;
        private string _stage1;
        private string _stage2;
        private string _stage3;
        private string _stage4;
        private string _stage5;
        private string _stage6;
        private string _stage7;
        private string _stage8;
        private string _stage9;
        private string _stage10;
        private string _stage11;
        private string _stage12;

        private string _stockTopSpeed;
        private string _stockAcceleration;
        private string _stockHandling;
        private string _stockNitro;
        private string _maxTopSpeed;
        private string _maxAcceleration;
        private string _maxHandling;
        private string _maxNitro;


        #endregion

        #region Validation Properties

        #region Information


        /// <summary>
        /// Car refill property to validate.
        /// </summary>
        public string Refill
        {
            get => _refill;
            set
            {
                _refill = value;
                RaisePropertyChanged(nameof(Refill));
            }
        }


        /// <summary>
        /// Car refill property to validate (Min(s) or Hr(s)).
        /// </summary>
        public string RefillDetection
        {
            get => _refillDetection;
            set
            {
                _refillDetection = value;
                RaisePropertyChanged(nameof(RefillDetection));
            }
        }


        #endregion

        #region Additional Parts

        /// <summary>
        /// Car epic cost to validate
        /// </summary>
        public string EpicCost
        {
            get => _epicCost;
            set
            {
                _epicCost = value;
                RaisePropertyChanged(nameof(EpicCost));
            }
        }

        /// <summary>
        /// Car rare cost to validate
        /// </summary>
        public string RareCost
        {
            get => _rareCost;
            set
            {
                _rareCost = value;
                RaisePropertyChanged(nameof(RareCost));
            }
        }

        /// <summary>
        /// Car uncommon cost to validate
        /// </summary>
        public string UncommonCost
        {
            get => _unCommonCost;
            set
            {
                _unCommonCost = value;
                RaisePropertyChanged(nameof(UncommonCost));
            }
        }

        #endregion

        #region Blueprints

        /// <summary>
        /// Car 1st star blueprints to validate
        /// </summary>
        public string FirstStar
        {
            get => _firstStar;
            set
            {
                _firstStar = value;
                RaisePropertyChanged(nameof(FirstStar));
            }
        }

        /// <summary>
        /// Car 2nd star blueprints to validate
        /// </summary>
        public string SecondStar
        {
            get => _secondStar;
            set
            {
                _secondStar = value;
                RaisePropertyChanged(nameof(SecondStar));
            }
        }

        /// <summary>
        /// Car 3rd star blueprints to validate
        /// </summary>
        public string ThirdStar
        {
            get => _thirdStar;
            set
            {
                _thirdStar = value;
                RaisePropertyChanged(nameof(ThirdStar));
            }
        }

        /// <summary>
        /// Car 4th star blueprints to validate
        /// </summary>
        public string FourthStar
        {
            get => _fourthStar;
            set
            {
                _fourthStar = value;
                RaisePropertyChanged(nameof(FourthStar));
            }
        }

        /// <summary>
        /// Car 5th star blueprints to validate
        /// </summary>
        public string FifthStar
        {
            get => _fifthStar;
            set
            {
                _fifthStar = value;
                RaisePropertyChanged(nameof(FifthStar));
            }
        }

        /// <summary>
        /// Car 6th star blueprints to validate
        /// </summary>
        public string SixthStar
        {
            get => _sixthStar;
            set
            {
                _sixthStar = value;
                RaisePropertyChanged(nameof(SixthStar));
            }
        }


        #endregion

        #region Ranks

        /// <summary>
        /// Car stock rank to validate
        /// </summary>
        public string StockRank
        {
            get => _stockRank;
            set
            {
                _stockRank = value;
                RaisePropertyChanged(nameof(StockRank));
            }
        }

        /// <summary>
        /// Car 1st star rank to validate
        /// </summary>
        public string FirstStarRank
        {
            get => _firstStarRank;
            set
            {
                _firstStarRank = value;
                RaisePropertyChanged(nameof(FirstStarRank));
            }
        }

        /// <summary>
        /// Car 2nd star rank to validate
        /// </summary>
        public string SecondStarRank
        {
            get => _secondStarRank;
            set
            {
                _secondStarRank = value;
                RaisePropertyChanged(nameof(SecondStarRank));
            }
        }

        /// <summary>
        /// Car 3rd star rank to validate
        /// </summary>
        public string ThirdStarRank
        {
            get => _thirdStarRank;
            set
            {
                _thirdStarRank = value;
                RaisePropertyChanged(nameof(ThirdStarRank));
            }
        }

        /// <summary>
        /// Car 4th star rank to validate
        /// </summary>
        public string FourthStarRank
        {
            get => _fourthStarRank;
            set
            {
                _fourthStarRank = value;
                RaisePropertyChanged(nameof(FourthStarRank));
            }
        }

        /// <summary>
        /// Car 5th star rank to validate
        /// </summary>
        public string FifthStarRank
        {
            get => _fifthStarRank;
            set
            {
                _fifthStarRank = value;
                RaisePropertyChanged(nameof(FifthStarRank));
            }
        }

        /// <summary>
        /// Car 6th star rank to validate
        /// </summary>
        public string SixthStarRank
        {
            get => _sixthStarRank;
            set
            {
                _sixthStarRank = value;
                RaisePropertyChanged(nameof(SixthStarRank));
            }
        }

        #endregion

        #region Upgrades

        /// <summary>
        /// Car stage 0 upgrade to validate
        /// </summary>
        public string Stage0
        {
            get => _stage0;
            set
            {
                _stage0 = value;
                RaisePropertyChanged(nameof(Stage0));
            }
        }

        /// <summary>
        /// Car 1st stage upgrade to validate
        /// </summary>
        public string Stage1
        {
            get => _stage1;
            set
            {
                _stage1 = value;
                RaisePropertyChanged(nameof(Stage1));
            }
        }

        /// <summary>
        /// Car 2nd stage upgrade to validate
        /// </summary>
        public string Stage2
        {
            get => _stage2;
            set
            {
                _stage2 = value;
                RaisePropertyChanged(nameof(Stage2));
            }
        }

        /// <summary>
        /// Car 3rd stage upgrade to validate
        /// </summary>
        public string Stage3
        {
            get => _stage3;
            set
            {
                _stage3 = value;
                RaisePropertyChanged(nameof(Stage3));
            }
        }

        /// <summary>
        /// Car 4th stage upgrade to validate
        /// </summary>
        public string Stage4
        {
            get => _stage4;
            set
            {
                _stage4 = value;
                RaisePropertyChanged(nameof(Stage4));
            }
        }

        /// <summary>
        /// Car 5th stage upgrade to validate
        /// </summary>
        public string Stage5
        {
            get => _stage5;
            set
            {
                _stage5 = value;
                RaisePropertyChanged(nameof(Stage5));
            }
        }

        /// <summary>
        /// Car 6th stage upgrade to validate
        /// </summary>
        public string Stage6
        {
            get => _stage6;
            set
            {
                _stage6 = value;
                RaisePropertyChanged(nameof(Stage6));
            }
        }

        /// <summary>
        /// Car 7th stage upgrade to validate
        /// </summary>
        public string Stage7
        {
            get => _stage7;
            set
            {
                _stage7 = value;
                RaisePropertyChanged(nameof(Stage7));
            }
        }

        /// <summary>
        /// Car 8th stage upgrade to validate
        /// </summary>
        public string Stage8
        {
            get => _stage8;
            set
            {
                _stage8 = value;
                RaisePropertyChanged(nameof(Stage8));
            }
        }

        /// <summary>
        /// Car 9th stage upgrade to validate
        /// </summary>
        public string Stage9
        {
            get => _stage9;
            set
            {
                _stage9 = value;
                RaisePropertyChanged(nameof(Stage9));
            }
        }

        /// <summary>
        /// Car 10th stage upgrade to validate
        /// </summary>
        public string Stage10
        {
            get => _stage10;
            set
            {
                _stage10 = value;
                RaisePropertyChanged(nameof(Stage10));
            }
        }

        /// <summary>
        /// Car 11th stage upgrade to validate
        /// </summary>
        public string Stage11
        {
            get => _stage11;
            set
            {
                _stage11 = value;
                RaisePropertyChanged(nameof(Stage11));
            }
        }

        /// <summary>
        /// Car 12th stage upgrade to validate
        /// </summary>
        public string Stage12
        {
            get => _stage12;
            set
            {
                _stage12 = value;
                RaisePropertyChanged(nameof(Stage12));
            }
        }

        #endregion

        #region Performance

        /// <summary>
        /// Car stock speed to validate
        /// </summary>
        public string StockTopSpeed
        {
            get => _stockTopSpeed;
            set
            {
                _stockTopSpeed = value;
                RaisePropertyChanged(nameof(StockTopSpeed));
            }
        }

        /// <summary>
        /// Car stock acceleration to validate
        /// </summary>
        public string StockAcceleration
        {
            get => _stockAcceleration;
            set
            {
                _stockAcceleration = value;
                RaisePropertyChanged(nameof(StockAcceleration));
            }
        }

        /// <summary>
        /// Car stock handling to validate
        /// </summary>
        public string StockHandling
        {
            get => _stockHandling;
            set
            {
                _stockHandling = value;
                RaisePropertyChanged(nameof(StockHandling));
            }
        }

        /// <summary>
        /// Car stock nitro to validate
        /// </summary>
        public string StockNitro
        {
            get => _stockNitro;
            set
            {
                _stockNitro = value;
                RaisePropertyChanged(nameof(StockNitro));
            }
        }


        /// <summary>
        /// Car max speed to validate
        /// </summary>
        public string MaxTopSpeed
        {
            get => _maxTopSpeed;
            set
            {
                _maxTopSpeed = value;
                RaisePropertyChanged(nameof(MaxTopSpeed));
            }
        }

        /// <summary>
        /// Car max acceleration to validate
        /// </summary>
        public string MaxAcceleration
        {
            get => _maxAcceleration;
            set
            {
                _maxAcceleration = value;
                RaisePropertyChanged(nameof(MaxAcceleration));
            }
        }

        /// <summary>
        /// Car max handling to validate
        /// </summary>
        public string MaxHandling
        {
            get => _maxHandling;
            set
            {
                _maxHandling = value;
                RaisePropertyChanged(nameof(MaxHandling));
            }
        }

        /// <summary>
        /// Car max nitro to validate
        /// </summary>
        public string MaxNitro
        {
            get => _maxNitro;
            set
            {
                _maxNitro = value;
                RaisePropertyChanged(nameof(MaxNitro));
            }
        }


        #endregion

        #endregion

        #region IDataErrorInfo Members

        public string Error => this[null];

        /// <summary>
        /// IDataErrorInfo Implementations.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public string this[string propertyName]
        {
            get
            {
                string result = null;

                switch (propertyName)
                {
                    #region Informations

                    case nameof(Refill):
                    case nameof(RefillDetection):
                        result = DoubleValidation(out var refill, Refill);
                        var re = refill ?? 0;
                        if (RefillDetection == "Hr(s)")
                            Car.Refill = re * 60;
                        else
                            Car.Refill = re;
                        break;

                    #endregion

                    #region Blueprints Validation

                    case nameof(FirstStar):
                        result = IntegerValidation(out var firstStarBP, FirstStar);
                        Car.Blueprints.FirstStar = firstStarBP == 0 ? null : firstStarBP;
                        break;
                    case nameof(SecondStar):
                        result = IntegerValidation(out var secondStarBP, SecondStar);
                        Car.Blueprints.SecondStar = secondStarBP == 0 ? null : secondStarBP;
                        break;
                    case nameof(ThirdStar):
                        result = IntegerValidation(out var thirdStarBP, ThirdStar);
                        Car.Blueprints.ThirdStar = thirdStarBP == 0 ? null : thirdStarBP;
                        break;
                    case nameof(FourthStar):
                        result = IntegerValidation(out var fourthStarBP, FourthStar);
                        Car.Blueprints.FourthStar = fourthStarBP == 0 ? null : fourthStarBP;
                        break;
                    case nameof(FifthStar):
                        result = IntegerValidation(out var fifthStarBP, FifthStar);
                        Car.Blueprints.FifthStar = fifthStarBP == 0 ? null : fifthStarBP;
                        break;
                    case nameof(SixthStar):
                        result = IntegerValidation(out var sixthStarBP, SixthStar);
                        Car.Blueprints.SixthStar = sixthStarBP == 0 ? null : sixthStarBP;
                        break;


                    #endregion

                    #region Performance Validation

                    case nameof(StockTopSpeed):
                        result = DoubleValidation(out var stockTopSpeed, StockTopSpeed);
                        Car.Performance.StockTopSpeed = stockTopSpeed == 0 ? null : stockTopSpeed;
                        break;

                    case nameof(StockAcceleration):
                        result = DoubleValidation(out var stockAcceleration, StockAcceleration);
                        Car.Performance.StockAcceleration = stockAcceleration == 0 ? null : stockAcceleration;
                        break;

                    case nameof(StockHandling):
                        result = DoubleValidation(out var stockHandling, StockHandling);
                        Car.Performance.StockHandling = stockHandling == 0 ? null : stockHandling;
                        break;

                    case nameof(StockNitro):
                        result = DoubleValidation(out var stockNitro, StockNitro);
                        Car.Performance.StockNitro = stockNitro == 0 ? null : stockNitro;
                        break;

                    case nameof(MaxTopSpeed):
                        result = DoubleValidation(out var maxTopSpeed, MaxTopSpeed);
                        Car.Performance.MaxTopSpeed = maxTopSpeed == 0 ? null : maxTopSpeed;
                        break;

                    case nameof(MaxAcceleration):
                        result = DoubleValidation(out var maxAcceleration, MaxAcceleration);
                        Car.Performance.MaxAcceleration = maxAcceleration == 0 ? null : maxAcceleration;
                        break;

                    case nameof(MaxHandling):
                        result = DoubleValidation(out var maxHandling, MaxHandling);
                        Car.Performance.MaxHandling = maxHandling == 0 ? null : maxHandling;
                        break;

                    case nameof(MaxNitro):
                        result = DoubleValidation(out var maxNitro, MaxNitro);
                        Car.Performance.MaxNitro = maxNitro == 0 ? null : maxNitro;
                        break;

                    #endregion

                    #region Ranks Validation

                    case nameof(StockRank):
                        result = IntegerValidation(out var stockRank, StockRank);
                        Car.Ranks.Stock = stockRank == 0 ? null : stockRank;
                        break;

                    case nameof(FirstStarRank):
                        result = IntegerValidation(out var firstStarRank, FirstStarRank);
                        Car.Ranks.FirstStar = firstStarRank == 0 ? null : firstStarRank;
                        break;

                    case nameof(SecondStarRank):
                        result = IntegerValidation(out var secondStarRank, SecondStarRank);
                        Car.Ranks.SecondStar = secondStarRank == 0 ? null : secondStarRank;
                        break;

                    case nameof(ThirdStarRank):
                        result = IntegerValidation(out var thirdStarRank, ThirdStarRank);
                        Car.Ranks.ThirdStar = thirdStarRank == 0 ? null : thirdStarRank;
                        break;

                    case nameof(FourthStarRank):
                        result = IntegerValidation(out var fourthStarRank, FourthStarRank);
                        Car.Ranks.FourthStar = fourthStarRank == 0 ? null : fourthStarRank;
                        break;

                    case nameof(FifthStarRank):
                        result = IntegerValidation(out var fifthStarRank, FifthStarRank);
                        Car.Ranks.FifthStar = fifthStarRank == 0 ? null : fifthStarRank;
                        break;

                    case nameof(SixthStarRank):
                        result = IntegerValidation(out var sixthStarRank, SixthStarRank);
                        Car.Ranks.SixthStar = sixthStarRank == 0 ? null : sixthStarRank;
                        break;

                    #endregion

                    #region Upgrades Validation

                    case nameof(Stage0):
                        result = IntegerValidation(out var stage0, Stage0);
                        Car.Upgrades.Stage0 = stage0 == 0 ? null : stage0;
                        break;

                    case nameof(Stage1):
                        result = IntegerValidation(out var stage1, Stage1);
                        Car.Upgrades.Stage1 = stage1 == 0 ? null : stage1;
                        break;

                    case nameof(Stage2):
                        result = IntegerValidation(out var stage2, Stage2);
                        Car.Upgrades.Stage2 = stage2 == 0 ? null : stage2;
                        break;

                    case nameof(Stage3):
                        result = IntegerValidation(out var stage3, Stage3);
                        Car.Upgrades.Stage3 = stage3 == 0 ? null : stage3;
                        break;

                    case nameof(Stage4):
                        result = IntegerValidation(out var stage4, Stage4);
                        Car.Upgrades.Stage4 = stage4 == 0 ? null : stage4;
                        break;

                    case nameof(Stage5):
                        result = IntegerValidation(out var stage5, Stage5);
                        Car.Upgrades.Stage5 = stage5 == 0 ? null : stage5;
                        break;

                    case nameof(Stage6):
                        result = IntegerValidation(out var stage6, Stage6);
                        Car.Upgrades.Stage6 = stage6 == 0 ? null : stage6;
                        break;

                    case nameof(Stage7):
                        result = IntegerValidation(out var stage7, Stage7);
                        Car.Upgrades.Stage7 = stage7 == 0 ? null : stage7;
                        break;

                    case nameof(Stage8):
                        result = IntegerValidation(out var stage8, Stage8);
                        Car.Upgrades.Stage8 = stage8 == 0 ? null : stage8;
                        break;

                    case nameof(Stage9):
                        result = IntegerValidation(out var stage9, Stage9);
                        Car.Upgrades.Stage9 = stage9 == 0 ? null : stage9;
                        break;

                    case nameof(Stage10):
                        result = IntegerValidation(out var stage10, Stage10);
                        Car.Upgrades.Stage10 = stage10 == 0 ? null : stage10;
                        break;

                    case nameof(Stage11):
                        result = IntegerValidation(out var stage11, Stage11);
                        Car.Upgrades.Stage11 = stage11 == 0 ? null : stage11;
                        break;

                    case nameof(Stage12):
                        result = IntegerValidation(out var stage12, Stage12);
                        Car.Upgrades.Stage12 = stage12 == 0 ? null : stage12;
                        break;

                    #endregion

                    #region Additional Parts Validation

                    case nameof(EpicCost):
                        result = IntegerValidation(out var epicCost, EpicCost);
                        Car.AdditionalParts.EpicCost = epicCost == 0 ? null : epicCost;
                        break;

                    case nameof(RareCost):
                        result = IntegerValidation(out var rareCost, RareCost);
                        Car.AdditionalParts.RareCost = rareCost == 0 ? null : rareCost;
                        break;

                    case nameof(UncommonCost):
                        result = IntegerValidation(out var uncommonCost, UncommonCost);
                        Car.AdditionalParts.UncommonCost = uncommonCost == 0 ? null : uncommonCost;
                        break;
                        #endregion
                }

                return result;
            }
        }

        /// <summary>
        /// Implementing the validation of integers.
        /// </summary>
        /// <param name="output">The output integer</param>
        /// <param name="input">The Input value</param>
        /// <returns>The Integer in correction state, error validation message in case of not being compatible, null in case nothing has been provided.</returns>
        private string IntegerValidation(out int? output, string input)
        {
            var result = ValidateIntegers(out var value, input);
            if (result != null && result.Any(char.IsLetter))
            {
                output = null;
                return result;
            }

            output = value;

            return null;
        }

        /// <summary>
        /// Implementing the validation of doubles.
        /// </summary>
        /// <param name="output">The output double</param>
        /// <param name="input">The Input value</param>
        /// <returns>The Double in correction state, error validation message in case of not being compatible, null in case nothing has been provided.</returns>
        private string DoubleValidation(out double? output, string input)
        {
            var result = ValidateDoubles(out var value, input);
            if (result != null && result.Any(char.IsLetter))
            {
                output = null;
                return result;
            }

            output = value;
            return null;
        }

        /// <summary>
        /// Validating doubles in case provided.
        /// </summary>
        /// <param name="output">output value as double.</param>
        /// <param name="input">The Input string to validate.</param>
        /// <returns>if there was an error returns the error otherwise a double value.</returns>
        private string ValidateDoubles(out double output, string input)
        {
            string result = null;
            if (input.Length <= 0)
            {
                output = 0;
                return null;
            }

            if (!double.TryParse(input, out output))
                result = "This field can only contain numbers.";
            else if (double.Parse(input) < 0)
                result = "This field cannot accept negative numbers.";

            return result;
        }

        /// <summary>
        /// Validating integers in case provided.
        /// </summary>
        /// <param name="output">output value as int.</param>
        /// <param name="input">The Input string to validate.</param>
        /// <returns>if there was an error returns the error otherwise an integer value.</returns>
        private string ValidateIntegers(out int output, string input)
        {
            string result = null;
            if (input.Length <= 0)
            {
                output = 0;
                return null;
            }

            if (!int.TryParse(input, out output))
                result = "This field can only contain numbers.";
            else if (int.Parse(input) < 0)
                result = "This field cannot accept negative numbers.";

            return result;
        }

        #endregion

    }
}
