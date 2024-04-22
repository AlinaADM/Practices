using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmoothieMaker.IngridientsFolder;

namespace SmoothieMaker
{
    internal class RecipiesData
    {
        private static string directory = @"C:\data\SmoothieMaker\";
        private static string recipiesFileName = "RecipiesList.txt";


        public List<Recipie> LoadRecipies()
        {
            List<Recipie> recipies = new List<Recipie>();

            string path = $"{directory}{recipiesFileName}";

            string[] recipiesAsString = File.ReadAllLines(path);

            for (int i = 0; i < recipiesAsString.Length; i++)
            {
                string[] recipiesSplits = recipiesAsString[i].Split(';');

                string number = recipiesSplits[0];
                string recipieName = recipiesSplits[1];
                string ingridient1 = recipiesSplits[2];
                int quantity1 = int.Parse(recipiesSplits[3]);
                Enum.TryParse(recipiesSplits[4], out UnitType unitType1);
                string ingridient2 = recipiesSplits[5];
                int quantity2 = int.Parse(recipiesSplits[6]);
                Enum.TryParse(recipiesSplits[7], out UnitType unitType2);

                Ingridients Ingridient1 = new Ingridients(ingridient1, quantity1, unitType1);
                Ingridients Ingridient2 = new Ingridients(ingridient2, quantity2, unitType2);

                Recipie recipie = new Recipie(number, recipieName, Ingridient1, Ingridient2);

                recipies.Add(recipie);
            }

            return recipies;
        }
       
    }
}
