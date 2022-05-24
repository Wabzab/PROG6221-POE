using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Assignment_Part1
{
    // Delegate declaration
    delegate void notifyDelegate(double i, double grossE);

    internal class BudgetPlanner
    {
        // The variables used to hold the users input while using the application
        private double monthlyIncome { get; set; } = 0;
        private double houseCost { get; set; } = 0;
        private double grossIncome { get; set; } = 0;

        // Use of generic collection Dictionary to store expense names as key with expense as value
        private IDictionary<string, double> expenseValues = new Dictionary<string, double>();

        // Instancing of necessary classes to access their methods
        HomeLoan loan = new HomeLoan();
        Utilities util = new Utilities();
        GenericExpense expense = new GenericExpense();
        PurchaseVehicle vehicleLoan = new PurchaseVehicle();

        // Method for gathering all necessary user input
        public void GetData()
        {
            // Capture standard income/expense data from user
            monthlyIncome = util.GetDouble("Please enter gross monthly income before tax >> ");
            expenseValues.Add("Tax", expense.CaptureExpense("Enter monthly tax deductions >> "));

            Console.WriteLine("Please enter the monthly expenses for the following catagories:");

            expenseValues.Add("Groceries", expense.CaptureExpense("Groceries >> "));
            expenseValues.Add("Water and Lights", expense.CaptureExpense("Water and Lights >> "));
            expenseValues.Add("Travel Costs", expense.CaptureExpense("Travel costs (including petrol) >> "));
            expenseValues.Add("Cell/Telephone", expense.CaptureExpense("Cellphone and Telephone >> "));
            expenseValues.Add("Other", expense.CaptureExpense("Other expenses >> "));

            // Ask user if they are renting or buying a house
            string choice = "none";
            bool tempBool = false;
            do
            {
                if (tempBool)
                {
                    Console.WriteLine("You need to enter 'rent' or 'buy'");
                }
                Console.Write("Will you be renting or buying housing? [rent] or [buy] >> ");
                choice = Console.ReadLine();
                tempBool = true;
            } while (choice != "rent" && choice != "buy");
            tempBool = false;

            // If user renting just capture monthly rent cost as a generic expense
            if (choice == "rent")
            {
                houseCost = expense.CaptureExpense("Please enter monthly rent cost >> ");
            }
            // Otherwise if buying capture necessary home loan info and do calculations
            else
            {
                houseCost = loan.CaptureExpense("Please enter home loan information:");
                if ((monthlyIncome / houseCost) < 3.0)
                {
                    Console.WriteLine("Approval of the home loan is unlikely, income is not sufficient.");
                } else
                {
                    Console.WriteLine("Approval of the home load in likely.");
                }
            }

            // Append the monthly expense for living space
            expenseValues.Add("Home Cost", houseCost);

            string vehicleChoice = "none";
            bool answerGiven = false;
            do
            {
                if (answerGiven)
                {
                    Console.WriteLine("You need to enter 'y' or 'n'");
                }
                Console.Write("Will you be buying a behicle? [y] or [n] >> ");
                vehicleChoice = Console.ReadLine();
                answerGiven = true;
            } while (vehicleChoice != "y" && vehicleChoice != "n");
            answerGiven = false;

            if (vehicleChoice == "y")
            {
                double vehicleCost = vehicleLoan.CaptureExpense("Enter details for vehicle financing:");
                expenseValues.Add("Vehicle Cost", vehicleCost);
            }

            

            // Calculate the gross income for the user
            grossIncome = CalculateGrossIncome(monthlyIncome, expenseValues.Values.ToList());

        }

        // Displays all necessary data with some color flare
        public void DisplayData(notifyDelegate notifyDelegate)
        {
            Console.WriteLine("==================================================\n");
            // Display the income and gross income in green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Monthly income: {0}", monthlyIncome.ToString("F"));

            // Change gross income text color to red if below zero
            if (grossIncome < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            // Format gross income to two decimal places
            Console.WriteLine("Income after expenses: {0}", grossIncome.ToString("F"));
            Console.ForegroundColor = ConsoleColor.White;

            // Notify user when expense > 75% income via a delegate
            notifyDelegate(monthlyIncome, grossIncome);

            // Display expenses in descending order
            Console.WriteLine("\nExpenses in descending order:");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            var sortedValues = from entry in expenseValues orderby entry.Value descending select entry;
            expenseValues = sortedValues.ToDictionary(x => x.Key, x => x.Value);
            for (int i = 0; i < expenseValues.Count; i++)
            {
                Console.WriteLine("{0, -30} {1}", expenseValues.ElementAt(i).Key, expenseValues.ElementAt(i).Value.ToString("F"));
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n==================================================");
        }

        // Method for calculating the gross income from all necessary data
        private double CalculateGrossIncome(double income, List<double> expenses)
        {
            // Start with monthly income
            double tempGrossIncome = income;
            // Subtract expenses from income
            foreach (double expense in expenses)
            {
                tempGrossIncome -= expense;
            }
            // Return the remainder
            return tempGrossIncome;
        }
    }
}
