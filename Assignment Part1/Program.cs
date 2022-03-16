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
            planner.DisplayData();
            Console.ReadKey();
        }
    }
}
