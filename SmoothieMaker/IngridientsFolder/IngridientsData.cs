using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmoothieMaker.IngridientsFolder;

namespace SmoothieMaker.IngridientsFolder
{
    internal class IngridientsData
    {
        private static string directory = @"C:\data\SmoothieMaker\";
        private static string ingridientsFileName = "IngridientsList.txt";


        public List<Ingridients> LoadIngridients()
        {
            List<Ingridients> ingridients = new List<Ingridients>();
            string path = $"{directory}{ingridientsFileName}";

            string[] ingridientsAsString = File.ReadAllLines(path);

            for (int i = 0; i < ingridientsAsString.Length; i++)
            {
                string[] ingridientsSplits = ingridientsAsString[i].Split(';');

                string name = ingridientsSplits[0];
                int quantity = int.Parse(ingridientsSplits[1]);
                Enum.TryParse(ingridientsSplits[2], out UnitType unitType);

                Ingridients ingridient = new Ingridients(name, quantity, unitType);

                ingridients.Add(ingridient);
            }

            return ingridients;
        }

        internal static void SaveChanges(List<Ingridients> ingridientsList)
        {

            string path = $"{directory}{ingridientsFileName}";

            System.IO.File.WriteAllText(path, string.Empty);

            StringBuilder sb = new StringBuilder();

            foreach (var ingridient in ingridientsList)
            {
                sb.Append($"{ingridient.Name};");
                sb.Append($"{ingridient.Quantity};");
                sb.Append($"{ingridient.UnitType};");
                sb.Append(Environment.NewLine);
            }

            File.WriteAllText(path, sb.ToString());

        }
    }
}
