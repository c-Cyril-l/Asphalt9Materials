using Asphalt_9_Materials.ViewModel.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asphalt_9_Materials.ViewModel.Helpers
{
    public class GettingInfo
    {
        /// <summary>
        /// Executing a stored procedure asynchronously to get the given car informations.
        /// </summary>
        /// <param name="carName">Car Name</param>
        /// <param name="a9">Asphalt 9 Entity</param>
        /// <returns>A Task of all informations required for a specific car.</returns>
        public async Task<AddCar_Result> GettingCarAsync(string carName, Asphalt9Entities a9)
        {
            return await a9.Database.SqlQuery<AddCar_Result>(sql: "EXEC AddCar {0}", carName).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chapter">Career Chapter</param>
        /// <param name="a9">Asphalt 9 Entity</param>
        /// <param name="isChapter">is chapter has been provided or not.</param>
        /// <returns>A List of career chapters depending on whether the chapter has been specified if yes then the list of specified chapter informations
        /// if not get all chapters informations.</returns>
        public async Task<List<AddChapters_Result>> GettingCareerAsync(int chapter, Asphalt9Entities a9, bool isChapter = true)
        {
            return await a9.Database.SqlQuery<AddChapters_Result>(sql: "EXEC AddChapters {0}, {1}", chapter, isChapter).ToListAsync();
        }

        /// <summary>
        /// Executing a stored procedure asynchronously to get cars.
        /// </summary>
        /// <param name="carClass">The Class to get cars.</param>
        /// <param name="a9">Asphalt 9 Entity</param>
        /// <param name="isClass">is class has been provided or not.</param>
        /// <returns>A List of cars depending on whether the class has been specified if yes then the list of specified class
        /// if not get all available cars.</returns>
        public async Task<List<AddCars_Result>> GettingCarsAsync(string carClass, Asphalt9Entities a9, bool isClass = true)
        {
            return await a9.Database.SqlQuery<AddCars_Result>(sql: "EXEC AddCars {0}, {1}", carClass, isClass).ToListAsync();
        }


    }
}
