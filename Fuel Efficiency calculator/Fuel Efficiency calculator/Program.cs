using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuel_Efficiency_calculator {
    class Program {
        /// <summary>
        /// Calculate the fuel consumption and then return the value.
        /// </summary>
        /// <param name="fuelUsed"></param>
        /// <param name="kilometers"></param>
        /// <returns></returns>
        private static void fuelCalculator(double fuelUsed, double kilometers) {
            double lPer100, mpg, mpgConvNum = 282.4809363;

            // Calculate L/100km.
            lPer100 = fuelUsed / (kilometers / 100);

            // Convert to MPG.
            mpg = mpgConvNum / lPer100;

            // Print the calculated numbers correct to two decimals.
            Console.WriteLine("The l/100 km is: {0:F2}", lPer100);
            Console.WriteLine("The MPG is: {0:F2}", mpg);
        }

        static void Main(string[] args) {
            CalFuelComsumption();
        }

        /// <summary>
        /// Recieve and check the fuel given by the user.
        /// </summary>
        /// <returns></returns>
        public static double ChkFuel() {
            bool rightVal;
            double fuel;

            do {
                // Get the fuel level, storing as a double.
                Console.WriteLine("How much fuel was used?");
                rightVal = double.TryParse(Console.ReadLine(), out fuel);

                // Check a number is given, then check if it is within range.
                if (!rightVal) {
                    Console.WriteLine("That isn't a number, please input a number.");
                } else if (fuel < 20) {
                    Console.WriteLine("{0}L is below the minimum of 20L, please enter a value greater than 20L", fuel);
                }
            } while (!rightVal || fuel < 20);
            return fuel;
        }

        /// <summary>
        /// Recieve and check the kilometers given by the user.
        /// </summary>
        /// <param name="fuel"></param>
        /// <returns></returns>
        public static double ChkKm(double fuel) {
            double kilometer, kmMin;
            bool rightVal;

            kmMin = fuel * 8;

            do {
                // Get the number of kilometers, storing as a double.
                Console.WriteLine("How many kilometers were traveled?");
                rightVal = double.TryParse(Console.ReadLine(), out kilometer);

                // Check a number was input and that it is within range.
                if (!rightVal) {
                    Console.WriteLine("That isn't a number, please input a number.");
                } else if (kilometer < kmMin) {
                    Console.WriteLine("{0}km is below the minimum of {1}km, please enter a value greater than {1}km",
                            kilometer, kmMin);
                }
            } while (!rightVal || kilometer < kmMin);

            return kilometer;
        }

        /// <summary>
        /// Prompt the user for the fuel and kilometers until the user doesn't want to continue
        /// anymore.
        /// </summary>
        public static void CalFuelComsumption() {
            string repeat = "y";
            double fuel, kilometer;

            Console.WriteLine("Hello and welcome to the fuel efficiency converter");

            // Keep repeating the calculation till the user doesn't want to.
            while (repeat == "y") {
                fuel = ChkFuel();

                kilometer = ChkKm(fuel);

                fuelCalculator(fuel, kilometer);

                // Ask if they want to continue anymore.
                Console.WriteLine("Do you want to perform another (Y/N)?");
                repeat = Console.ReadLine().ToLower(); // Keep their input in lower case.
            }

            Console.WriteLine("Press any Key to exit");
            string key1 = Console.ReadKey().ToString(); // Exit Gracefully.
            Console.WriteLine();
            Console.WriteLine(key1);
            Console.ReadKey();
        }
    }
}
