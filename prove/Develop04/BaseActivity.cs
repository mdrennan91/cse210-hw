using System;
using System.Collections.Generic;
using System.Threading;

public class BaseActivity
{
    private string _description;
    protected int _duration;

    public BaseActivity(string description, int duration)
    {
        _description = description;
        _duration = duration;
    }

    public void Start()
    {
        Console.WriteLine($"Description: {_description}");
        Console.WriteLine($"Duration: {_duration} seconds\n");

        RunActivity();

        Console.WriteLine("Good job! You have completed the activity.");
        Console.WriteLine($"Activity: {_description}");
        Console.WriteLine($"Duration: {_duration} seconds\n");
        DisplaySpinningAnimation(4, 1000);
    }

    protected virtual void RunActivity()
    {
    }

    protected void DisplaySpinningAnimation(int iterations, int interval)
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        int totalDuration = iterations * interval;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddMilliseconds(totalDuration);
        
        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(interval);
            Console.Write("\b \b");

            i = (i + 1) % animationStrings.Count;
        }
    }

     protected void DisplayCountDownAnimation(int numSeconds)
    {
        List<string> animationStrings = new List<string>();
        for (int i = numSeconds; i > 0; i++)
        {
            animationStrings.Add(i.ToString());
        }

        int totalDuration = numSeconds * 1000;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddMilliseconds(totalDuration);
        
        int j = 0;

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[j];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            j = (j + 1) % animationStrings.Count;
        }
    }
}