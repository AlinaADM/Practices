using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SmoothieMaker.IngridientsFolder;

namespace SmoothieMaker
{
    public class Recipie
    {
        private string number;
        private string recipieName;
        private Ingridients ingridient1;
        private Ingridients ingridient2;

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        public string RecipieName
        {
            get { return recipieName; }
            set { recipieName = value; }
        }

        public Ingridients Ingridient1
        {
            get { return ingridient1; }
            set { ingridient1 = value; }
        }

        public Ingridients Ingridient2
        {
            get { return ingridient2; }
            set { ingridient2 = value; }
        }

        public Recipie(string number, string recipieName)
        {

        }

        public Recipie(string number, string recipieName, Ingridients ingridient1, Ingridients ingridient2)
        {
            Number = number;
            RecipieName = recipieName;
            Ingridient1 = ingridient1;
            Ingridient2 = ingridient2;
        }

        public virtual string DisplayDetails()
        {
            return $"{number}: {recipieName} \nIngridients:\n {ingridient1.Name} {ingridient1.Quantity} {ingridient1.UnitType}\n {ingridient2.Name} {ingridient2.Quantity} {ingridient2.UnitType}\n ";
        }

        
    }
}
