using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Inlamning3
{
    internal class City
    {
        string name;
        int populationNumber;
        int populationAvrageIncome;
        int touristNumberPerYear;
        List<Accommodation> accommodation = new List<Accommodation> { };
        int accommodationCount;
        double avrageCoust;


        public City(string cityName, int cityPopulationNumber, int cityPopulationAvrageIncome, int cityTouristNumberPerYear,
            List<Accommodation> cityAccommodation, double cityAvrageCoust)
        {
            name = cityName;
            populationNumber = cityPopulationNumber;
            populationAvrageIncome = cityPopulationAvrageIncome;
            touristNumberPerYear = cityTouristNumberPerYear;
            accommodation = cityAccommodation;
            accommodationCount = cityAccommodation.Count();
            avrageCoust = cityAvrageCoust;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int PopulationNumber
        {
            get { return populationNumber; }
            set { populationNumber = value; }
        }
        public int PopulationAvrageIncome
        {
            get { return populationAvrageIncome; }
            set { populationAvrageIncome = value; }
        }
        public int TouristNumberPerYear
        {
            get { return touristNumberPerYear; }
            set { touristNumberPerYear = value; }
        }
        public List<Accommodation> Accommodation
        {
            get { return accommodation; }
            set { accommodation = value; }
        }
        public int AccommodationCount
        {
            get { return accommodationCount; }
            set { accommodationCount = value; }
        }
        public double AvrageCoust
        {
            get { return avrageCoust; }
            set { avrageCoust = value; }
        }
    }
}
