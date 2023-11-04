public class ListingActivity : BaseActivity
{
    private string[] _prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
    };

    public ListingActivity(string description, int duration) : base(description, duration)
    {
    }

    protected override void RunActivity()
    {
        Console.Write("Prepare to begin... ");
        DisplaySpinningAnimation(4, 1000);
        Random rand = new Random();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($" --- {_prompts[rand.Next(_prompts.Length)]} ---");

        Console.WriteLine("Start listing items or press Enter to finish and exit the activity...");
        DateTime startTime = DateTime.Now;

        int itemCount = 0;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            string item = "> " + Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
                break;
            itemCount++;
            Console.Write("> ");
        }

        Console.WriteLine($"\nYou listed {itemCount} items!");
    }
}