using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2_GoldChallangeTwo_Repository;

namespace _2_GoldChallangeTwo_ConsoleApp
{
    class ProgramUI
    {
        public BadgeContentRepository _badgeContentRepo = new BadgeContentRepository();

        public void Run()
        {
            SeedContent(); 
            Menu();
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Hello Security Admin, Please choose an option(number) from the list below:\n" +
                "1.Add a badge \n" +
                "2.Edit a badge \n" +
                "3.List all Badges");

            string menuInput = Console.ReadLine();
            switch (menuInput)
            {
                case "1":
                    AddABadge();
                    break;
                case "2":
                    EditABadge();
                    break;
                case "3":
                    ListAllBadges();
                    break;
                default:
                    Console.WriteLine("Please enter a valid number");
                    break;
            }
        }

        private void AddABadge()
        {
            Console.Clear();
            List<string> newList = new List<string>();
            BadgeContent newBadge = new BadgeContent();
            Console.WriteLine("What is the number on the badge:");
            newBadge.BadgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("List a door that it needs access to:");
            string doorInputOne = Console.ReadLine().ToLower();
            newList.Add(doorInputOne);
            newBadge.DoorName = newList;

            _badgeContentRepo.CreateNewBadgeID(newBadge);

            bool doorAddLoop = true;
            while (doorAddLoop)
            {


                Console.WriteLine("Any other doors you need to add? (y/n)");
                string questionInput = Console.ReadLine().ToLower();
                switch (questionInput)
                {
                    case "y":
                        Console.WriteLine("List a door that it needs access to:");
                        string doorInputTwo = Console.ReadLine().ToLower();
                        newBadge.DoorName.Add(doorInputTwo);
                        break;
                    case "n":
                        doorAddLoop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input .Please input y/n. ");
                        break;

                }
            }

            Menu();




        }


        public void EditABadge()
        {
            Console.Clear();
            List<string> newList = new List<string>();
            BadgeContent existingBadge = new BadgeContent();
          

            Console.WriteLine("What is the badge number to update?");
            string userInputParse = Console.ReadLine();
            existingBadge.BadgeID = Int32.Parse(userInputParse);

            string badgeConfirmed = _badgeContentRepo.GetBadgeByKey(existingBadge.BadgeID);
            if (badgeConfirmed == null)
            {
                Console.WriteLine($"Badge # {userInputParse} does not exist in system.");
                Console.ReadLine();
                Menu();
            }
            int badgeConfirmedInt = Int32.Parse(badgeConfirmed);
            newList = _badgeContentRepo.GetDoorByKey(badgeConfirmedInt);
            
            if(badgeConfirmed != null)
            {
                Console.Clear();
                Console.WriteLine($"{badgeConfirmed} has access to the following doors :\n" +
                    $"{string.Join(System.Environment.NewLine, newList).ToLower()}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Badge number does not exist");
            }
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("What action would you like to do? \n" +
                "1. Remove a door \n" +
                "2. Add a door");
            string userInputTwo = Console.ReadLine();

            switch (userInputTwo)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Which door would you like to remove?");
                    string doorToRemove = Console.ReadLine().ToLower();
                    bool removeResult =_badgeContentRepo.RemoveDoorbyKey(doorToRemove);
                    if(removeResult)
                    { 
                    Console.WriteLine($"{badgeConfirmed} has access to the following doors :\n" +
                    $"{string.Join(System.Environment.NewLine, newList)}");
                    Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"Badge #{badgeConfirmed} does not have access to Door #{doorToRemove} ");
                        Console.ReadLine();
                    }
                    break;

                    

                case "2":
                    Console.Clear();
                    Console.WriteLine("List a door that it needs access to:");
                    string doorInputOne = Console.ReadLine().ToLower();
                    newList.Add(doorInputOne);
                    existingBadge.DoorName = newList;
                    _badgeContentRepo.AddValueToKey(existingBadge.BadgeID, existingBadge.DoorName);
                    Console.WriteLine($"{badgeConfirmed} has access to the following doors :\n" +
                    $"{string.Join(System.Environment.NewLine, newList)}");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Please input a valid option");
                    break;
                    

            }
            Menu();
                
            


        }

        public void ListAllBadges()
        {
            Console.Clear();
            string badge = "Badge#".PadRight(10);
            Console.Write(badge);
            Console.WriteLine("Door Access");

            foreach (int key in _badgeContentRepo._dictionary.Keys)
            {
                foreach (string item in _badgeContentRepo._dictionary[key])
                {
                    Console.Write("{0},", key);
                    Console.WriteLine("                {0},", item);
                }
                Console.WriteLine();
            }
            Console.ReadLine();

            Menu();
        }

        public void SeedContent()
        {
            BadgeContent existingBadge = new BadgeContent();
            List<string> newListB100 = new List<string>();
            List<string> newListB200 = new List<string>();
            List<string> newListB300 = new List<string>();
            newListB100.Add("a1");
            newListB100.Add("b2");
            newListB100.Add("b3");
            newListB200.Add("b2");
            newListB200.Add("b3");
            newListB300.Add("a1");
            newListB300.Add("b3");

            _badgeContentRepo._dictionary.Add(100, newListB100);
            _badgeContentRepo._dictionary.Add(200, newListB200);
            _badgeContentRepo._dictionary.Add(300, newListB300);




        }

    }
}
