using System;
using System.Runtime.CompilerServices;
class Program
{
    static void Main(string[] args)
    {
        DateTime today = DateTime.Now;

        Running runningActivity = new Running(today.ToString("dd MMM yyyy"), 30, 3.0);
        Cycling cyclingActivity = new Cycling(today.ToString("dd MMM yyyy"), 30, 15.0);
        Swimming swimmingActivity = new Swimming(today.ToString("dd MMM yyyy"), 30, 20);

        List<Activity> activities = new List<Activity>
        {
            runningActivity,
            cyclingActivity,
            swimmingActivity,
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}