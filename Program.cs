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
            decimal purchaseAmount = 1;  //Creating a purchase amount variable for item cost
            decimal paymentAmount = 0;   //Creating a payment amount variable for payment received

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
                    Console.ReadLine();

                }
                else   //When the customer paid more than the item amount, the customer need change
                {
                    Denominations(purchaseAmount, paymentAmount);  //Calculating the change and printing each denomination amount to be returned
                    Console.ReadLine();
                }
            } 

        } // end Main ()

        static decimal GetAmount(string prompt) //This prints out the prompt, retrieves the user input and turns it into a decimal
        {
            decimal amount = -1.0m;
            while (amount <= 0) 
            {
                Console.Write(prompt);
                try
                {
                    amount = decimal.Parse(Console.ReadLine());

                    if (amount < 0)   //This ensures that the user enters a postive number
                    {
                        Console.WriteLine("Please enter a POSITIVE number: ");
                    }
                }
                catch (FormatException fe)  //This ensures that the user enters a number
                {
                    Console.WriteLine(fe); 
                    Console.WriteLine("That's not a number. Please enter a number: ");
                }

            } //End of While Loop
            return amount;  //returns the amount to both purchase and payment amounts
        }

        static void Denominations(decimal purchaseAmount, decimal paymentAmount)  //this contains denominations from $20 bills down to pennies
        {
            decimal changeDue = ComputeChange(purchaseAmount, paymentAmount); //creating a variable changeDue and retrieving ComputeChange to calculate it
            double[] changeArr = { 20, 10, 5, 1, 0.25, 0.10, 0.05, 0.01 };
            while (changeDue != 0)
            {
                for(int i = 0; i <changeArr.Length; i++)
                {
                    changeDue = CalculateDenomination(changeDue, (decimal)changeArr[i], changeArr[i].ToString());
                }
                if (changeDue > 0)
                {
                    Console.WriteLine("CURRENT CHANGE " + changeDue);
                }

            }
        }

        static decimal ComputeChange(decimal purchaseAmount, decimal paymentAmount) //computes the changeDue by subtracting paymentAmount - purchaseAmount
        {
            decimal changeDue = (paymentAmount - purchaseAmount); //computes the changeDue by subtracting paymentAmount - purchaseAmount
            Console.WriteLine($"Change Due: ${changeDue}"); //Printing out the amount of change that is due
            return changeDue;                                               //fixing the changeDue precision and returning changeDue to Denominations
        }

        static decimal CalculateDenomination(decimal currentChangeDue, decimal denomination, string prompt) //calculates each denomination due 
        {
            decimal howMany = (currentChangeDue / denomination); //howMany variable determines each denomination due back to customer
            if (howMany >= 1)//if the denomination is not due back to the customer, nothing is printed, if it is, then it prints off howMany
            {
                Console.WriteLine(prompt + ": " + (int)howMany);
            }
            currentChangeDue %= denomination; //currentChange due is the remainder after removing the denomination amount returned to customer
            return currentChangeDue; //returning currentChangeDue to Denominations
        }
    }
}