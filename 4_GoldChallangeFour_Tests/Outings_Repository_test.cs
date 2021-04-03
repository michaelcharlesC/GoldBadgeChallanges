using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _4_GoldChallangeFour_Repository;
using System.Collections.Generic;

namespace _4_GoldChallangeFour_Tests
{
    [TestClass]
    public class Outings_Repository_test
    {
        private OutingsRepository _testRepo = new OutingsRepository();

        [TestMethod]
        public void Test_DisplayList() 
        {
            SeedOutingsList();
            List<OutingsContent> testList = _testRepo.DisplayList();
            int result = testList.Count;
            int expected = 8;
            Assert.AreEqual(expected, result);


        }

        public void SeedOutingsList()
        {
            OutingsContent outingsOne = new OutingsContent(EventType.Concert, 200, new DateTime(2020, 03, 20, 11, 20, 10), 100, 20000);
            OutingsContent outingsTwo = new OutingsContent(EventType.Golf, 30, new DateTime(2021, 06, 22, 12, 30, 20), 150, 4500);
            OutingsContent outingsThree = new OutingsContent(EventType.Bowling, 70, new DateTime(2019, 01, 11, 08, 23, 54), 80, 5600);
            OutingsContent outingsFour = new OutingsContent(EventType.AmusementPark, 300, new DateTime(2021, 02, 25, 02, 04, 06), 70, 21000);
            OutingsContent outingsFive = new OutingsContent(EventType.Concert, 101, new DateTime(2020, 07, 11, 04, 14, 06), 100, 10100);
            OutingsContent outingsSix = new OutingsContent(EventType.Golf, 25, new DateTime(2021, 07, 30, 09, 13, 02), 150, 3750);
            OutingsContent outingsSeven = new OutingsContent(EventType.Bowling, 100, new DateTime(2021, 08, 02, 10, 22, 10), 80, 8000);
            OutingsContent outingsEight = new OutingsContent(EventType.AmusementPark, 255, new DateTime(2020, 12, 25, 05, 21, 10), 70, 17850);

            _testRepo.AddOutings(outingsOne);
            _testRepo.AddOutings(outingsTwo);
            _testRepo.AddOutings(outingsThree);
            _testRepo.AddOutings(outingsFour);
            _testRepo.AddOutings(outingsFive);
            _testRepo.AddOutings(outingsSix);
            _testRepo.AddOutings(outingsSeven);
            _testRepo.AddOutings(outingsEight);
        }

        [TestMethod]
        public void Test_AddOutings()
        {
            SeedOutingsList();
            bool expectedResult =false;

            OutingsContent testOuting = new OutingsContent(EventType.Concert, 9999, new DateTime(1999, 09, 09, 11, 20, 10), 999, 999999);
            _testRepo.AddOutings(testOuting);
            List<OutingsContent> testList = _testRepo.DisplayList();

            if (testList.Contains(testOuting))
            {
                expectedResult = true;
            }

            Assert.IsTrue(expectedResult);

        }

        [TestMethod]
        public void Test_CalculationsAll()
        {

            OutingsContent outingsOne = new OutingsContent(EventType.Concert, 200, new DateTime(2020, 03, 20, 11, 20, 10), 100, 1);

            _testRepo.AddOutings(outingsOne);
            int expected = 1;
            string totalString = _testRepo.CalculationsAll();
            int total = int.Parse(totalString);
            Assert.AreEqual(expected, total);

        }


        [TestMethod]
        public void Test_CalculationsOutingsGolf()
        {

            OutingsContent outingsOne = new OutingsContent(EventType.Golf, 200, new DateTime(2020, 03, 20, 11, 20, 10), 100, 1);

            _testRepo.AddOutings(outingsOne);
            int expected = 1;
            string totalString = _testRepo.CalculationsOutingsGolf();
            int total = int.Parse(totalString);
            Assert.AreEqual(expected, total);

        }

        [TestMethod]
        public void Test_CalculationsOutingsBowling()
        {
            OutingsContent outingsOne = new OutingsContent(EventType.Bowling, 200, new DateTime(2020, 03, 20, 11, 20, 10), 100, 1);

            _testRepo.AddOutings(outingsOne);
            int expected = 1;
            string totalString = _testRepo.CalculationsOutingsBowling();
            int total = int.Parse(totalString);
            Assert.AreEqual(expected, total);
        }

        [TestMethod]
        public void Test_CalculationsOutingsAmusementPark()
        {
            OutingsContent outingsOne = new OutingsContent(EventType.AmusementPark, 200, new DateTime(2020, 03, 20, 11, 20, 10), 100, 1);

            _testRepo.AddOutings(outingsOne);
            int expected = 1;
            string totalString = _testRepo.CalculationsOutingsAmusementPark();
            int total = int.Parse(totalString);
            Assert.AreEqual(expected, total);
        }

        [TestMethod]
        public void Test_CalculationsOutingsConcerts()
        {
            OutingsContent outingsOne = new OutingsContent(EventType.Concert, 200, new DateTime(2020, 03, 20, 11, 20, 10), 100, 1);

            _testRepo.AddOutings(outingsOne);
            int expected = 1;
            string totalString = _testRepo.CalculationsOutingsConcerts();
            int total = int.Parse(totalString);
            Assert.AreEqual(expected, total);
        }


    }
}
