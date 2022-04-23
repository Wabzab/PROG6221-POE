using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Assignment_Part1
{
    // Where the application begins and ends
    internal class Program
    {

        // Function to be called through delegate
        static private void notify(double i, double grossE) { 
            if((grossE - i) > (i * 0.75))
            {
                Console.WriteLine("Your expenses exceeds 75% of your income.");
            }
        }

        static void Main(string[] args)
        {
            // Create instance of BudgetPlanner class
            BudgetPlanner planner = new BudgetPlanner();

            // Welcome message to start off the application
            WelcomeMessage();            

            // GetData method of the BudgetPlanner class captures all user input
            planner.GetData();
            
            // DisplayData method does as it is named, displays necessary data
            planner.DisplayData(notify);

            // Hold the application until a key is pressed by the user, then close.
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Enter any key to exit...");
            Console.ReadKey();
        }

        static void WelcomeMessage()
        {
            // Using ForegroundColor to change the text color for nice aesthetics.
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("--------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("            BUDGET PLANNER APPLICATION            ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("--------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
