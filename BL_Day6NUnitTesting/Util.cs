using System;

namespace BL_Day6NUnitTesting
{
    internal class Util
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a program number to run it:\n1.Fewest notes for given amount of currency.\n2.Day of the week" +
                "\n3.Temperature conversion\n4.Monthly payment on the borrowed amount\n5.Square root of a Number\n6.Number to Binary\n7.Swap nibbles in Binary");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Util.FewestNotes();
                    break;
                case 2:
                    {
                        int d, m, y;
                        Console.WriteLine("Enter the day in the date:");
                        d = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the month in the date:");
                        m = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the year in the date:");
                        y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Day of the week: {0}", Util.DayOfTheWeek(d, m, y));
                    };
                    break;
                case 3:
                    Util.TemperatureConversion();
                    break;
                case 4:
                    {
                        Console.Write("Enter the amount of principal: ");
                        double p = Convert.ToDouble(Console.ReadLine());
                        // What exactly is the difference between Double.Parse and Convert.ToDouble

                        Console.Write("Enter the number of years for repayment: ");
                        double y = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter the rate of interest: ");
                        double r = Convert.ToDouble(Console.ReadLine());

                        Util.MonthlyPayment(p,y,r);
                    };
                    break;
                case 5:
                    Console.WriteLine("Enter a number to find it's square root");
                    double num = Convert.ToDouble(Console.ReadLine());
                    double sqrt = Util.Sqrt(num);
                    Console.WriteLine("The square root of {0} is {1}", num , sqrt);
                    break;
                case 6:
                    {
                        Console.WriteLine("Enter a number to see it's binary representation: ");
                        int number = Convert.ToInt32(Console.ReadLine());

                        string binary = Util.NumberToBinary(number);

                        Console.WriteLine("Binary representation of the number {0} is {1}", number, binary);

                        //Console.WriteLine("Binary representation of the number is {0}", binary);
                    }
                    break;
                case 7:
                    Util.SwapNibbles();
                    break;
                default:
                    Console.WriteLine("Incorrect input, program ends here");
                    break;
            }
        }
        public static void FewestNotes()

        {
            Console.WriteLine("Enter the total amount of currency: ");
            int totalAmt = Convert.ToInt32(Console.ReadLine()); // Total amount
            int amt = totalAmt;
            int totalNoOfNotes = 0;
            int[] currencyDenominatios = { 1000, 500, 100, 50, 10, 5, 2, 1 };
            Console.WriteLine("Currency denominations available are : ");
            foreach (int denomination in currencyDenominatios)
            {
                Console.Write(denomination + " ");
            }
            Console.WriteLine();
            int[] noOfNotes = new int[currencyDenominatios.Length];
            for (int i = 0; i < currencyDenominatios.Length; i++)
            {
                noOfNotes[i] = amt / (currencyDenominatios[i]);
                amt = amt % (currencyDenominatios[i]);
            }
            Console.WriteLine("To disburse minimum number of notes:");
            for (int i = 0; i < currencyDenominatios.Length; i++)
            {
                Console.WriteLine("Number of {0} Rupee notes required are {1}", currencyDenominatios[i], noOfNotes[i]);
                totalNoOfNotes += noOfNotes[i];
            }
            Console.WriteLine("Total number of notes disbursed are {0}", totalNoOfNotes);
        }

        public static int DayOfTheWeek( int d, int m, int y)
        {
            int y0 = y - (14 - m) / 12;
            int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
            int m0 = m + 12 * ((14 - m) / 12) - 2;
            int d0 = (d + x + 31 * m0 / 12) % 7;
            return d0;
        }

        public static void TemperatureConversion()
        {
            Console.WriteLine("Chose a type of conversion:\n1.Celsius to Fahrenheit:\n2.Fahrenheit to Celsius:");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {
                        double c, f; //Celsius & Farenheit
                        Console.WriteLine("Enter the temperature in Celsius (output will be in Farenheit): ");
                        c = Convert.ToDouble(Console.ReadLine());
                        f = 32 + 1.8 * c;
                        Console.WriteLine("Temperature in Farenheit is {0}", f);
                    };
                    break;
                case 2:
                    {
                        double c, f; //Celsius & Farenheit
                        Console.WriteLine("Enter the temperature in Farenheit (output will be in Celsius): ");
                        f = Convert.ToDouble(Console.ReadLine());
                        c = (f-32)*(5.0/9.0);
                        Console.WriteLine("Temperature in celsius is {0}", c);
                    };
                    break;
                default:
                    Console.WriteLine("Incorrect Input, program ends here");
                    break;
            }
        }

        public static void MonthlyPayment(double p, double y, double r)
        {
            double noOfMonths = 12 * y;
            double ratePerMonth = r / (12 * 100);
            double monthlyPayment = (p * ratePerMonth) / (1 - (Math.Pow(1 + ratePerMonth, -noOfMonths))) ;
            Console.WriteLine("Monthly payment: {0}", monthlyPayment);

        }

        public static double Sqrt(double c)
        {
            //return Math.Sqrt(num);
            if (c < 0) return double.NaN;
            double epsilon = 1e-15;
            double t = c;
            while (Math.Abs(t - c / t) > epsilon * t)
            {
                t = (c / t + t) / 2.0;
            }
            return t;
        }

        public static string NumberToBinary(int num)
        {
            int tempNum = num;

            /*if (num == 0)
            {
                return "0";
            }

            string binary = string.Empty;

            while (tempNum > 0)
            {
                int remainder = tempNum % 2;
                binary = remainder + binary;
                tempNum /= 2;
            }*/

            if (num < 0)
            {
                tempNum = -num;
            }
            string binary = "";
            while (tempNum != 0)
            {
                binary = tempNum%2 + binary;
                tempNum = tempNum/2;
            }
            if (num < 0)
            {
                binary = "-" + binary;
            }
            //Console.WriteLine("Binary representation of the number {0} is {1}", num, binary);
            return binary;

            //string binary = Convert.ToString(num, 2).PadLeft(8, '0');
        }

            public static void SwapNibbles()
            {
                Binary.SwapNibbles();
            }
    }
}