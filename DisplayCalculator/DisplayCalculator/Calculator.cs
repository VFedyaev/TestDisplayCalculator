using ConsoleTables;
using System;
using System.Collections.Generic;

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

                //Check length of values. Rule of Addition in the column. On the top must be longest value.
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

                //Check length of values. Rule of Multiplication in the column. On the top must be longest value.
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

                //Check division by zero
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

                        Console.WriteLine("Show the Division in column? Y/N");
                        showId = Console.ReadLine();
                        if (showId.ToUpper() == "Y")
                        {
                            Console.Clear();
                            DivisionInColumn(values);
                        }
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

        //Пошаговый вывод деления
        public static void DivisionByStep(Tuple<double, double> userValues)
        {
            try
            {
                //Do multiplication on 100 user values.
                int compFirstValue = Convert.ToInt32(userValues.Item1 * 100), compSecondValue = Convert.ToInt32(userValues.Item2 * 100);
                string answer = "";

                Console.Write(userValues.Item1 + " / " + userValues.Item2 + " = " + compFirstValue + " / " + compSecondValue);
                Console.WriteLine();
                //Check if values is integer
                if (Int32.TryParse(userValues.Item1.ToString(), out int number1) && Int32.TryParse(userValues.Item2.ToString(), out int number2))
                {
                    Console.WriteLine();
                    Console.WriteLine("Answer is: = " + (Convert.ToDouble(Convert.ToDouble(number1) / Convert.ToDouble(number2))));
                }
                else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        int counter = 1;
                        int valueOfCurrentIteration = 0, valueOfPrevIteration = 0;

                        //Looking for the closest to divisible. The closest will be write into variable of name valueOfPrevIteration
                        do
                        {
                            valueOfCurrentIteration = compSecondValue * counter;

                            if (valueOfCurrentIteration >= compFirstValue)
                                break;
                            else
                            {
                                valueOfPrevIteration = valueOfCurrentIteration;
                                counter++;
                            }
                        } while (compFirstValue > valueOfCurrentIteration);

                        Console.WriteLine();
                        Console.WriteLine(compSecondValue + " * " + --counter + " = " + valueOfPrevIteration);
                        Console.WriteLine(compFirstValue + " - " + valueOfPrevIteration + " = " + (compFirstValue - valueOfPrevIteration));

                        compFirstValue -= valueOfPrevIteration;
                        answer += counter;

                        //Doing multipling and put comma if firstValue less than Divider
                        while (compFirstValue < compSecondValue)
                        {
                            compFirstValue *= 10;
                            answer += ",";
                        };
                    }

                    Console.WriteLine();
                    //Creating the correct answer display: Exaple 22.67 / 4.5 = 5,,3,7,7,7,
                    //22.67 / 4.5 = 5,03,7,7,7,
                    answer = answer.Replace(",,", ",0");
                    //Substring = 5,
                    string stringBeforeChar = answer.Substring(0, answer.IndexOf(",") + 1);
                    //Substring = 03,7,7,7, Replace = 03777
                    string stringAfterChar = answer.Substring(answer.IndexOf(",") + 1).Replace(",", "");
                    //22.67 / 4.5 = 5,03777,
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

        //Отображение деления в столбик
        public static void DivisionInColumn(Tuple<double, double> userValues)
        {
            //P.S. Oh, I'm really sorry, for this code. Your poor eyes, yes i know what do u feel now. One more time sorry me. But at this moment i can't come up with nothing better. Because i do it by my self and i have't a person to ask him mb better way. 
            try
            {
                //Do multiplication on 100 user values.
                int compFirstValue = Convert.ToInt32(userValues.Item1 * 100), compSecondValue = Convert.ToInt32(userValues.Item2 * 100);
                string answer = "";

                List<int> divisible = new List<int>();
                List<int> subtrahend = new List<int>();
                List<int> resFirstValueMinusPrevIter = new List<int>();

                //Check if values is integer
                if (Int32.TryParse(userValues.Item1.ToString(), out int number1) && Int32.TryParse(userValues.Item2.ToString(), out int number2))
                {
                    Console.WriteLine();
                    Console.WriteLine("  " + Convert.ToDouble(number1) + "|" + Convert.ToDouble(number2));
                    Console.WriteLine("-   |----------");
                    Console.WriteLine("  " + (Convert.ToDouble(Convert.ToDouble(number2) * Convert.ToDouble(number2))) + "|" + (Convert.ToDouble(Convert.ToDouble(number1) / Convert.ToDouble(number2))));
                    Console.WriteLine(" ----");
                    Console.WriteLine("   " + (Convert.ToDouble(Convert.ToDouble(number1) - (Convert.ToDouble(Convert.ToDouble(number2) * Convert.ToDouble(number2))))));
                }
                else
                {
                    //Looking for the closest to divisible. The closest will be write into variable of name valueOfPrevIteration
                    for (int j = 0; j < 3; j++)
                    {
                        int counter = 1;
                        int valueOfCurrentIteration = 0, valueOfPrevIteration = 0;

                        do
                        {
                            valueOfCurrentIteration = compSecondValue * counter;

                            if (valueOfCurrentIteration >= compFirstValue)
                                break;
                            else
                            {
                                valueOfPrevIteration = valueOfCurrentIteration;
                                counter++;
                            }
                        } while (compFirstValue > valueOfCurrentIteration);
                        --counter;

                        divisible.Add(compFirstValue);
                        subtrahend.Add(valueOfPrevIteration);

                        compFirstValue -= valueOfPrevIteration;
                        resFirstValueMinusPrevIter.Add(compFirstValue);

                        answer += counter;

                        //Doing multipling and put comma if firstValue less than Divider
                        while (compFirstValue < compSecondValue)
                        {
                            compFirstValue *= 10;
                            answer += ",";
                        };
                    }

                    //Creating the correct answer display: Exaple 22.67 / 4.5 = 5,,3,7,7,7,
                    //22.67 / 4.5 = 5,03,7,7,7,
                    answer = answer.Replace(",,", ",0");
                    //Substring = 5,
                    string stringBeforeChar = answer.Substring(0, answer.IndexOf(",") + 1);
                    //Substring = 03,7,7,7, Replace = 03777
                    string stringAfterChar = answer.Substring(answer.IndexOf(",") + 1).Replace(",", "");
                    //22.67 / 4.5 = 5,03777,
                    answer = stringBeforeChar + stringAfterChar;

                    Console.WriteLine("  " + divisible[0] + "|" + compSecondValue);
                    Console.WriteLine("-     |-------");
                    Console.WriteLine("  " + subtrahend[0] + "|" + answer);
                    Console.WriteLine("  ----");
                    Console.WriteLine("    " + divisible[1]);
                    Console.WriteLine("-");
                    Console.WriteLine("    " + subtrahend[1]);
                    Console.WriteLine("    ----");
                    Console.WriteLine("     " + divisible[2]);
                    Console.WriteLine("-");
                    Console.WriteLine("     " + subtrahend[2]);
                    Console.WriteLine("     ----");
                    Console.WriteLine("      " + resFirstValueMinusPrevIter[2]);
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}