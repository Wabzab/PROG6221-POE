using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Part1
{
    internal class BudgetPlanner
    {

        private double monthlyIncome { get; set; } = 0;
        private double monthlyTax { get; set; } = 0;
        private double[] monthlyExpenditures { get; set; } = new double[5];
        private double houseCost { get; set; } = 0;
        private double grossIncome { get; set; } = 0;

        HomeLoan loan = new HomeLoan();
        Utilities util = new Utilities();

        public void GetData()
        {

            monthlyIncome = util.GetDouble("Please enter gross monthly income before tax >> ");
            monthlyTax = util.GetDouble("Please enter monthly tax deductions >> ");

            Console.WriteLine("Please enter the monthly expenses for the following catagories:");
            monthlyExpenditures[0] = util.GetDouble("Groceries >> ");
            monthlyExpenditures[1] = util.GetDouble("Water and Lights >> ");
            monthlyExpenditures[2] = util.GetDouble("Travel costs (including petrol) >> ");
            monthlyExpenditures[3] = util.GetDouble("Cellphone and Telephone >> ");
            monthlyExpenditures[4] = util.GetDouble("Other expenses >> ");

            string choice = "none";
            do
            {
                Console.Write("Will you be renting or buying housing? [rent] or [buy] >> ");
                choice = Console.ReadLine();
            } while (choice != "rent" && choice != "buy");

            if (choice == "rent")
            {
                houseCost = util.GetDouble("Please enter monthly rent cost >> ");
            }
            else
            {
                houseCost = loan.CalculateHomeLoan();
                if ((monthlyIncome / houseCost) < 3)
                {
                    Console.WriteLine("Approval of the home loan is unlikely, income is not sufficient.");
                }
            }

            grossIncome = CalculateGrossIncome();

        }

        public void DisplayData()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Monthly income: {0}", monthlyIncome);
            Console.WriteLine("Income after expenses: {0}", grossIncome);
            Console.WriteLine("--------------------------------------------------");
        }

        private double CalculateGrossIncome()
        {
            double tempGrossIncome = monthlyIncome - monthlyTax - houseCost;
            foreach (var expenses in monthlyExpenditures)
            {
                tempGrossIncome -= expenses;
            }
            return tempGrossIncome;
        }
    }
}
