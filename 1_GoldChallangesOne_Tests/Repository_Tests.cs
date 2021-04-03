using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _1_GoldChallangeOne_Repository;
using System.Collections.Generic;

namespace _1_GoldChallangesOne_Tests
{
    [TestClass]
    public class Repository_Tests
    {
        private MenuContentRepository _testRepo = new MenuContentRepository();
        [TestMethod]
        public void GetContentByNumberTest()
        {
            // Arrange
            SeedItemList();
            int correctNum = 1;
            int incorrectNum = 9;

            MenuContent correctResult, incorrectResult;

            // Act
            correctResult = _testRepo.GetItemsByNumber(correctNum);
            incorrectResult = _testRepo.GetItemsByNumber(incorrectNum);
            // Assert
            Assert.IsNotNull(correctResult);
            Assert.IsNull(incorrectResult);

           
        }

        private void SeedItemList()
        {
            MenuContent spaghetti = new MenuContent(1, "Spaghetti", "Pasta with chease, sauce and avocado", 50m, "pasta,chease,tomato,avocado");
            MenuContent hotDog = new MenuContent(2, "Hotdog", "jucy traditional hotdog", 5m, "buns, meat,sauces,");

            _testRepo.AddItemToList(hotDog);
            _testRepo.AddItemToList(spaghetti);

            MenuContent avocado = new MenuContent("smashed avocados, 200 Calories ");
            _testRepo.AddIngredientsList(avocado);
        }


        [TestMethod]
        public void AddItemToListTest()
        {
            // Arrange
            SeedItemList();
            int ItemToAdd = 2500;
            MenuContent ItemAdded;

            // Act
            ItemAdded = _testRepo.GetItemsByNumber(ItemToAdd);
            
            if(ItemAdded != null)
            {
                Assert.Fail("Item already exist");
            }
            else
            {
                _testRepo.AddItemToList(new MenuContent { MealNumber = 2500, MealName = "Chicken tenders", Description = "Chicken tenders already bought from KFC", Price = 11.50m, Ingredients = "Everything,you,can,think,of" });
            }

            ItemAdded = _testRepo.GetItemsByNumber(ItemToAdd);
            // Assert
            Assert.IsNotNull(ItemAdded);
        }

        [TestMethod]
        public void SeeMenuListTest()
        {
            // Arrange
            SeedItemList();
            List<MenuContent> listReceived;

            //Act
            listReceived = _testRepo.SeeMenuList();
            int count = listReceived.Count;


            //Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void RemoveItemFromListTest()
        {
            // Arrange
            SeedItemList();
            int realMealNum = 1;

            //Act
            MenuContent item = _testRepo.GetItemsByNumber(realMealNum);

            if (item == null)
            {
                Assert.Fail("Number does not exist in repository");
            }
            else
            {
                _testRepo.RemoveItemFromList(realMealNum);
            }

            item = _testRepo.GetItemsByNumber(realMealNum);

            // Assert
            Assert.IsNull(item);
         
        }

        [TestMethod]
        public void SeeIngredientsListTest()
        {
            
                // Arrange
                SeedItemList();
                List<MenuContent> listReceived;

                //Act
                listReceived = _testRepo.SeeIngredientsList();
                int count = listReceived.Count;


                //Assert
                Assert.AreEqual(1, count);
            

            
        }

        [TestMethod]
        public void AddIngredientsToListTest()
        {
            // Arrange
            SeedItemList();
            List<MenuContent> currentItems;
            int listCount;

            // Act
            currentItems = _testRepo.SeeIngredientsList();
            listCount = currentItems.Count;


            if (listCount != 1)
            {
                Assert.Fail("Item was not added");
            }
            else
            {
                _testRepo.AddIngredientsList(new MenuContent {Ingredients="beef sticks = 100 Calories"});
            }

            listCount = currentItems.Count;
            // Assert
            Assert.AreEqual(2, listCount);

            
        }

       
    }
}
