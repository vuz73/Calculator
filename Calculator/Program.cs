using System;

namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.

            // Use a switch statement to do the math.
            switch (op)
            {
                case "с":
                    result = num1 + num2;
                    break;
                case "в":
                    result = num1 - num2;
                    break;
                case "у":
                    result = num1 * num2;
                    break;
                case "д":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Консольный калькулятор на C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declare variables and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Ask the user to type the first number.
                Console.WriteLine("Введите число и нажмите Enter");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Не корректный ввод. Пожалуйста введите число: ");
                    numInput1 = Console.ReadLine();
                }

                // Ask the user to type the second number.
                Console.WriteLine("Введите второе число и нажмите Enter");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Не корректный ввод. Пожалуйста введите число: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask the user to choose an operator.
                Console.WriteLine("Выберите операцию из предложенного списка:");
                Console.WriteLine("\tс - Сложение");
                Console.WriteLine("\tв - Вычитание");
                Console.WriteLine("\tу - Умножение");
                Console.WriteLine("\tд - Деление");
                Console.Write("Какое действие? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Эта операция приведет к математической ошибке.\n");
                    }
                    else Console.WriteLine("Ваш результат: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("О нет! При попытке выполнить математические расчеты возникло исключение.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Нажмите 'н' и Enter, чтобы закрыть приложение, или нажмите любую другую клавишу и Enter, чтобы продолжить: ");
                if (Console.ReadLine() == "н") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
    }
}