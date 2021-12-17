using System;
using CalculatorLibrary;

namespace CalculatorProgram 
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Отображать заголовок как приложение консольного калькулятора C#.
            Console.WriteLine("Консольный калькулятор на C#\r");
            Console.WriteLine("------------------------\n");

            Calculator calculator = new Calculator();

            while (!endApp)
            {
                // Объявление переменных и устанавливайте их пустыми.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Попросите пользователя ввести первое число.
                Console.WriteLine("Введите первое число и нажмите Enter");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Не корректный ввод. Пожалуйста введите число: ");
                    numInput1 = Console.ReadLine();
                }

                // Попросите пользователя ввести второе число.
                Console.WriteLine("Введите второе число и нажмите Enter");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Не корректный ввод. Пожалуйста введите число: ");
                    numInput2 = Console.ReadLine();
                }

                // Попросите пользователя выбрать операцию.
                Console.WriteLine("Выберите операцию из предложенного списка:");
                Console.WriteLine("\tс - Сложение");
                Console.WriteLine("\tв - Вычитание");
                Console.WriteLine("\tу - Умножение");
                Console.WriteLine("\tд - Деление");
                Console.Write("Какое действие? ");

                string op = Console.ReadLine();

                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
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

                // Подождите, пока пользователь ответит, прежде чем закрывать.
                Console.Write("Нажмите 'н' и Enter, чтобы закрыть приложение, или нажмите любую другую клавишу и Enter, чтобы продолжить: ");
                if (Console.ReadLine() == "н") endApp = true;

                Console.WriteLine("\n"); // Удобный межстрочный интервал.
            }
            return;
        }
    }
}