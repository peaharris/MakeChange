using System;

//(20 points) Right now, the first two methods(items 1 and 2 above) don't take any parameters.
//Each one outputs a hard-coded string for its prompt, and each one returns a double. Combine
//these two methods into a single method which takes one parameter: the string to prompt the user with.
//Instead of calling the two methods in items 1 and 2, have  Main() call this new method two different times,
//with two different string prompts - once prompting for the purchase amount, and the second time prompting for the payment amount.
//Note: Leave the methods from items 1 and 2 in your code(in order to get credit for them) even though you don't call them or use
//them any more. Normally, you would remove them. However, for grading purposes, I would like you to leave them.

//(10 points) Instead of having one big long method that computes and print how many twenties, then also computes how many tens,
//then also computes how many fives(and so on) (item 3 above), write a much smaller method that takes some parameters(you decide
//what the parameters should be), computes and prints out only one of the denominations(based on the parameters), and returns
//how much money is still owed to the customer(after giving the customer that denomination). If written correctly, you should
//be able to have Main() call this method 8 different times (with parameters for the 8 different denominations). That is, Main()
//should no longer call the method that you wrote for item 3. Main() should now call this new method 8 different times with 8
//different sets of parameters.
//Note: Leave the method from item 3 in your code (in order to get credit for it) even though you don't call it or use it any more.
//Normally, you would remove it. However, for grading purposes, I would like you to leave it.


namespace MakeChange
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Sequence = I start in Main and execute statements from top to bottom, same statements in the same order
            //Conditional = I dont know in advance whether I am going to exectue a statement or not IF & SWITCH statement(Boolean logic)
            //Iteration

            GetChangeDue();

        } // end Main ()

        //(20 points) A method that a) prompts for the purchase amount, b) accepts the purchase amount,
        //c) converts the purchase amount to a double, and d) returns that double.

        static double GetPurchaseAmount()
        {
            Console.Write("Purchase Amount: ");
            double purchaseAmount = double.Parse(Console.ReadLine());
            return purchaseAmount;
        }

        //(20 points) A method that a) prompts for the payment amount, b) accepts the payment amount, c) converts
        //the payment amount to a double, and d) returns that double.

        static double GetPaymentAmount()
        {
            Console.Write("Payment Amount: ");
            double paymentAmount = double.Parse(Console.ReadLine());
            return paymentAmount;
        }

        //(30 points) A method that accepts two parameters: the purchase amount and the payment amount.
        //This method will compute the change due, print out the change due, and print out how many of
        //each denomination should be given to the customer.

        static void GetChangeDue()
        {
            double purchaseAmount = GetPurchaseAmount();
            double paymentAmount = GetPaymentAmount();
            double changeDue = (paymentAmount - purchaseAmount);
            Console.WriteLine($"Change Due: ${changeDue}");
            changeDue += 0.000001;

            //how many $20's should be given to the customer
            int twenties = (int)(changeDue / 20);
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

            //how many $1's should be given to the customer
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

        }
    }
}


