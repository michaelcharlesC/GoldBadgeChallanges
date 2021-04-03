using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_GoldChallangeOne_Repository
{
    
   
    public class MenuContent
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Ingredients { get; set; }
        

        public MenuContent() { }
        public MenuContent(int mealNumber,string mealName, string description, decimal price, string ingredients)
        {
            MealName = mealName;
            Description = description;
            Price = price;
            MealNumber = mealNumber;
            Ingredients = ingredients;
            

        }

        public MenuContent(string ingredientsInList)
        {
            Ingredients = ingredientsInList;
        }

        
    }
}
