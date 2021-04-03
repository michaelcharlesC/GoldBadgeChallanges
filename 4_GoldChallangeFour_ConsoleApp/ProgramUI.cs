using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4_GoldChallangeFour_Repository;

namespace _4_GoldChallangeFour_ConsoleApp
{
    class ProgramUI
    {
        private OutingsRepository _outingsRepo = new OutingsRepository();

        public void Run()
        {
            SeedOutingsList();
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Komodo Outings! \n" +
                    "Please select a number from menu to continue : \n" +
                    "\n" +
                    "1. See the list of all outings \n" +
                    "2. Add new outings to the list \n" +
                    "3. Outings Calculator \n" +
                    "4. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SeeOutingsList();
                        break;
                    case "2":
                        AddOutingsToList();
                        break;
                    case "3":
                        OutingsCalculator();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please input a valid option");
                        Console.ReadLine();
                        Menu();
                        break;
                }

            }
            
        }

        public void SeeOutingsList()
        {
            Console.Clear();
            List<OutingsContent> listOfOutings = _outingsRepo.DisplayList();
            Console.WriteLine("TotalCostPerPerson      Attendees      EventDate                    TotalCostPerson        EventType    ");
            foreach (OutingsContent outings in listOfOutings)
            {
                Console.WriteLine($"${outings.TotalCostPerson}                         {outings.Attendees}       {outings.EventDate}              ${outings.TotalCostPerson}                {outings.EventType}");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }

        public void AddOutingsToList()
        {
            Console.Clear();
            List<OutingsContent> listOfOutings = _outingsRepo.DisplayList();
            OutingsContent newOutings = new OutingsContent();
            Console.WriteLine("Please enter the Event Type : \n" +
                "1. Golf \n" +
                "2. Bowling \n" +
                "3. Amusement Park \n" +
                "4. Concert");
            string eventAsString = Console.ReadLine();
            int eventAsInt = Int32.Parse(eventAsString);
            newOutings.EventType = (EventType)eventAsInt;

            Console.WriteLine("Enter the number of attendees : ");
            string attendeesString = Console.ReadLine();
            int attendeesInt = Int32.Parse(attendeesString);
            newOutings.Attendees = attendeesInt;

            Console.WriteLine("Enter the Date of the event (YYYY/MM/DD): ");
            string dateAsString = Console.ReadLine();
            DateTime dateEvent = DateTime.Parse(dateAsString);
            newOutings.EventDate = dateEvent;

            Console.WriteLine("Enter the total cost per person : ");
            string totalCostString = Console.ReadLine();
            int totalCostInt = Int32.Parse(totalCostString);
            newOutings.TotalCostPerson = totalCostInt;

            double totalCost = newOutings.TotalCostPerson * newOutings.Attendees;
            Console.WriteLine($"Estimated total cost for the event is ${totalCost}. \n" +
                $"Would you like to enter a custom cost for the event? (y/n): ");
            string userInputCost = Console.ReadLine().ToLower();
            switch (userInputCost)
            {
                case "y":
                    Console.WriteLine("Please enter total cost for the event: ");
                    string eventCostString = Console.ReadLine();
                    int eventCostInt = Int32.Parse(eventCostString);
                    newOutings.TotalCostEvent = eventCostInt;
                    _outingsRepo.AddOutings(newOutings);
                    break;
                case "n":
                    newOutings.TotalCostEvent = totalCost;
                    _outingsRepo.AddOutings(newOutings);
                    break;


            }
            
            if (listOfOutings.Contains(newOutings))
            {
                Console.WriteLine("Successfully added to the list");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("FAILED to add to list. Please try again");
                Console.ReadLine();
                Console.Clear();
            }

            
        }

            

        public void OutingsCalculator()
        {
            Console.Clear();
            
            OutingsContent outings = new OutingsContent();
            Console.WriteLine("1. See total cost for all outings combined \n" +
                "2. See total cost for all outings of type GOLF \n" +
                "3. See total cost for all outings of type BOWLING \n" +
                "4. See total cost for all outings of type AMUSEMENT PARK \n" +
                "5. See total cost for all outings of type CONCERT \n" +
                "6. Back to MENU");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    string resultAll = _outingsRepo.CalculationsAll();
                    Console.WriteLine($"Total cost for ALL events is : ${resultAll}");
                    Console.ReadLine();
                    break;
                case "2":
                    string resultGolf = _outingsRepo.CalculationsOutingsGolf();
                    Console.WriteLine($"Total cost for GOLF events is : ${resultGolf}");
                    Console.ReadLine();
                    break;
                case "3":
                    string resultBowling = _outingsRepo.CalculationsOutingsBowling();
                    Console.WriteLine($"Total cost for GOLF events is : ${resultBowling}");
                    Console.ReadLine();
                    break;
                case "4":
                    string resultAmusementPark = _outingsRepo.CalculationsOutingsAmusementPark();
                    Console.WriteLine($"Total cost for GOLF events is : ${resultAmusementPark}");
                    Console.ReadLine();
                    break;
                case "5":
                    string resultConcerts = _outingsRepo.CalculationsOutingsConcerts();
                    Console.WriteLine($"Total cost for GOLF events is : ${resultConcerts}");
                    Console.ReadLine();
                    break;
                case "6":
                    Menu();
                    break;
                default:
                    Console.WriteLine("Please input a valid option");
                    Console.ReadLine();
                    break;
            }
            Console.Clear();


        }


        public void SeedOutingsList()
        {
            OutingsContent outingsOne = new OutingsContent(EventType.Concert, 200, new DateTime(2020, 03, 20,11,20,10), 100, 20000);
            OutingsContent outingsTwo = new OutingsContent(EventType.Golf, 30, new DateTime(2021, 06, 22, 12, 30, 20), 150, 4500);
            OutingsContent outingsThree = new OutingsContent(EventType.Bowling, 70, new DateTime(2019, 01, 11, 08, 23, 54), 80, 5600);
            OutingsContent outingsFour = new OutingsContent(EventType.AmusementPark, 300, new DateTime(2021, 02, 25, 02, 04, 06), 70, 21000);
            OutingsContent outingsFive = new OutingsContent(EventType.Concert, 101, new DateTime(2020, 07, 11, 04, 14, 06), 100, 10100);
            OutingsContent outingsSix = new OutingsContent(EventType.Golf, 25, new DateTime(2021, 07, 30, 09, 13, 02), 150, 3750);
            OutingsContent outingsSeven = new OutingsContent(EventType.Bowling, 100, new DateTime(2021, 08, 02, 10, 22, 10), 80, 8000);
            OutingsContent outingsEight = new OutingsContent(EventType.AmusementPark, 255, new DateTime(2020, 12, 25, 05, 21, 10), 70, 17850);

            _outingsRepo.AddOutings(outingsOne);
            _outingsRepo.AddOutings(outingsTwo);
            _outingsRepo.AddOutings(outingsThree);
            _outingsRepo.AddOutings(outingsFour);
            _outingsRepo.AddOutings(outingsFive);
            _outingsRepo.AddOutings(outingsSix);
            _outingsRepo.AddOutings(outingsSeven);
            _outingsRepo.AddOutings(outingsEight);
        }
    }
}
