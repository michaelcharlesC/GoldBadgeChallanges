using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3_GoldChallangesThree_Repository;

namespace _3_GoldChallangesThree_ConsoleApp
{
    class ProgramUI
    {
        private ClaimContentRepo _contentRepo = new ClaimContentRepo();

        public void Run()
        {
            SeedClaimContent();
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();

                Console.WriteLine("Choose a menu item : \n" +
                   "1. See all claims \n" +
                   "2. Take care of next claim \n" +
                   "3. Enter new claim \n" +
                   "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        ProcessNextClaim();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "4":
                        keepRunning =false;
                        break;
                    default:
                        Console.WriteLine("Please input a valid option");
                        Menu();
                        break;
                }
            }


        }
        public void SeeAllClaims()
        {
            
            Queue<ClaimContent> listOfClaims = _contentRepo._claimsQueue;
            Console.Clear();
            Console.WriteLine("ClaimID      Type      Description         Amount($)      DateOfAccident         DateOfClaim             ClaimValid");
            foreach(ClaimContent claim in listOfClaims)
            {
                Console.WriteLine($"{claim.ClaimID}           {claim.ClaimType}      {claim.Description}     {claim.ClaimAmount}      {claim.DateOfIncident}      {claim.DateOfClaim}      {claim.IsValid} \n");
                
            }
            Console.ReadLine();
        }
        public void ProcessNextClaim()
        {
            Console.Clear();
           
            Queue<ClaimContent> listOfClaims = _contentRepo._claimsQueue;
            ClaimContent firstClaim = listOfClaims.First<ClaimContent>();

            Console.WriteLine($"ClaimID: {firstClaim.ClaimID} \n" +
                $"Type: {firstClaim.ClaimType} \n" +
                $"Description: {firstClaim.Description} \n" +
                $"Amount: ${firstClaim.ClaimAmount} \n" +
                $"DateOfAccident: {firstClaim.DateOfIncident} \n" +
                $"DateOfClaim: {firstClaim.DateOfClaim} \n" +
                $"IsValid: {firstClaim.IsValid} ");
            Console.WriteLine("Do you want to deal with this claim now (y/n)?");
            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case "y":
                    Console.Clear();
                    listOfClaims.Dequeue();
                    Console.WriteLine("Claim processed");
                    Console.ReadLine();
                    break;
                case "n":
                    Menu();
                    break;
            }
        }
        public void CreateNewClaim()
        {
            Console.Clear();
            ClaimContent claimToBeAdded = new ClaimContent();
            Console.WriteLine("Enter the claim ID :");
            string claimIDstring= Console.ReadLine();
            claimToBeAdded.ClaimID = int.Parse(claimIDstring);

            Console.WriteLine("Enter the claim type number : \n" +
                "1.Car \n" +
                "2.Home \n" +
                "3.Theft");
            string claimTypeString = Console.ReadLine();
            int claimTypeInt = int.Parse(claimTypeString);
            claimToBeAdded.ClaimType = (ClaimType)claimTypeInt;

            Console.WriteLine("Enter a claim description : ");
            claimToBeAdded.Description = Console.ReadLine();

            Console.WriteLine("Amount of Damage :$ ");
            string claimAmountString = Console.ReadLine();
            decimal claimAmountDec = decimal.Parse(claimAmountString);
            claimToBeAdded.ClaimAmount = claimAmountDec;

            Console.WriteLine("Date of Accident (YYYY,MM,DD): ");
            string claimAccidentString = Console.ReadLine();
            DateTime claimAccidentDate = DateTime.Parse(claimAccidentString);
            claimToBeAdded.DateOfIncident = claimAccidentDate;

            Console.WriteLine("Date of claim (YYYY,MM,DD): ");
            string claimDateString = Console.ReadLine();
            DateTime claimDate = DateTime.Parse(claimDateString);
            claimToBeAdded.DateOfClaim = claimDate;
            int claimValidation = (int)(claimDate - claimAccidentDate).TotalDays;

            if(claimValidation <= 30)
            {
                Console.WriteLine("This claim is Valid");
                claimToBeAdded.IsValid = true;
                bool wasCreated= _contentRepo.CreateNewClaim(claimToBeAdded);
                if (wasCreated)
                {
                    Console.WriteLine("This claim was created and added to the list");
                }
                else
                {
                    Console.WriteLine("FAILED : Some information was not correct. Please try again");
                    
                }
            }
            else
            {
                Console.WriteLine("Claim is NOT valid. \n" +
                    "A claim needs to be subbmited no more than 30 days after an incident took place." );
                Console.ReadLine();
                Console.Clear();
                Menu();
            }




        }

        public void SeedClaimContent()
        {
            ClaimContent firstClaim = new ClaimContent(001, ClaimType.Car, "Frontal crash, I65", 10.000m, new DateTime(2021, 03, 01,12,30,20), new DateTime(2021, 03, 27,11, 30, 20), true);
            ClaimContent secondClaim = new ClaimContent(002, ClaimType.Home, "Tornado damage", 100.000m, new DateTime(2021, 01, 10,08,23,54), new DateTime(2021, 02, 02,06, 34, 22), true);
            ClaimContent thirdClaim = new ClaimContent(003, ClaimType.Theft, "House robbery ", 3.000m, new DateTime(2020, 07, 11,02,04,06), new DateTime(2020, 10, 27,04, 20, 10), false);

            _contentRepo._claimsList.Add(firstClaim);
            _contentRepo._claimsList.Add(secondClaim);
            _contentRepo._claimsList.Add(thirdClaim);

            _contentRepo._claimsQueue.Enqueue(firstClaim);
            _contentRepo._claimsQueue.Enqueue(secondClaim);
            _contentRepo._claimsQueue.Enqueue(thirdClaim);

        }

    }
}
