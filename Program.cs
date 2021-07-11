namespace Sorbo_Assignment_5
{

    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            string result;

            do
            {
                result = DisplayMenu();
                Run(result);
            }
            while (result.ToUpper() != "E");

            Console.WriteLine(" Good Bye...");

        }
        public static string DisplayMenu()
        {

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Rob Sorbo");
            Console.WriteLine("Homework 5");
            Console.WriteLine();
            Console.WriteLine("Hit [1] to run Exercise 1.");
            Console.WriteLine("Hit [2] to run Exercise 2.");
            Console.WriteLine("Hit [3] to run Exercise 3.");
            Console.WriteLine("Hit [4] to run Exercise 4.");
            Console.WriteLine("Hit [5] to run Exercise 5.");

            Console.WriteLine();
            Console.WriteLine("Hit [E]: Exit;");
            Console.WriteLine();
            Console.WriteLine();

            var result = Console.ReadLine();
            return result;


        }
        private static bool Run(string exeArg)

        {
            switch (exeArg.ToLower())
            {

                case "1":
                    DoExe1();
                    return true;

                case "2":
                    DoExe2();
                    return true;

                case "3":
                    DoExe3();
                    return true;

                case "4":
                    DoExe4();
                    return true;

                case "5":
                    DoExe5();
                    return true;

                default:
                    Console.WriteLine("Exiting the Program!");
                    return true;
            }
        }
        private static void DoExe1()
        {
            double[] Grades = new double[8];

            int length = Grades.Length;
            string input;
            double sum = 0;
            double Avg;

            //input values into an array in a loop: https://stackoverflow.com/questions/62253620/how-do-i-store-an-input-value-in-an-array-using-foreach
            // https://www.tutorialspoint.com/csharp/csharp_arrays.htm
            for (int i = 0; i < length; i++)
            {
                Console.Write($"Please enter score for test number {i + 1}>>");
                input = Console.ReadLine();
                Grades[i] = Convert.ToInt32(input);
                sum = sum + Grades[i];
            }

            Console.WriteLine();
            Console.WriteLine("Scores for the tests are:");
            Console.WriteLine();

            //print array values https://stackoverflow.com/questions/16265247/printing-all-contents-of-array-in-c-sharp
            Avg = sum / length;
            for (int a = 0; a < length; a++)
            {
                Console.WriteLine($"Test #{a + 1}:\t {Grades[a]} From average {Grades[a] - Avg}");
            }
            Console.WriteLine();

            Console.WriteLine("Total is\t{0}\nAverage is\t{1}", sum, Avg);

        }
        private static void DoExe2()
        {

            double[] Temps = new double[5];
            string input;
            double sum = 0;
            double temp;
            bool isNumeric = false;
            bool outOfRange = false;
            int i = 0;

            while (i<Temps.Length)
            {
                Console.Write($"Enter temperature #{i + 1} \t>> ");
                input = Console.ReadLine();
                //how I figured out how to assess a numeric response: https://stackoverflow.com/questions/894263/identify-if-a-string-is-a-number
                isNumeric = int.TryParse(input, out _);
                if (!isNumeric)
                {
                    Console.WriteLine("Please enter a number between -30 and 130 degrees.");
                    continue;

                }
                temp = Convert.ToDouble(input);
                outOfRange = (temp < -30 || temp > 130);

                //making sure it is in range before I record the add the record to the array
                if (outOfRange)
                {
                    Console.WriteLine("Temperature is out of range. Please enter a temperature between -30 and 130 degrees.");
                    continue;
                }  
                Temps[i] = temp;
                sum += Temps[i];
                i++;

            }

            if (Temps[0] > Temps[1] && Temps[1] > Temps[2] && Temps[2] > Temps[3] && Temps[3] > Temps[4])
            {
                 Console.Write("Getting cooler:   ");
            }
            else if (Temps[0] < Temps[1] && Temps[1] < Temps[2] && Temps[2] < Temps[3] && Temps[3] < Temps[4])
            {
                Console.Write("Getting warmer:   ");
            }
            else Console.Write("It's a mixed bag   ");


            foreach (int a in Temps)
            {
                Console.Write($"{a.ToString()}\t");
            }

            double avg = sum / Temps.Length;
            Console.WriteLine();
            Console.WriteLine($"The average temperature is {avg}");


        }
        
        private static void DoExe3()
        {
            int Stay;
            double Price;

            Console.Write("How many nights is your stay?  ");
            Stay = Convert.ToInt32(Console.ReadLine());


            // 1-2 = $200; 3-4 = $180; 5-7 =$160; 8 or more = $145)
            if (Stay == 1 | Stay == 2) Price = 200;
            else if (Stay == 3 | Stay == 4) Price = 180;
            else if (Stay == 5 | Stay == 6 | Stay == 7) Price = 160;
            else Price = 145;

            string strPrice = Price.ToString("C");
            Console.WriteLine($"Price per night is {strPrice}");

            double Total = Price * Stay;
            string strTotal = Total.ToString("C");
            Console.WriteLine($"Total for {Stay} nights is {strTotal}");



        }
        private static void DoExe4()
        {
            int[] numbers = new int[] { 12, 15, 22, 88 };
            int x;
            double average;
            double total = 0;

            Console.Write("\nThe numbers are...");
            for (x = 0; x < numbers.Length; x++)
                Console.Write("{0, 6}", numbers[x]);
            Console.WriteLine();
            for (x = 0; x < numbers.Length; x++)
            {
                total = total + numbers[x];
            }
            average = total / numbers.Length;
            Console.WriteLine("The average is {0}", average);

        }
        private static void DoExe5()
        {
            const int QUIT = 999;
            //I changed this to a List, since the array seemed to have an indefinite length
            //This resource was helpful regarding lists: https://stackoverflow.com/questions/599369/array-of-an-unknown-length-in-c-sharp/599413


            List<int> numbers = new List<int>();
            int x = 0;
            int num = 0;
            double average;
            double total = 0;
            string inString;
         


            while (num != QUIT)
            {
                Console.Write("Please enter a number or " +
                QUIT + " to quit...");
                inString = Console.ReadLine();
                num = Convert.ToInt32(inString);

                if (num != QUIT)
                {
                    numbers.Add(num);
                    total = total + numbers[x];
                    x++;
                }
                else break;


            }
            Console.Write("The numbers are:\t");
            for (int y = 0; y < numbers.Count; y++)
                Console.Write("{0,6}", numbers[y]);
            average = total / numbers.Count;
            Console.WriteLine();
            Console.WriteLine("The average is {0}", average);


        }
    }
}



