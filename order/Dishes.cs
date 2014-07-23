/*
 * Define Dish object that can hold all the info on a dish.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace order
{
    public class dish
    {

        #region properties
        //Name of the dish
        public string Name { get; set; }
        
        //Dish Count
        public int Count { get; set; }

        //is this dish allowed to be ordered more than once by a customer
        public bool AllowMultiple { get; set; }
        #endregion

        public dish(string name)
        {
            Name = name;
            Count = 0;
            AllowMultiple = false;
        }

        //Update the count for this dish
        public void AddDish()
        {
            Count++;
        }

        public void resetDishCount()
        {
            Count = 0;
        }

        //Is this dish a valid dish.  In terms of does it have a name, 
        // if muliple orders is it allowed to be ordered multiple times?
        public Boolean isValid()
        {
            if (Name == "")
                return false;
            else if (Count > 1 & AllowMultiple == false)
                return false;
            return true;
        }

        public override string ToString()
        {
            if (Count > 1 & AllowMultiple == true)
                return Name + "(x" + Count.ToString() + ')';
            else 
                return Name;
        }
    }
}
