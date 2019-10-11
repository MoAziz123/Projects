using System;

namespace ConsoleApp1
{
    static class Calculator
    {
        private static int answer;

        static void Main()

        {
            Console.WriteLine("Welcome to the calculator app. Please type the 2 values to operate on");
            Console.WriteLine("Then, type the operator you wish to use.");





            while (true)
            {
                string stuf1 = Console.ReadLine(); //always need to define types for variables
                string operato1 = Console.ReadLine();
                string stuf2 = Console.ReadLine();
                int arg1 = Convert.ToInt32(stuf1);
                int arg2 = Convert.ToInt32(stuf2);

                switch (operato1) {


                    case "+":
                        {

                            Console.WriteLine(Calculator.Addition(arg1, arg2));
                            continue;
                        }

                    case "-":
                        {
                            Console.WriteLine(Calculator.Subtraction(arg1, arg2));
                            continue;
                        }
                    case "*":
                    {
                            Console.WriteLine(Calculator.Multiplication(arg1, arg2));
                            continue;
                        }
                    case "/":
                        {
                            Console.WriteLine(Calculator.Divison(arg1, arg2));
                            continue;
                        }

                    case "end":
                        {
                            break;
                        }



                }
            }

            



        }
        

        static int Addition(int arg1, int arg2)
        {
            return arg1 + arg2;
        }

        static int Subtraction(int arg1, int arg2)
        {

            return arg1 - arg2;
        }

        static int Multiplication(int arg1, int arg2)
        {

            return arg1 * arg2;
        }

        static int Divison(int arg1, int arg2)
        {

            return arg1 / arg2;
        }
    
    }
}
