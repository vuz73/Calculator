using System;
using System.IO;
using System.Diagnostics;

namespace CalculatorLibrary
{
    public class Calculator
    {
        public Calculator()
        {
            StreamWriter logFile = File.AppendText("calculator.log");
            Trace.Listeners.Add(new TextWriterTraceListener(logFile));
            Trace.AutoFlush = true;
            Trace.WriteLine("\nСтарт Calculator Log");
            Trace.WriteLine(String.Format("Начало {0}", System.DateTime.Now.ToString()));
        }
        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; /*Значение по умолчанию равно "не-число", 
                                         * если операция, такая как деление, может привести к ошибке.*/

            // Используйте оператор switch для выбора операции.
            switch (op)
            {
                case "с":
                    result = num1 + num2;
                    Trace.WriteLine(String.Format("{0} + {1} = {2}", num1, num2, result));
                    break;
                case "в":
                    result = num1 - num2;
                    Trace.WriteLine(String.Format("{0} - {1} = {2}", num1, num2, result));
                    break;
                case "у":
                    result = num1 * num2;
                    Trace.WriteLine(String.Format("{0} * {1} = {2}", num1, num2, result));
                    break;
                case "д":
                    // Попросите пользователя ввести ненулевой делитель.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        Trace.WriteLine(String.Format("{0} / {1} = {2:#.##} ", num1, num2, result));
                    }
                    break;
                // Возвращаемый текст для неправильного ввода параметра.
                default:
                    break;
            }
            return result;
        }
    }
}
