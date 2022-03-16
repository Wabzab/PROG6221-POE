using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Assignment_Part1
{
    class Utilities
    {
        public double GetDouble(string s)
        {
            string tempString = "";
            double tempDouble = 0;
            do
            {
                Console.Write(s);
                tempString = Console.ReadLine();
            } while (!double.TryParse(tempString, NumberStyles.Any, CultureInfo.InvariantCulture, out tempDouble));
            return tempDouble;
        }
    }
}
