using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _3_GoldChallangesThree_Repository;
using System.Collections.Generic;

namespace _3_GoldChallangeThree_Tests
{
    [TestClass]
    public class Repository_Test
    {
        private ClaimContentRepo _testRepo = new ClaimContentRepo();
        [TestMethod]
        public void Test_CreateNewClaim()
        {
            ClaimContent testClaim = new ClaimContent();

            bool expected = _testRepo.CreateNewClaim(testClaim);

            Assert.IsTrue(expected);

            

        }

        public void SeedClaimContent()
        {
            ClaimContent firstClaim = new ClaimContent(001, ClaimType.Car, "Frontal crash, I65", 10.000m, new DateTime(2021, 03, 01, 12, 30, 20), new DateTime(2021, 03, 27, 11, 30, 20), true);
            ClaimContent secondClaim = new ClaimContent(002, ClaimType.Home, "Tornado damage", 100.000m, new DateTime(2021, 01, 10, 08, 23, 54), new DateTime(2021, 02, 02, 06, 34, 22), true);
            ClaimContent thirdClaim = new ClaimContent(003, ClaimType.Theft, "House robbery ", 3.000m, new DateTime(2020, 07, 11, 02, 04, 06), new DateTime(2020, 10, 27, 04, 20, 10), false);

            _testRepo._claimsList.Add(firstClaim);
            _testRepo._claimsList.Add(secondClaim);
            _testRepo._claimsList.Add(thirdClaim);

            _testRepo._claimsQueue.Enqueue(firstClaim);
            _testRepo._claimsQueue.Enqueue(secondClaim);
            _testRepo._claimsQueue.Enqueue(thirdClaim);

        }

        [TestMethod]
        public void Test_GetClaimList()
        {
            SeedClaimContent();
            List<ClaimContent> testList = _testRepo._claimsList;
            int listCount = testList.Count;

            Assert.AreEqual(3, listCount);

        }
    }
}
