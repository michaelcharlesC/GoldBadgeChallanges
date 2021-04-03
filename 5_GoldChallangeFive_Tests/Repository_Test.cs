using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _5_GoldChallangeFive_Repository;
using System.Collections.Generic;

namespace _5_GoldChallangeFive_Tests
{
    [TestClass]
    public class Repository_Test
    {
        CustomerRepository _testRepo = new CustomerRepository();

        [TestMethod]
        public void AddNewCustomer()
        {
            SeedCustomerList();
            bool expectedResult = false;
            CustomerClass testUser = new CustomerClass("test","test",CustomerType.Potential);
            List<CustomerClass> testList = _testRepo.GetCustomerList();
            testList.Add(testUser);

            if (testList.Contains(testUser))
            {
                expectedResult = true;
            }
            else
            {
                expectedResult = false;
            }
            Assert.IsTrue(expectedResult);

        }

        public void SeedCustomerList()
        {
            CustomerClass user1 = new CustomerClass("JHONY", "BRAVO", CustomerType.Current);
            _testRepo.AddNewCustomer(user1);

            _testRepo._listOfEmails.Add(CustomerType.Current, "We currently have the lowest rates on Helicopter Insurance!");
            _testRepo._listOfEmails.Add(CustomerType.Potential, "It's been a long time since we've heard from you, we want you back");
        }

        [TestMethod]
        public void Test_GetCustomerList()
        {
            SeedCustomerList();
            List<CustomerClass> testList = _testRepo.GetCustomerList();

            int result = testList.Count;
            int expected = 1;

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void Test_UpdateCustomer()
        {
            SeedCustomerList();
            CustomerClass testUser = new CustomerClass("TEST", "TEST", CustomerType.Potential);
            string toRemoveFirstName = "TEST";
            string toRemoveLastName = "TEST";
            
            _testRepo.AddNewCustomer(testUser);
            bool result = _testRepo.UpdateCustomer(toRemoveFirstName, toRemoveLastName, testUser);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Test_DeleteCustomer()
        {
            SeedCustomerList();
            CustomerClass testUser = new CustomerClass("TEST", "TEST", CustomerType.Potential);
            string toRemoveFirstName = "TEST";
            string toRemoveLastName = "TEST";

            _testRepo.AddNewCustomer(testUser);
            bool result = _testRepo.DeleteCustomer(toRemoveFirstName, toRemoveLastName);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void Test_GetCustomerByName()
        {
            SeedCustomerList();
            CustomerClass testUser = new CustomerClass("TEST", "TEST", CustomerType.Potential);
            string toRemoveFirstName = "TEST";
            string toRemoveLastName = "TEST";

            _testRepo.AddNewCustomer(testUser);
            CustomerClass result = _testRepo.GetCustomerByName(toRemoveFirstName, toRemoveLastName);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_GetGreetEmail()
        {
            SeedCustomerList();
            CustomerClass testUser = new CustomerClass("TEST", "TEST", CustomerType.Potential);

            _testRepo.AddNewCustomer(testUser);
            string emailResult = _testRepo.GetGreetEmail(testUser.Type);

            Assert.IsNotNull(emailResult);
        }
    }
}
