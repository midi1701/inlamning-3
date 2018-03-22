using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning3
{
    class Country
    {
        private string name;
        private int populationNumber;
        private int bnp;
        List<City> cities = new List<City> { };

        public Country(string countryNamn, int countryPopulationNumber, int countryBnp, City city)
        {
            name = countryNamn;
            populationNumber = countryPopulationNumber;
            bnp = countryBnp;
            cities.Add(city);
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

        public List<City> Cities
        {
            get { return cities; }
            set { cities = value; }
        }

        public int BNP
        {
            get { return bnp; }
            set { bnp = value; }
        }
    }
}
