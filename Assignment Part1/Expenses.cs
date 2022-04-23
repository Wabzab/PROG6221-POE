using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Part1
{
    // Abstract class
    abstract class Expenses
    {
        // Abstract method
        public abstract double CaptureExpense(string phrase);
    }

    // HomeLoad extends abstact class Expenses
    class HomeLoan : Expenses
    {
        // Instance Utilities class to access its' methods
        Utilities util = new Utilities();

        // Implement the abstract method to capture home loan info
        public override double CaptureExpense(string phrase)
        {
            double baseValue, deposit, interest, time;

            // Capture info for home loan calculations
            Console.WriteLine(phrase);
            baseValue = util.GetDouble("Please enter base value of home >> ");
            deposit = util.GetDouble("Please enter the deposit percentage for the home loan >> ");
            interest = util.GetDouble("Please enter interest percentage for the loan >> ");
            time = util.GetDouble("Please enter number of months to pay back loan >> ");

            // Calculate the monthly pay back for a home load
            double P = baseValue - (baseValue * (deposit / 100.0));
            double i = interest / 100.0;
            double n = time / 12.0;
            double A = P * (1 + (i * n));

            double homeLoan = A / time;
            return homeLoan;
        }
    }

    class PurchaseVehicle : Expenses
    {

        Utilities util = new Utilities();

        public override double CaptureExpense(string phrase)
        {
            // Monthly repayment and premium is over 5 years
            string make, model;
            double price, deposit, interest, premium;
            double period = 60;

            Console.WriteLine(phrase);
            make = util.GetString("Enter vehicle make >> ");
            model = util.GetString("Enter vehicle model >> ");
            price = util.GetDouble("Enter vehicle price >> ");
            deposit = util.GetDouble("Enter vehicle deposit >> ");
            interest = util.GetDouble("Enter interest rate (percentage) >> ");
            premium = util.GetDouble("Enter estimated insurance premium for a 5 year policy >> ");

            double P = price - (price * (deposit / 100.0));
            double i = interest / 100.0;
            double n = period / 12;
            double A = P * (1 + (i * n));

            double vehicleLoan = A / period;
            double insurance = premium / period;

            return vehicleLoan + insurance;
        }
    }

    // GenericExpense extends Expenses
    class GenericExpense : Expenses
    {
        // Instance Utilities class to access its' methods
        Utilities util = new Utilities();

        // Implement the abstract method to capture generic expenses
        public override double CaptureExpense(string phrase)
        {
            return (double)util.GetDouble(phrase);
        }

    }
}
