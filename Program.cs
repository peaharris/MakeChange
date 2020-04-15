using System;

namespace MakeChange
{
    class Program
    {
        //Modify our Make Change program to include the following:
        //Surround some of our code in a try-catch statement. Specifically, when we execute double.Parse()
        //in order to convert the string value that the user entered for one of the amounts into a numeric
        //value, that could throw an error(if we're sending non-numeric string data to double.Parse()). So
        //we want to surround that in a try-catch.
        //Again, there is some finesse required here. As long as the user keeps entering bad data, keep telling
        //the user that the data is bad and re-asking them to enter it again. This sounds like a try-catch inside
        //of a loop. One tricky part of putting a try-catch inside of a loop is paying attention to where variables
        //are declared and where those variables are in-scope and where those variables are out-of-scope.
        //Note: This kind of error checking (try-catch) might be cleverly combined with our previous error checking
        //for amounts that aren't positive.

        public static void Main(string[] args)
        {
            double purchaseAmount;
            double paymentAmount;

            do
            {
                purchaseAmount = GetAmount("Purchase Amount: ");
                paymentAmount = GetAmount("Payment Amount: ");

            } while (purchaseAmount > paymentAmount);

            if (paymentAmount == purchaseAmount)
            {
                Console.WriteLine("My man!");
            }

            else
            {
                double changeDue = ComputeChange(purchaseAmount, paymentAmount);
                int twenties = 20;
                changeDue = CalculateDenomination(changeDue, twenties, twenties, "Twenties");

                int tens = 10;
                changeDue = CalculateDenomination(changeDue, tens, tens, "Tens");

                int fives = 5;
                changeDue = CalculateDenomination(changeDue, fives, fives, "Fives");

                int ones = 1;
                changeDue = CalculateDenomination(changeDue, ones, ones, "Ones");

                double quarters = 0.25;
                changeDue = CalculateDenomination(changeDue, quarters, quarters, "Quarters");

                double dimes = 0.10;
                changeDue = CalculateDenomination(changeDue, dimes, dimes, "Dimes");

                double nickels = 0.05;
                changeDue = CalculateDenomination(changeDue, nickels, nickels, "Nickels");

                double pennies = 0.01;
                changeDue = CalculateDenomination(changeDue, pennies, pennies, "Pennies");
            }

        } // end Main ()

        static double GetAmount(string prompt)
        {
            double amount = -1.0;
            while (amount <= 0) 
            {
                Console.Write(prompt);
                try
                {
                    amount = double.Parse(Console.ReadLine());
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("That's not a number. Please enter a number: ");
                    Console.WriteLine(fe.Message);
                }

            } //End of While Loop
            return amount;
        }

        static double ComputeChange(double purchaseAmount, double paymentAmount)
        {
            double changeDue = (paymentAmount - purchaseAmount);
            Console.WriteLine($"Change Due: ${changeDue}");
            return changeDue += 0.000001;
        }

        static double CalculateDenomination(double currentChangeDue, double denomination, double value, string prompt)

        {
            denomination = (int)(currentChangeDue / denomination);
            if (denomination == 0)
            {

            }
            else
            {
                Console.WriteLine(prompt + ": " + denomination);
            }
            currentChangeDue %= value;
            return currentChangeDue;
        }
    }
}


