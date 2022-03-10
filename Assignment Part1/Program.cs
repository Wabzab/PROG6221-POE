using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Assignment_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BudgetPlanner planner = new BudgetPlanner();
            planner.GetData();
            Console.ReadKey();
        }
    }

    internal class BudgetPlanner
    {

        private double monthlyIncome = 0;
        private double monthlyTax = 0;
        private double[] monthlyExpenditures = new double[5];


        public void GetData()
        {

            monthlyIncome = GetDouble("Please enter gross monthly income before tax >> ");
            monthlyTax = GetDouble("Please enter monthly tax deductions >> ");

            Console.WriteLine("Please enter the monthly expenses for the following catagories:");
            monthlyExpenditures[0] = GetDouble("Groceries >> ");
            monthlyExpenditures[1] = GetDouble("Water and Lights >> ");
            monthlyExpenditures[2] = GetDouble("Travel costs (including petrol) >> ");
            monthlyExpenditures[3] = GetDouble("Cellphone and Telephone >> ");
            monthlyExpenditures[4] = GetDouble("Other expenses >> ");


        }

        private double GetDouble(string s)
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
