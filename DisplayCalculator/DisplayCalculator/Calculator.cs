using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayCalculator
{
    public class Calculator
    {
        //.NET 4.0+'s Tuple: Allow multiple return values
        public static Tuple<double, double> InputValues()
        {
            double firstValue, secondValue;

            Console.WriteLine();
            Console.WriteLine("Please input first value!");
            firstValue = Convert.ToDouble(Validator.InputValidator());

            Console.WriteLine("Please input second value!");
            secondValue = Convert.ToDouble(Validator.InputValidator());

            return Tuple.Create(firstValue, secondValue);
        }

        //Сложение
        public static void Addition()
        {
            try
            {
                var values = InputValues();
                double result = values.Item1 + values.Item2;
                Console.WriteLine("Result is: " + result);
                Console.WriteLine("---------------------------------------");

                var table = new ConsoleTable(values.Item1.ToString());
                table.AddRow(values.Item2)
                     .AddRow(result);
                table.Write(Format.AlternativeAddition);
            }
            catch (FormatException)
            {
                Console.WriteLine("You have not input value. Next time please input value if program ask you!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("You try to do something wrong! " + ex);
            }
        }

        //Вычитание
        public static void Subtraction()
        {
            try
            {
                var values = InputValues();
                double result = values.Item1 - values.Item2;
                Console.WriteLine("Result is: " + result);
                Console.WriteLine("---------------------------------------");

                var table = new ConsoleTable(values.Item1.ToString());
                table.AddRow(values.Item2)
                     .AddRow(result);
                table.Write(Format.AlternativeSubstraction);
            }
            catch (FormatException)
            {
                Console.WriteLine("You have not input value. Next time please input value if program ask you!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("You try to do something wrong! " + ex);
            }
        }

        //Умножение
        public static void Multiplication()
        {
            try
            {
                var values = InputValues();
                double result = values.Item1 * values.Item2;
                Console.WriteLine("Result is: " + result);
                Console.WriteLine("---------------------------------------");

                var table = new ConsoleTable(values.Item1.ToString());
                table.AddRow(values.Item2)
                     .AddRow(result);
                table.Write(Format.AlternativeMultiplication);
            }
            catch (FormatException)
            {
                Console.WriteLine("You have not input value. Next time please input value if program ask you!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("You try to do something wrong! " + ex);
            }
        }

        //Деление
        public static void Division()
        {
            try
            {
                var values = InputValues();
                double result;

                if (values.Item2 == 0)
                    Console.WriteLine("You try to divide by zero. It's the biggest wrong in your life. :))");
                else
                {
                    result = values.Item1 / values.Item2;
                    Console.WriteLine("Result is: " + result);
                    Console.WriteLine("---------------------------------------");

                    var table = new ConsoleTable(values.Item1.ToString());
                    table.AddRow(values.Item2)
                         .AddRow(result);
                    table.Write(Format.AlternativeDivision);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("You have not input value. Next time please input value if program ask you!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("You try to do something wrong! " + ex);
            }
        }
    }
}
