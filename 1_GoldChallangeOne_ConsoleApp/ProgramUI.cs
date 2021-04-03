using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_GoldChallangeOne_Repository;


namespace _1_GoldChallangeOne_ConsoleApp
{
    class ProgramUI
    {
        private MenuContentRepository _repoContent = new MenuContentRepository();

        public void Run()
        {
            SeedItemList();
            Menu();
        }

        public void Menu()
        {
            bool runningMenu = true;

            while (runningMenu)
            {

                
                Console.WriteLine("Welcome to Komodo Caffe \n" +
                    "Please choose a menu option number: \n" +
                    "" +
                    "1. See Full Menu, \n" +
                    "2. Add New Menu Items, \n" +
                    "3. Delete Menu Items \n" +
                    "4. Start New Order \n" +
                    "5. Check Ingredients List \n" +
                    "6. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        SeeFullMenu();
                        break;
                    case "2":
                        AddNewMenuItems();
                        break;
                    case "3":
                        DeleteMenuItems();
                        break;
                    case "4":
                        OrderPlacer();
                        Console.Clear();
                        break;
                    case "5":
                        CheckIngredientsList();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Program OFF , Goodbye!");
                        Console.ReadKey();
                        runningMenu = false;
                        break;
                }

            }


        }

        public void SeeFullMenu()
        {
            Console.Clear();
            List<MenuContent> fullListContent = _repoContent.SeeMenuList();
            foreach(MenuContent content in fullListContent)
            {
                Console.WriteLine($"Meal Number is :{content.MealNumber} \n"+
                    $"Meal Name :{content.MealName} \n" +
                    $"Items Description : {content.Description} \n" +
                    $"Item Ingredients : {content.Ingredients} \n" +
                    $"Price : {content.Price} \n");
            }
        }

        public void AddNewMenuItems()
        {
            Console.Clear();
            MenuContent newItem = new MenuContent();

            Console.WriteLine("Enter new meal reference number:");
            newItem.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new meal item name :");
            newItem.MealName = Console.ReadLine();
            Console.WriteLine("Enter new description for item:");
            newItem.Description = Console.ReadLine();
            Console.WriteLine("Enter new ingredients for item:");
            newItem.Ingredients = Console.ReadLine();
            Console.WriteLine("Enter new price for item:");
            newItem.Price = decimal.Parse(Console.ReadLine());

            _repoContent.AddItemToList(newItem);
            _repoContent.AddIngredientsList(newItem);
        }

        public void DeleteMenuItems()
        {
            Console.Clear();           
            SeeFullMenu();

            
            Console.WriteLine("Enter the number of the menu item for removal:");
            string inputString = Console.ReadLine();
            int input = int.Parse(inputString);

            bool isItemDeleted = _repoContent.RemoveItemFromList(input);

            if (isItemDeleted)
            {
                Console.Clear();
                Console.WriteLine("The item was deleted");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Item could not be deleted");
                Console.ReadLine();
            }
            
        }

        public void OrderPlacer()
        {
            Console.Clear();
            List<MenuContent> existingList = _repoContent.SeeMenuList();
            SeeFullMenu();
            Console.WriteLine("Choose an item number for the order:");
            int inputInt = int.Parse(Console.ReadLine());

            foreach (var itemNum in existingList)
            {
                if (inputInt == itemNum.MealNumber)
                {
                    Console.Clear();
                    Console.WriteLine($"Order has been placed succesfully for item number {inputInt}. You have a {itemNum.MealName}, and your total for today is ${itemNum.Price}.");
                    Console.ReadKey();
                }
                else if (inputInt <= existingList.Count)
                {
                    continue;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Your entry does not match any of the existing items");
                    Console.ReadKey();
                }
            }
            
        }

        public void CheckIngredientsList()
        {
            Console.Clear();
            List<MenuContent> ingList = _repoContent.SeeIngredientsList();
            foreach (MenuContent content in ingList)
            {
                Console.WriteLine($"{content.Ingredients} \n" +
                    $"");
                
            }
            Console.ReadKey();
            Console.Clear();
        }

        
        private void SeedItemList()
        {
            MenuContent breakfastSandwich = new MenuContent(1,"Morning Sandwich", "Grilled Cheese Sandwich with Ham and Egs", 10.99m, "Cheese, Bread, Ham and egs");
            MenuContent scrambledEgs = new MenuContent(2,"Breakfast Eggs", "Scrambled Eggs with fresh cucumbers,wheat bread and sausages", 7m, "Egs, sausages, vegetables, bread");
            MenuContent burrito = new MenuContent(3,"Morning Burito", "Scrambled Eggs in a buritto wrapp,added chease, chicken nuggets and hashbrown", 12.50m, "Egs, wrap, cheese, chicken nuggets and potato hasbrown");

            _repoContent.AddItemToList(breakfastSandwich);
            _repoContent.AddItemToList(scrambledEgs);
            _repoContent.AddItemToList(burrito);

            MenuContent breakfastSandwichIng = new MenuContent("Morning Sandwich -> Tasty provalone cheese, brown baked bread, sweet ham  and fresh egs -> 749 Calories");
            MenuContent scrambledEgsIng = new MenuContent("Breakfast Eggs -> Cage free egs, jucy pork sausages, whole wheat bread and fresh vegetables -> 600 Calories ");
            MenuContent burritoIng = new MenuContent("Morning Burito -> Cage free egs, flour burrito wrap, tasty provolane cheese, frozen chicken nuggets and potato hasbrown -> 923 Calories");

            _repoContent.AddIngredientsList(burritoIng);
            _repoContent.AddIngredientsList(scrambledEgsIng);
            _repoContent.AddIngredientsList(burritoIng);
        }



    }
}
