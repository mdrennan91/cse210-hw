public class BreathingActivity : BaseActivity
{
    public BreathingActivity(string description, int duration) : base(description, duration)
    {
    }

    protected override void RunActivity()
    {
        int inhaleDuration, exhaleDuration;

        Console.Write("Enter the duration for inhales (in seconds): ");
        inhaleDuration = int.Parse(Console.ReadLine());
        Console.Write("Enter the duration for exhales (in seconds): ");
        exhaleDuration = int.Parse(Console.ReadLine());

        Console.WriteLine ("Prepare to begin... ");
        DisplaySpinningAnimation(5, 1000);

        for (int i = 0; i < _duration;)
        {
            Console.Write("Breathe in... ");
            DisplaySpinningAnimation(inhaleDuration, 1000);
            Console.WriteLine("");


            Console.Write("Breathe out... ");
            DisplaySpinningAnimation(exhaleDuration, 1000);
            Console.WriteLine("");
            Console.WriteLine("");


            i += inhaleDuration + exhaleDuration;
        }
    }
}
