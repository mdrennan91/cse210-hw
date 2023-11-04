using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Mindfulness Activity\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Exit");
            Console.Write("Select a choice from the menu: ");

            int choice = int.Parse(Console.ReadLine());

            BaseActivity activity = null;

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nWelcome to the Breathing Activity.\n");
                    Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
                    Console.Write("\nHow long, in seconds, would you like for your breathing session? ");
                    int duration = int.Parse(Console.ReadLine());
                    activity = new BreathingActivity("Breathing Activity", duration);
                    break;
                case 2:
                    Console.WriteLine("\nWelcome to the Reflection Activity.\n");
                    Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
                    Console.WriteLine("This will help you recognize the power you have and how you can use it in other aspects of your life.");
                    Console.Write("\nHow long, in seconds, would you like for your reflection session? ");
                    duration = int.Parse(Console.ReadLine());
                    activity = new ReflectionActivity("Reflection Activity", duration);
                    break;
                case 3:
                    Console.WriteLine("\nWelcome to the Listing Activity.\n");
                    Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                    Console.Write("\nHow long, in seconds, would you like for your listing session? ");
                    duration = int.Parse(Console.ReadLine());
                    activity = new ListingActivity("Listing Activity", duration);
                    break;
                case 4:
                    Console.WriteLine("Thanks for particitpating in the Mindfulness Acticity!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            activity.Start();
        }
    }
}