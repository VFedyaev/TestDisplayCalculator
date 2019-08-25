using ConsoleTables;
using System;

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

                if (values.Item1.ToString().Length >= values.Item2.ToString().Length)
                {
                    var table = new ConsoleTable(values.Item1.ToString());
                    table.AddRow(values.Item2)
                         .AddRow(result);
                    table.Write(Format.AlternativeAddition);
                }
                else
                {
                    var table = new ConsoleTable(values.Item2.ToString());
                    table.AddRow(values.Item1)
                         .AddRow(result);
                    table.Write(Format.AlternativeAddition);
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

                if (values.Item1.ToString().Length >= values.Item2.ToString().Length)
                {
                    var table = new ConsoleTable(values.Item1.ToString());
                    table.AddRow(values.Item2)
                         .AddRow(result);
                    table.Write(Format.AlternativeMultiplication);
                }
                else
                {
                    var table = new ConsoleTable(values.Item2.ToString());
                    table.AddRow(values.Item1)
                         .AddRow(result);
                    table.Write(Format.AlternativeMultiplication);
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

        //Деление
        public static void Division()
        {
            try
            {
                string showId;
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

                    Console.WriteLine("Show the Division step by step? Y/N");
                    showId = Console.ReadLine();
                    if (showId.ToUpper() == "Y")
                    {
                        Console.WriteLine();
                        DivisionByStep(values);
                    }
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

        public static void DivisionByStep(Tuple<double, double> userValues)
        {
            //P.S. Oh, I'm really sorry, for this code. Your poor eyes, yes i know what do u feel now. One more time sorry. But at this moment i can't come up with nothing better. Because i do it by my self and i have't a person to ask him mb better way. 
            try
            {
                int compFirstValue = Convert.ToInt32(userValues.Item1 * 100), compSecondValue = Convert.ToInt32(userValues.Item2 * 100);
                string answer = "";

                Console.Write(userValues.Item1 + " / " + userValues.Item2 + " = " + compFirstValue + " / " + compSecondValue);
                Console.WriteLine();

                if (Int32.TryParse(userValues.Item1.ToString(), out int number1) && Int32.TryParse(userValues.Item2.ToString(), out int number2))
                {
                    Console.WriteLine();
                    Console.WriteLine("Answer is: = " + (Convert.ToDouble(Convert.ToDouble(number1) / Convert.ToDouble(number2))));
                    Console.ReadKey();
                }
                else
                {
                    for (int j = 0; j < 7; j++)
                    {
                        int i = 1;
                        int valueOfCurrentIteration = 0, valueOfPrevIteration = 0;

                        do
                        {
                            valueOfCurrentIteration = compSecondValue * i;

                            if (valueOfCurrentIteration >= compFirstValue)
                                break;
                            else
                            {
                                valueOfPrevIteration = valueOfCurrentIteration;
                                i++;
                            }
                        } while (compFirstValue >= valueOfCurrentIteration);

                        Console.WriteLine();
                        Console.WriteLine(compSecondValue + " * " + --i + " = " + valueOfPrevIteration);
                        Console.WriteLine(compFirstValue + " - " + valueOfPrevIteration + " = " + (compFirstValue - valueOfPrevIteration));

                        compFirstValue -= valueOfPrevIteration;
                        answer += i;

                        while (compFirstValue < compSecondValue)
                        {
                            compFirstValue *= 10;
                            answer += ",";
                        };
                        j++;
                    }

                    Console.WriteLine();

                    answer = answer.Replace(",,", ",0");
                    string stringBeforeChar = answer.Substring(0, answer.IndexOf(",") + 1);
                    string stringAfterChar = answer.Substring(answer.IndexOf(",") + 1).Replace(",", "");
                    answer = stringBeforeChar + stringAfterChar;

                    Console.WriteLine("Answer is: = " + answer);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
