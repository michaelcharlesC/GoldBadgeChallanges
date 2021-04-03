using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5_GoldChallangeFive_Repository;

namespace _5_GoldChallangeFive_ConsoleApp
{
    class ProgramUI
    {
        private CustomerRepository _customerRepo = new CustomerRepository();

        public void Run()
        {
            SeedCustomerList();
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to Komodo Insurance! \n" +
                    "Please choose a menu number: \n" +
                    "1) View list of customers with greeting emails(Alphabetical order) \n" +
                    "2) Create new customer and assign greet email \n" +
                    "3) Update existing customer \n" +
                    "4) Delete existing customer \n" +
                    "5) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        DisplayLists();
                        break;
                    case "2":
                        CreateNewCustomer();
                        break;
                    case "3":
                        UpdateExistingCustomer();
                        break;
                    case "4":
                        DeleteCustomer();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        Menu();
                        break;

                }
            }

        }

        public void DisplayLists()
        {
            Console.Clear();
            List<CustomerClass> list = _customerRepo.GetCustomerList();

            Console.WriteLine("FirstName       LastName      Type           Email");
            foreach (CustomerClass customer in list)
            {
                Console.WriteLine($"{customer.FirstName}          {customer.LastName}          {customer.Type}     {_customerRepo.GetGreetEmail(customer.Type)}");
            }
            Console.ReadLine();
        }

        public void CreateNewCustomer()
        {
            Console.Clear();
            CustomerClass newCustomer = new CustomerClass();

            Console.WriteLine("Enter first name :");
            newCustomer.FirstName = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter last name :");
            newCustomer.LastName = Console.ReadLine().ToUpper();
            Console.WriteLine("Choose a customer type number:  \n" +
                "1) Current \n" +
                "2) Past \n" +
                "3) Potential ");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    newCustomer.Type = CustomerType.Current;
                    break;
                case "2":
                    newCustomer.Type = CustomerType.Past;
                    break;
                case "3":
                    newCustomer.Type = CustomerType.Potential;
                    break;
                default:
                    Console.WriteLine("Invalid option, returning to menu...");
                    Menu();
                    break;
            }
            _customerRepo.AddNewCustomer(newCustomer);
            List<CustomerClass> existingListUpdated = _customerRepo.GetCustomerList();
            if (existingListUpdated.Contains(newCustomer))
            {
                Console.Clear();
                Console.WriteLine("User was added !");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Something went wrong, please try again");
                Console.ReadLine();
                Menu();
            }


        }



        public void UpdateExistingCustomer()
        {
            Console.Clear();
            CustomerClass newCustomer = new CustomerClass();
            DisplayLists();

            Console.WriteLine("Enter the first name of the existing user");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the last name of the existing user");
            string lastName = Console.ReadLine();

            CustomerClass existingCustomer = _customerRepo.GetCustomerByName(firstName, lastName);
            if (existingCustomer == null)
            {
                Console.Clear();
                Console.WriteLine("User does not exist in system.");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();

                Console.WriteLine("User was found in system! \n" +
                    "Enter new user first name: ");
                newCustomer.FirstName = Console.ReadLine();
                Console.WriteLine("Enter new user last name");
                newCustomer.LastName = Console.ReadLine();

                Console.WriteLine("Choose a customer type number:  \n" +
                    "1) Current \n" +
                    "2) Past \n" +
                    "3) Potential ");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        newCustomer.Type = CustomerType.Current;
                        break;
                    case "2":
                        newCustomer.Type = CustomerType.Past;
                        break;
                    case "3":
                        newCustomer.Type = CustomerType.Potential;
                        break;
                    default:
                        Console.WriteLine("Invalid option, returning to menu...");
                        Menu();
                        break;
                }

                bool wasAdded = _customerRepo.UpdateCustomer(firstName,lastName ,newCustomer);
                if (wasAdded)
                {
                    Console.Clear();
                    Console.WriteLine("User was updated !");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("User was not updated.Please try again");
                    Console.ReadLine();
                }
            }
        }

        public void DeleteCustomer()
        {
            Console.Clear();
            DisplayLists();
            CustomerClass existingUser = new CustomerClass();

            Console.WriteLine("Enter the first name of the user you want to remove:");
            existingUser.FirstName = Console.ReadLine();
            Console.WriteLine("Enter the last name of the user you want to remove:");
            existingUser.LastName = Console.ReadLine();

            bool deleteResult = _customerRepo.DeleteCustomer(existingUser.FirstName, existingUser.LastName);
            if (deleteResult)
            {
                Console.WriteLine("User was deleted!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("User was not deleted. please try again");
                Console.ReadLine();

            }
            Console.Clear();
        }

        public void SeedCustomerList()
        {
            CustomerClass user1 = new CustomerClass("JHONY", "BRAVO", CustomerType.Current);
            CustomerClass user2 = new CustomerClass("CHRIS", "JACK", CustomerType.Past);
            CustomerClass user3 = new CustomerClass("DONALD", "DUCK", CustomerType.Potential);
            CustomerClass user4 = new CustomerClass("JACKIE", "CHAN", CustomerType.Potential);

            _customerRepo.AddNewCustomer(user1);
            _customerRepo.AddNewCustomer(user2);
            _customerRepo.AddNewCustomer(user3);
            _customerRepo.AddNewCustomer(user4);

            _customerRepo._listOfEmails.Add(CustomerType.Current, "We currently have the lowest rates on Helicopter Insurance!");
            _customerRepo._listOfEmails.Add(CustomerType.Past, "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
            _customerRepo._listOfEmails.Add(CustomerType.Potential, "It's been a long time since we've heard from you, we want you back");
        }

    }
}
