using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

/*
 * This is a class just for general purpose functions
 * that will be used through-out the program
 */

namespace Assignment_Part1
{
    class Utilities
    {
        // A method for displaying a string s and then reading input from the user,
        // ensuring that it is of type double.
        public double GetDouble(string s)
        {
            // Temporary variables for storing in-between values
            string tempString = "";
            double tempDouble = 0;
            bool tempBool = false;
            do
            {
                if (tempBool)
                {
                    // Executed if the user enters something not valid
                    Console.WriteLine("You did not input a valid number, try again");
                }
                Console.Write(s);
                tempString = Console.ReadLine();
                tempBool = true;
                // CultureInfo parameter is to change the decimal point from ',' to '.'
            } while (!double.TryParse(tempString, NumberStyles.Any, CultureInfo.InvariantCulture, out tempDouble));
            return tempDouble;
        }
    }
}
