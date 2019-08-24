using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string menuId, continueId;

                do
                {
                    Console.WriteLine("Main Menu: Please choose the operator!");
                    Console.WriteLine("+");
                    Console.WriteLine("-");
                    Console.WriteLine("*");
                    Console.WriteLine("/");
                    Console.WriteLine("---------------------------------------");
                    Console.Write("Choose and press Enter: ");
                    menuId = Console.ReadLine();
                    switch (menuId)
                    {
                        case "+":
                            Console.WriteLine("You have choose operator of Additing " + "'" + menuId + "'");
                            Calculator.Addition();
                            break;
                        case "-":
                            Console.WriteLine("You have choose operator of Subtracting " + "'" + menuId + "'");
                            Calculator.Subtraction();
                            break;
                        case "*":
                            Console.WriteLine("You have choose operator of Multiplying " + "'" + menuId + "'");
                            Calculator.Multiplication();
                            break;
                        case "/":
                            Console.WriteLine("You have choose operator of Divisioning " + "'" + menuId + "'");
                            Calculator.Division();
                            break;
                        default:
                            Console.WriteLine("You try to choose nonexist operator or doing something wrong.");
                            break;
                    }

                    Console.WriteLine("Do you want to continue? Y(press Enter)/N");
                    continueId = Console.ReadLine();
                    Console.Clear();

                } while (continueId.ToUpper() != "N");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wrong! " + ex);
                Console.ReadKey();
            }
        }
    }
}
