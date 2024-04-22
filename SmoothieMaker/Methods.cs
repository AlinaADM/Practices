using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmoothieMaker.IngridientsFolder;

namespace SmoothieMaker
{
    public class Methods
    {

        private static List<Ingridients> ingridientsList = new();
        private static List<Recipie> recipiesList = new();

        internal static void ShowStock()
        {     
            foreach(var ingridient in ingridientsList)
            {
                Console.WriteLine(ingridient.DisplayDetails());
            }
        }

        internal static void ShowRecipies()
        {
            RecipiesData recipiesData = new RecipiesData();
            recipiesList = recipiesData.LoadRecipies();

            foreach(var recipe in recipiesList)
            {
                Console.WriteLine(recipe.DisplayDetails());
            }
        }

        internal static void LoadIngridientsStart()
        {
            IngridientsData ingridientsData = new IngridientsData();
            ingridientsList = ingridientsData.LoadIngridients();
        }

        internal static void ShowMainMenu()
        {
            Console.WriteLine("Select an action");

            Console.WriteLine("1: Make a smoothie");
            Console.WriteLine("2: Check ingridients stock");
            Console.WriteLine("3: Update stock");
            Console.WriteLine("4: Exit");

            Console.WriteLine("Your selection: ");

            string userSelection = Console.ReadLine();
            switch(userSelection)
            {
                case "1":
                    MakeSmoothie();
                    break;
                case "2":
                    ShowIngridientsMenu();
                    break;
                case "3":
                    UpdateStock();
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try agagin");
                    break;
            }
        }

        internal static void MakeSmoothie()
        {
            Console.WriteLine("Recipies are loading...");
            Console.WriteLine("AVALAIBALE RECIPIES");
            Console.WriteLine();

            ShowRecipies();
            Console.WriteLine("Enter number of recipe that you would like to make:");
            string selectedNumber= Console.ReadLine();

            if(selectedNumber != null)
            {
                Recipie selectedRecipe = recipiesList.Where(p  => p.Number == selectedNumber).FirstOrDefault();
                if(selectedRecipe != null)
                {
                    Console.WriteLine(selectedRecipe.DisplayDetails());

                    Console.WriteLine("Do you want make selected Smoothie?");
                    Console.WriteLine("yes/no");

                    string userSelection = Console.ReadLine();

                    int amount1 = selectedRecipe.Ingridient1.Quantity;
                    int amount2 = selectedRecipe.Ingridient2.Quantity;

                    string ingridientName1 = selectedRecipe.Ingridient1.Name;
                    string ingridientName2 = selectedRecipe.Ingridient2.Name;

                    Ingridients selectedIngridient1 = ingridientsList.Where(p=>p.Name == ingridientName1).FirstOrDefault();
                    Ingridients selectedIngridient2 = ingridientsList.Where(p => p.Name == ingridientName2).FirstOrDefault();

                    if (userSelection == "yes")
                    {
                        if(selectedIngridient1.Quantity < 0 || selectedIngridient2.Quantity < 0 || amount1 > selectedIngridient1.Quantity || amount2 > selectedIngridient2.Quantity)
                        {
                            Console.WriteLine("Sorry, you do not have enough ingridients to make selected recipe");
                            Console.WriteLine("Fill your stock or choose another recipe");
                        }
                        else
                        {
                            selectedIngridient1.UseIngridients(amount1);
                            selectedIngridient2.UseIngridients(amount2);

                            Console.WriteLine("Smoothie was made");
                            Console.WriteLine("You have left:");
                            Console.WriteLine(selectedIngridient1.DisplayDetails());
                            Console.WriteLine(selectedIngridient2.DisplayDetails());

                        }
                    }
                }
            }
            ShowMainMenu();
        }

        internal static void ShowIngridientsMenu()
        {
            ShowStock();
            ShowMainMenu();
        }

        public static void UpdateStock()
        {
            Console.WriteLine("What ingridient would you like to update?");

            ShowStock();

            string userSelection = Console.ReadLine();
            Ingridients selectedIngridient = ingridientsList.Where(p => p.Name == userSelection).FirstOrDefault();

            Console.WriteLine("How much stock would you like to add?");
            int amount = int.Parse(Console.ReadLine());
            selectedIngridient.AddIngridient(amount);

            Console.WriteLine("Adding quantity...");
            Console.WriteLine("Successfully added");
            Console.WriteLine($"New amount in stock is:\n{selectedIngridient.DisplayDetails()}");

            Console.WriteLine("Do you want to save changes to file?");
            userSelection = Console.ReadLine();

            if(userSelection == "yes")
            {
                IngridientsData.SaveChanges(ingridientsList);
            }

            ShowMainMenu();
        }
       
    }
}
