using System;

namespace MakeChange
{
    class Program
    {
        //Modify our Make Change program to include the following:

        //When the user has entered the purchase price, use one of the iteration statements from this chapter in order to:
        //Check to see if the purchase price is greater than zero.If it is not greater than zero,
        //then loop and have the user re-enter the purchase price
        //After the user has entered both the purchase amount and the payment amount, use one of the
        //iteration statements from this chapter in order to:

        //Check to see if the payment is enough.If it isn't enough, loop so that you ask for both
        //the purchase price and the payment again. As long as the payment isn't enough, you should
        //continue to loop and ask for the amounts again.When the payment is finally enough, you should
        //compute and print out the change as before and end.
        //Note: This will require some amount of finesse, a good understanding of loops, and some creative thinking.
        //In order to get both parts done, it will probably require one loop (purchase price > 0)  to be inside of
        //another loop (payment is enough). Also, only two loops are needed.If you have more than two loops in your
        //solution, you might want to see if you can re-work your program to get it down to only two loops.
        public static void Main(string[] args)
        {
            double purchaseAmount;
            double paymentAmount;

            do
            {
                purchaseAmount = GetAmount("Purchase Amount: ");
                paymentAmount = GetAmount("Payment Amount: ");

                while ( purchaseAmount <= 0)
                {
                    Console.WriteLine("The Purchase Amount must be greater than zero.");
                    purchaseAmount = GetAmount("Purchase Amount: ");
                    paymentAmount = GetAmount("Payment Amount: ");
                }

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


