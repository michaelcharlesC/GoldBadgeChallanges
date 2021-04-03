using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _2_GoldChallangeTwo_Repository;
using System.Collections.Generic;

namespace _2_GoldChallangeTwo_Tests
{
    [TestClass]
    public class Repository_Tests
    {
        private BadgeContentRepository _testRepo = new BadgeContentRepository();
        [TestMethod]
        public void Test_GetBadgeByKey()
        {
            // arrange
            SeedContentList();
            int trueKey = 100;
            int falseKey = 900;

            // act
            string correctResult = _testRepo.GetBadgeByKey(trueKey);
            string incorrectResult = _testRepo.GetBadgeByKey(falseKey);

            // Assert
            Assert.IsNotNull(correctResult);
            Assert.IsNull(incorrectResult);
        }

        private void SeedContentList()
        {
            BadgeContent existingBadge = new BadgeContent();
            List<string> newListB100 = new List<string>();
            newListB100.Add("a1");
            newListB100.Add("b2");
            newListB100.Add("b3");
            _testRepo._dictionary.Add(100, newListB100);
        }

        [TestMethod]

        public void Test_CreateNewBadgeID()
        {
            //Arrange
            SeedContentList();
            List<string> testList = new List<string>();
            BadgeContent inputToAdd = new BadgeContent(555, testList);
            
            string resultContent;
            testList.Add("Test");

            //Act
            _testRepo.CreateNewBadgeID(inputToAdd);
            resultContent = _testRepo.GetBadgeByKey(555);

            //Assert
            Assert.IsNotNull(555);
            


        }

        [TestMethod]
        public void Test_AddValueToKey()
        {
            // Arrange
            SeedContentList();
            List<string> testExistingList = new List<string>();
            
            _testRepo._dictionary.Add(888, testExistingList);
            testExistingList.Add("existing");
           

            //Act
            _testRepo.AddValueToKey(888, testExistingList);
            bool result = _testRepo._dictionary.ContainsValue(testExistingList);
            
            // Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void Test_RemoveDoorByKey()
        {
            //Arrange
            SeedContentList();
            List<string> testList = new List<string>();
            testList.Add("test");
            BadgeContent inputToAdd = new BadgeContent(888, testList);
            _testRepo._dictionary.Add(888, testList);

            //Act
            bool result = _testRepo.RemoveDoorbyKey("test");

            //Assert
            Assert.IsTrue(result);



        }
        [TestMethod]
        public void Test_GetDoorByKey()
        {
            //Arrange 
            SeedContentList();
            List<string> testDoor = new List<string>();
            testDoor.Add("doorTest");
            BadgeContent addBadgeToDict = new BadgeContent(999, testDoor);

            //Act
            List<string> testResult = _testRepo.GetDoorByKey(100);
            int testResultCount = testResult.Count;


            //Assert
            Assert.AreEqual(3, testResultCount);
        }

            
            



        
    }
}
