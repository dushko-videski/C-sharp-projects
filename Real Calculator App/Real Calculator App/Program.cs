using System;

namespace Real_Calculator_App
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Please enter type of arithmetic operation: + , - , * , /");
                string operant = Console.ReadLine().ToUpper();
                if (operant == "S")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thank you for using the calculator! The application will automatcally close after presssing any key!");
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
                }
                else if (operant != "+" &&
                  operant != "-" &&
                  operant != "*" &&
                  operant != "/")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid operant entered!");
                    Console.ResetColor();
                    continue;
                }

                Console.WriteLine("Enter first number!");
                string numberFirst = Console.ReadLine();
                int firstNumber;
                bool isFirstNumberConverted = int.TryParse(numberFirst, out firstNumber);

                Console.WriteLine("Enter second number!");
                string numberSecond = Console.ReadLine();
                int secondNumber;
                bool isSecondNumberConverted = int.TryParse(numberSecond, out secondNumber);


                if (!isFirstNumberConverted || !isSecondNumberConverted)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input number!");
                    Console.ResetColor();
                    continue;
                }
                else
                {
                    switch (operant)
                    {
                        case "+":
                            int sum = Sum(firstNumber, secondNumber);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"The result is {sum}");
                            Console.ResetColor();
                            break;
                        case "-":
                            if (firstNumber > secondNumber || firstNumber == secondNumber)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"The result is {Substract(firstNumber, secondNumber)}");
                                Console.ResetColor();
                            }
                            else if (firstNumber < secondNumber)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Substraction is possible only if the first number is bigger then the second number!");
                                Console.ResetColor();
                                continue;
                            }
                            break;
                        case "*":
                            int multiply = Multiply(firstNumber, secondNumber);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"The result is {multiply}");
                            Console.ResetColor();
                            break;
                        case "/":
                            if (secondNumber == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Division with 0 is not possible!");
                                Console.ResetColor();
                                continue;
                            }
                            else
                            {
                                double first = Convert.ToDouble(firstNumber);
                                double second = Convert.ToDouble(secondNumber);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"The result is {Math.Round(Divide(first, second), 2)}");
                                Console.ResetColor();
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }
        public static int Sum(int first, int second)
        {
            return first + second;
        }

        public static int Substract(int first, int second)
        {
            return first - second;
        }

        public static int Multiply(int first, int second)
        {
            return first * second;
        }

        public static double Divide(double first, double second)
        {
            return first / second;
        }

    }

}
