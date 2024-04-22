using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmoothieMaker.IngridientsFolder;

namespace SmoothieMaker.IngridientsFolder
{
    public class Ingridients
    {
        private string name;
        private int quantity;
        private UnitType unitType;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public UnitType UnitType
        {
            get; set;
        }

        public Ingridients(string name, int quantity, UnitType unitType)
        {
            Name = name;
            Quantity = quantity;
            UnitType = unitType;
        }

        public virtual string DisplayDetails()
        {
            return $"{name}.........{quantity} {UnitType} in stock";
        }

        public void UseIngridients(int items)
        {
            Quantity -= items;

        }

        public void AddIngridient(int amount)
        {
            Quantity += amount;
        }
    }
}
