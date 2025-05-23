using System;
using System.Collections.Generic;

namespace Small_Map_Virtual
{
    public interface IGraph<TCity, TRoad>
    {
        void AddCity(TCity city);
        void AddRoad(TRoad road);
        double CalculateDistance(TCity cityA, TCity cityB);
        string PrintGraph();
    }

    public class City
    {
        public string Name;
        public int X;
        public int Y;

        public City(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{Name} ({X}, {Y})";
        }
    }

    public class Road
    {
        public City CityA;
        public City CityB;
        public double Distance;

       // public Road(City cityA, City cityB)
       // {
         //   CityA = cityA;
           // CityB = cityB;
            //Distance = Math.Sqrt(Math.Pow(cityA.X - cityB.X, 2) + Math.Pow(cityA.Y - cityB.Y, 2));
        //}

        public Road(City cityA, City cityB, double distance)
        {
            CityA = cityA;
            CityB = cityB;
            Distance = distance;
        }

        public override string ToString()
        {
            return $"{CityA.Name} to {CityB.Name}: {Distance} km";
        }
    }


    public static class CityDatabase
    {
        public static List<City> Cities = new List<City>();

        public static void AddCity(City city)
        {
            Cities.Add(city);
        }
        
    }

    public class MapGraph : IGraph<City, Road>
    {
        private List<Road> Roads;

        public MapGraph()
        {
            Roads = new List<Road>();
        }

        public void AddCity(City city)
        {
            CityDatabase.AddCity(city);
        }

        public void AddRoad(Road road)
        {
            Roads.Add(road);
        }

        public double CalculateDistance(City cityA, City cityB)
        {
            return Math.Sqrt(Math.Pow(cityA.X - cityB.X, 2) + Math.Pow(cityA.Y - cityB.Y, 2));
        }

        public string PrintGraph()
        {
            string result = ":\n";
            for (int i = 0; i < CityDatabase.Cities.Count; i++) //count تعداد عناصر موجود در لیست رو بر میگردونه
            {
                result +="  ||  "+ CityDatabase.Cities[i].ToString() + "\n";
            }
            result += "Roads:\n";
            for (int i = 0; i < Roads.Count; i++)
            {
                result += "  ||  "+ Roads[i].ToString() + "\n";
            }
            return result;
        }
    }

}
