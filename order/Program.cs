using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace order
{
    enum meal
    {
        entree = 0,
        side,
        drink,
        dessert
    }

    class Program
    {
        private static bool InvalidDishSelection;   //used to keep track of invalid dish selection for the meal

        static void Main(string[] args)
        {
            string[] input;

            //Define each meal
            dish[] morning = { new dish("eggs"), new dish("Toast"), new dish("coffee") };
            dish[] night = { new dish("steak"), new dish("potato"), new dish("Wine"), new dish("cake") };

            //Update coffee for morning and potato's for night as multiple orders by a customer are allowed
            morning[(int)meal.drink].AllowMultiple = true;
            night[(int)meal.side].AllowMultiple = true;

            bool exit = false;
            do
            {
                InvalidDishSelection = false;
                Console.Write("\nInput: ");
                input = Console.ReadLine().ToString().Split(',');   //Read customer input and parse by comma
                if (input.Length > 0)
                {
                    switch (input[0].ToUpper())
                    {
                        case "MORNING":
                            InputCustomerOrder(morning, input); //Update meal with customer order
                            Console.WriteLine("Output: " + OutputString(morning));  //get a output string from a meal
                            resetDishCount(morning);    //Make sure to reset count so all dishes will have count of 0
                            break;
                        case "NIGHT":
                            InputCustomerOrder(night, input);
                            Console.WriteLine("Output: " + OutputString(night));
                            resetDishCount(night);
                            break;
                        case "EXIT":
                            Console.WriteLine("Goodbye");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Output: Invalid dish selection. \nPlease enter MORNING or NIGHT, followed by dish selection for your order. \nThank you.");
                            break;
                    }
                }
            }
            while (!exit);
        }

        /*
         * Parse customer input and update dishes by what was ordered and count of each dish ordered.
         * Parameters:
         * dishes - list of dishes available for customer
         * inputString - Customer order
         */
        public static void InputCustomerOrder(dish[] dishes, string[] inputString)
        {
            int dishNumber;
            try
            {
                for (int i = 1; i < inputString.Length; i++)
                {
                    //if customer requests a meal that is not offered then set the invalid dish selection to true.
                    // We will use it to print out error message to customer.
                    if (int.TryParse(inputString[i], out dishNumber) == false || dishNumber > dishes.Length)
                    {
                        InvalidDishSelection = true;
                        continue;
                    }
                    dishes[dishNumber - 1].AddDish();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in InputCustomerOrder : " + ex.ToString());
                throw ex;
            }
        }

        /*
         * Spit out the output string.
         * Parameters:
         * dishes - dishes for the meal with customer input
         */
        public static string OutputString(dish[] dishes)
        {
            string returnString = string.Empty;

            try
            {
                //go through each dish, if customer ordered it and it's part of the meal then print out the dish
                foreach (dish item in dishes)
                {
                    if (item.Count != 0)
                    {
                        if (returnString.Length > 0 & item.Name.Length > 0)
                            returnString += ", ";
                        returnString += item.ToString();
                        //if the dish is invalid then set invalid dish selection to true
                        if (!item.isValid())
                        {
                            InvalidDishSelection = true;
                            break;
                        }
                    }
                }

                if (InvalidDishSelection)
                    if (returnString.Length > 0)
                        return returnString + ", error";
                    else
                        return returnString + "error";
                return returnString;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in OutputString: " + ex.ToString());
                throw ex;
            }
        }

        static void resetDishCount(dish[] dishes)
        {
            foreach (dish item in dishes)
                item.resetDishCount();
        }
    }
}
