using System;

namespace MakeChange
{
    class Program
    {
        public static void Main(string[] args)
        {
            double purchaseAmount;
            double paymentAmount;

            do
            {
                purchaseAmount = GetAmount("Purchase Amount: ");
                paymentAmount = GetAmount("Payment Amount: ");

                if (purchaseAmount > paymentAmount)
                {
                    Console.WriteLine("You don't have enough money! Please enter again.");
                }
                else if (paymentAmount == purchaseAmount)
                {
                    Console.WriteLine("My man! No change needed!");
                }
                else
                {
                    Denominations(purchaseAmount, paymentAmount);
                }
            } while (purchaseAmount > paymentAmount);

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
                }

            } //End of While Loop
            return amount;
        }

        static void Denominations(double purchaseAmount, double paymentAmount)
        {
            double changeDue = ComputeChange(purchaseAmount, paymentAmount);

            changeDue = CalculateDenomination(changeDue, 20.00, "Twenties");
            changeDue = CalculateDenomination(changeDue, 10.00, "Tens");
            changeDue = CalculateDenomination(changeDue, 5.00, "Fives");
            changeDue = CalculateDenomination(changeDue, 1.00, "Ones");
            changeDue = CalculateDenomination(changeDue, 0.25, "Quarters");
            changeDue = CalculateDenomination(changeDue, 0.10, "Dimes");
            changeDue = CalculateDenomination(changeDue, 0.05, "Nickels");
            changeDue = CalculateDenomination(changeDue, 0.01, "Pennies");
        }

        static double ComputeChange(double purchaseAmount, double paymentAmount)
        {
            double changeDue = (paymentAmount - purchaseAmount);
            Console.WriteLine($"Change Due: ${changeDue}");
            return changeDue += 0.000001;
        }

        static double CalculateDenomination(double currentChangeDue, double denomination, string prompt)

        {
            int howMany = (int)(currentChangeDue / denomination);
            if (howMany != 0)
            {
                Console.WriteLine(prompt + ": " + howMany);
            }
            currentChangeDue %= denomination;
            return currentChangeDue;
        }
    }
}