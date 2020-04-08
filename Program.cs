using System;

//Modify our Make Change program to include the following:
//After the user has entered both the purchase amount and the payment amount. . .

//If the payment amount is not enough to cover the purchase amount, print out an error message of your
//choosing and don't calculate any change.

//If the payment amount is exactly correct(the payment is exactly equal to the purchase), then print out
//a message that indicates they gave exact change and don't calculate any change.

//If the payment amount is more than the purchase amount, then go ahead and compute the change due and
//how many of each denomination the customer should receive.

//In the part of your code where you are computing and printing out how many of each denomination the
//customer should receive, add some checks so that denominations that you don't need to give the customer
//are not printed out at all. The old program would tell the user to give the customer 0 of that denomination.
//When the customer should receive 0 of a denomination, let's just not print anything for that denomination.

namespace MakeChange
{
    class Program
    {
        public static void Main(string[] args)

        {
            double purchaseAmount = GetAmount("Purchase Amount: ");
            double paymentAmount = GetAmount("Payment Amount: ");


            if (purchaseAmount > paymentAmount)
            {
                Console.WriteLine("Cough it up buckoo!");
            }
            else if (paymentAmount == purchaseAmount)
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
            Console.Write(prompt);
            double amount = double.Parse(Console.ReadLine());
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


