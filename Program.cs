using System;

namespace MakeChange
{
    class Program
    {
        //The is a cashier program. It asks the user for the purchase price of an item and the payment amount received from the customer.
        //It computes the change as well as the denominations needed to be returned to the customer. If a denomination is not needed,
        //it won't be printed.

        public static void Main(string[] args)
        {
            double purchaseAmount = 1;  //Creating a purchase amount variable for item cost
            double paymentAmount = 0;   //Creating a payment amount variable for payment received

            while (purchaseAmount > paymentAmount) //starting the while loop
            {
                purchaseAmount = GetAmount("Purchase Amount: "); //asking user for the purchase amount of the item
                paymentAmount = GetAmount("Payment Amount: ");  //asking user for the payment amount received 

                if (purchaseAmount > paymentAmount)  //When the customer doesn't have enough money
                {
                    Console.WriteLine("You don't have enough money! Please try again.");
                }
                else if (paymentAmount == purchaseAmount) //When the customer paid the user in exact change
                {
                    Console.WriteLine("My man! No change needed!");
                }
                else   //When the customer paid more than the item amount, the customer need change
                {
                    Denominations(purchaseAmount, paymentAmount);  //Calculating the change and printing each denomination amount to be returned
                }
            } 

        } // end Main ()

        static double GetAmount(string prompt) //This prints out the prompt, retrieves the user input and turns it into a double
        {
            double amount = -1.0;
            while (amount <= 0) 
            {
                Console.Write(prompt);
                try
                {
                    amount = double.Parse(Console.ReadLine());

                    if (amount < 0)   //This ensures that the user enters a postive number
                    {
                        Console.WriteLine("Please enter a POSITIVE number: ");
                    }
                }
                catch (FormatException fe)  //This ensures that the user enters a number
                {
                    Console.WriteLine("That's not a number. Please enter a number: ");
                }

            } //End of While Loop
            return amount;  //returns the amount to both purchase and payment amounts
        }

        static void Denominations(double purchaseAmount, double paymentAmount)  //this contains denominations from $20 bills down to pennies
        {
            double changeDue = ComputeChange(purchaseAmount, paymentAmount); //creating a variable changeDue and retrieving ComputeChange to calculate it

            double currentChangeDue = CalculateDenomination(changeDue, 20.00, "Twenties");//retrieving the $20 bills due
            currentChangeDue = CalculateDenomination(currentChangeDue, 10.00, "Tens"); //retrieving the $10 bills due
            currentChangeDue = CalculateDenomination(currentChangeDue, 5.00, "Fives"); //retrieving the $5 bills due
            currentChangeDue = CalculateDenomination(currentChangeDue, 1.00, "Ones"); //retrieving the $1 bills due
            currentChangeDue = CalculateDenomination(currentChangeDue, 0.25, "Quarters"); //retrieving the quarters due
            currentChangeDue = CalculateDenomination(currentChangeDue, 0.10, "Dimes"); //retrieving the dimes due
            currentChangeDue = CalculateDenomination(currentChangeDue, 0.05, "Nickels"); //retrieving the nickels due
            currentChangeDue = CalculateDenomination(currentChangeDue, 0.01, "Pennies"); //retrieving the pennies due
        }

        static double ComputeChange(double purchaseAmount, double paymentAmount) //computes the changeDue by subtracting paymentAmount - purchaseAmount
        {
            double changeDue = (paymentAmount - purchaseAmount); //computes the changeDue by subtracting paymentAmount - purchaseAmount
            Console.WriteLine($"Change Due: ${changeDue}"); //Printing out the amount of change that is due
            return changeDue += 0.000001;  //fixing the changeDue precision and returning changeDue to Denominations
        }

        static double CalculateDenomination(double currentChangeDue, double denomination, string prompt) //calculates each denomination due 

        {
            int howMany = (int)(currentChangeDue / denomination); //howMany variable determines each denomination due back to customer
            if (howMany != 0)//if the denomination is not due back to the customer, nothing is printed, if it is, then it prints off howMany
            {
                Console.WriteLine(prompt + ": " + howMany);
            }
            currentChangeDue %= denomination; //currentChange due is the remainder after removing the denomination amount returned to customer
            return currentChangeDue; //returning currentChangeDue to Denominations
        }
    }
}