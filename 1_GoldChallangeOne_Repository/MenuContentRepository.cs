using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_GoldChallangeOne_Repository
{
   public  class MenuContentRepository
    {

        List<MenuContent> _listOfItems = new List<MenuContent>();
        List<MenuContent> _listofIngredients = new List<MenuContent>();


        public void AddItemToList(MenuContent content)
        {
            _listOfItems.Add(content);
        }

        public void AddIngredientsList(MenuContent ingredients)
        {
            _listofIngredients.Add(ingredients);
        }

        public bool RemoveItemFromList(int mealNum)
        {
            MenuContent item = GetItemsByNumber(mealNum);

            if(item == null)
            {
                return true;
            }
            int initialCount = _listOfItems.Count;
            _listOfItems.Remove(item);

            if(initialCount > _listOfItems.Count)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public List<MenuContent> SeeMenuList()
        {
            return _listOfItems;
        }

        public List<MenuContent> SeeIngredientsList()
        {
            return _listofIngredients;
        }

        public MenuContent GetItemsByNumber(int itemNumber)
        {
            foreach(MenuContent item in _listOfItems)
            {
                if (item.MealNumber == itemNumber)
                {
                    return item;
                }
            }

            return null;
        }





    }
}
