using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Part1
{
    abstract class Expenses
    {
        public abstract double CalculateHomeLoan();
    }

    class HomeLoan : Expenses
    {

        Utilities util = new Utilities();

        public override double CalculateHomeLoan()
        {
            double baseValue, deposit, interest, time;

            baseValue = util.GetDouble("Please enter base value of home >> ");
            deposit = util.GetDouble("Please enter the deposit percentage for the home loan >> ");
            interest = util.GetDouble("Please enter interest percentage for the loan >> ");
            time = util.GetDouble("Please enter number of months to pay back loan >> ");


            double P = baseValue - (baseValue * (deposit / 100.0));
            double i = interest / 100.0;
            double n = time / 12;
            double A = P * (1 + (i * n));

            double homeLoan = A / time;
            return homeLoan;
        }
    }
}
