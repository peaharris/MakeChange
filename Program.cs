using System;

//Prompt the user for a purchase amount
//Read in the purchase amount from the user
//Prompt the user for the payment amount
//Read in the payment amount from the user
//Compute the change due
//Print out the change due
//Print out how many $20's should be given to the customer
//Print out how many $10's should be given to the customer
//Print out how many $5's should be given to the customer
//Print out how many $1's should be given to the customer
//Print out how many $0.25's (quarters) should be given to the customer
//Print out how many $0.10's (dimes) should be given to the customer
//Print out how many $0.05's (nickels) should be given to the customer
//Print out how many $0.01's (pennies) should be given to the customer




namespace MakeChange
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Console.Write("Purchase Amount: ");
            //double purchasePrice;
            //purchasePrice = double.Parse(Console.ReadLine());
            double purchasePrice = GetPurchaseAmount();

            Console.Write("Payment Amount: ");
            double paymentAmount = double.Parse(Console.ReadLine());

            double changeDue = (paymentAmount - purchasePrice);
            Console.WriteLine($"Change Due: ${changeDue}");
            changeDue += 0.000001;

            //how many $20's should be given to the customer
            int twenties = (int) (changeDue / 20);
            Console.WriteLine($"Twenties: {twenties}");
            changeDue -= twenties * 20;

            //how many $10's should be given to the customer
            int tens = (int)(changeDue / 10);
            Console.WriteLine($"Tens: {tens}");
            changeDue -= tens * 10;

            //how many $5's should be given to the customer
            int fives = (int)(changeDue / 10);
            Console.WriteLine($"Fives: {fives}");
            changeDue = changeDue % 5;   // 8.77/5=> 1 with remainder of 3.77

            //how many $5's should be given to the customer
            int ones = (int)(changeDue / 1);
            Console.WriteLine($"Ones: {ones}");
            changeDue %= 1;   // 3.77/1=> 3 with remainder of 0.77

            //how many quarters should be given to the customer
            int quarters = (int)(changeDue / 0.25);
            Console.WriteLine($"Quarters: {quarters}");
            changeDue %= 0.25;   // 0.77/0.25=> 3 with remainder of 0.02

            //how many dimes should be given to the customer
            int dimes = (int)(changeDue / 0.10);
            Console.WriteLine($"Dimes: {dimes}");
            changeDue %= 0.10;   

            //how many nickels should be given to the customer
            int nickles = (int)(changeDue / 0.05);
            Console.WriteLine($"Nickels: {nickles}");
            changeDue %= 0.05; 

            //how many pennies should be given to the customer
            int pennies = (int)(changeDue / 0.01);
            Console.WriteLine($"Pennies: {pennies}");

        } // end Main ()

        static double GetPurchaseAmount()
        {

            Console.Write("Purchase Amount: ");
            double purchaseAmount;
            purchaseAmount = double.Parse(Console.ReadLine());
            return purchaseAmount;
        }
    }
}


