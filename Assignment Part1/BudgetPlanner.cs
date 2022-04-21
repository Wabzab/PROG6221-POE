using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Assignment_Part1
{
    internal class BudgetPlanner
    {
        // The variables used to hold the users input while using the application
        private double monthlyIncome { get; set; } = 0;
        private double houseCost { get; set; } = 0;
        private double grossIncome { get; set; } = 0;

        // Use of an ArrayList to store expenses
        private ArrayList expenses = new ArrayList();

        // Instancing of necessary classes to access their methods
        HomeLoan loan = new HomeLoan();
        Utilities util = new Utilities();
        GenericExpense expense = new GenericExpense();

        // Method to gather all necessary user input
        public void GetData()
        {
            // Capture standard income/expense data from user
            monthlyIncome = util.GetDouble("Please enter gross monthly income before tax >> ");
            expenses.Add(expense.CaptureExpense("Please enter monthly tax deductions >> "));

            Console.WriteLine("Please enter the monthly expenses for the following catagories:");
            expenses.Add(expense.CaptureExpense("Groceries >> "));
            expenses.Add(expense.CaptureExpense("Water and Lights >> "));
            expenses.Add(expense.CaptureExpense("Travel costs (including petrol) >> "));
            expenses.Add(expense.CaptureExpense("Cellphone and Telephone >> "));
            expenses.Add(expense.CaptureExpense("Other expenses >> "));

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
                }
            }

            // Append the monthly expense for living space to expenses
            expenses.Add(houseCost);

            // Calculate the gross income for the user
            grossIncome = CalculateGrossIncome(monthlyIncome, expenses);

        }

        // Displays all necessary data with some color flare
        public void DisplayData()
        {
            Console.WriteLine("--------------------------------------------------");
            // Display the income and gross income in green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Monthly income: {0}", monthlyIncome);

            // Change gross income text color to red if below zero
            if (grossIncome < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            // Format gross income to two decimal places
            Console.WriteLine("Income after expenses: {0}", grossIncome.ToString("F"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------------------");
        }

        // Method for calculating the gross income from all necessary data
        private double CalculateGrossIncome(double income, ArrayList expenses)
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
