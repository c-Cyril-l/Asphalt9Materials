using Asphalt_9_Materials.Core;
using Asphalt_9_Materials.ViewModel.Entities;
using System;

namespace Asphalt_9_Materials.ViewModel.Helpers
{
    public class GetModeledInformations
    {

        /// <summary>
        /// Getting information of every single car and provide its information to core car class.
        /// </summary>
        /// <param name="carEntity">Car to get informations.</param>
        /// <param name="isPath">Is car image pas has been provided?</param>
        /// <returns>The Car based on given car entity</returns>
        public Car GetCar(AddCars_Result carEntity, bool isPath = true)
        {
            return new Car()
            {
                CarName = carEntity.CarName,
                CarBrand = carEntity.CarBrand,
                FullName = carEntity.FullName,
                Stars = carEntity.Stars ?? 0,
                Image = isPath ? FileHelpers.ImagePath(carEntity.Image) : carEntity.Image,
                Refill = carEntity.Refill,
                Fuel = carEntity.Fuel,
                ReleaseDate = carEntity.ReleaseDate,
                CarClass = carEntity.CarClass,

                Type = Enum.Parse(typeof(CarType), carEntity.Type).ToString(),

                Performance = new Performance()
                {
                    MaxTopSpeed = carEntity.MaxSpeed ?? 0,
                    MaxAcceleration = carEntity.MaxAcceleration ?? 0,
                    MaxHandling = carEntity.MaxHandling ?? 0,
                    MaxNitro = carEntity.MaxNitro ?? 0,
                    StockTopSpeed = carEntity.StockSpeed ?? 0,
                    StockAcceleration = carEntity.StockAcceleration ?? 0,
                    StockHandling = carEntity.StockHandling ?? 0,
                    StockNitro = carEntity.StockNitro ?? 0,
                },

                Blueprints = new Core.Blueprint()
                {
                    FirstStar = carEntity.FirstStarBP,
                    SecondStar = carEntity.SecondStarBP,
                    ThirdStar = carEntity.ThirdStarBP,
                    FourthStar = carEntity.FourthStarBP,
                    FifthStar = carEntity.FifthStarBP,
                    SixthStar = carEntity.SixthStarBP,
                },
                Ranks = new Ranks()
                {
                    Stock = carEntity.StockStarRank,
                    FirstStar = carEntity.FirstStarRank,
                    SecondStar = carEntity.SecondStarRank,
                    ThirdStar = carEntity.ThirdStarRank,
                    FourthStar = carEntity.FourthStarRank,
                    FifthStar = carEntity.FifthStarRank,
                    SixthStar = carEntity.SixthStarRank,
                },
                Upgrades = new Upgrades()
                {
                    Stage0 = carEntity.Stage1,
                    Stage1 = carEntity.Stage2,
                    Stage2 = carEntity.Stage3,
                    Stage3 = carEntity.Stage4,
                    Stage4 = carEntity.Stage5,
                    Stage5 = carEntity.Stage6,
                    Stage6 = carEntity.Stage7,
                    Stage7 = carEntity.Stage8,
                    Stage8 = carEntity.Stage9,
                    Stage9 = carEntity.Stage10,
                    Stage10 = carEntity.Stage11,
                    Stage11 = carEntity.Stage12,
                    Stage12 = carEntity.Stage13,

                },

                AdditionalParts = new AdditionalParts()
                {
                    EpicQuantity = carEntity.EpicQuantity,
                    EpicCost = carEntity.EpicCost,

                    RareQuantity = carEntity.RareQuantity,
                    RareCost = carEntity.RareCost,

                    UncommonQuantity = carEntity.UncommonQuantity,
                    UncommonCost = carEntity.UncommonCost,
                }
            };


        }


        /// <summary>
        /// Getting information of every single chapter and provide its information to core career class.
        /// </summary>
        /// <param name="career">Career to get informations.</param>
        /// <returns>The Career based on given entity.</returns>
        public Core.Career GetCareer(AddChapters_Result career)
        {
            return new Core.Career()
            {
                Chapter = career.Chapter,
                Season = career.Season,
                Mode = career.Mode,
                Race = career.Race,
                Rank = career.Rank,
                Time = career.Time,
                Track = career.Track,
                Credits = career.Credits,
                Reputation = career.Reputation
            };
        }


    }
}
