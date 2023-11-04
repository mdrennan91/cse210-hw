public class ReflectionActivity : BaseActivity
{
    private string[] _prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] _questions = {
        "Why was this experience meaningful to you? ",
        "Have you ever done anything like this before? ",
        "How did you get started? ",
        "How did you feel when it was complete? ",
        "What made this time different than other times when you were not as successful? ",
        "What is your favorite thing about this experience? ",
        "What could you learn from this experience that applies to other situations? ",
        "What did you learn about yourself through this experience? ",
        "How can you keep this experience in mind in the future? "
    };

    public ReflectionActivity(string description, int duration) : base(description, duration)
    {
    }

    protected override void RunActivity()
    {
        Random rand = new Random();
        Console.WriteLine("Consider the following prompt:");

        int reflectionDuration = 10;
        int questionsCount = (_duration -5) / reflectionDuration;
        
        for (int i = 0; i < questionsCount; i++)
        {
            string prompt = _prompts[rand.Next(_prompts.Length)];
            Console.WriteLine($" --- {prompt} ---");
            
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();
            
            Console.WriteLine("Now ponder each of the following questions as they relate to this experience.");
            Console.WriteLine ("Prepare to begin... ");
            DisplaySpinningAnimation(5, 1000);
            
            int remainingTime = (_duration - 5) - i * 10;
            
            for (int j = 0; j < _questions.Length; j++)
            {
                if (remainingTime < 10)
                {
                    break;
                }

                Console.Write($" > {_questions[j]}");
                DisplaySpinningAnimation(10, 1000);
                Console.WriteLine();

                remainingTime -= 10;
            }
        }
    }
}