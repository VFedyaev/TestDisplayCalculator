using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayCalculator
{
    public class Validator
    {
        public static string InputValidator()
        {
            int X = Console.CursorLeft;
            int Y = Console.CursorTop;

            StringBuilder sb = new StringBuilder();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                char keyChar = keyInfo.KeyChar;

                switch (keyChar)
                {
                    case ',': //Запрет ввода более одной запятой
                        if ((sb.ToString().IndexOf(keyChar) < 0) && sb.Length != 0)
                            sb.Append(keyChar);
                        break;

                    case '-': //Знак минуса может быть только первый
                        if (sb.Length == 0)
                            sb.Append(keyChar);
                        break;

                    case '\b': //Посимвольное удаление
                        if (keyInfo.Key == ConsoleKey.Backspace && sb.Length != 0)
                            sb.Remove(sb.Length - 1, 1);
                        break;

                    default: //Ввод только чисел
                        if (Char.IsDigit(keyChar))
                            sb.Append(keyChar);
                        break;
                }

                Console.CursorLeft = X;
                Console.CursorTop = Y;
                Console.Write("{0} ", sb.ToString());

            } while (keyInfo.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return sb.ToString();
        }
    }
}
