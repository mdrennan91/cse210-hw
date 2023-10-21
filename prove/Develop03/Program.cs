using System;

class Program
{
    static void Main(string[] args)
    {

        Reference _reference = new Reference("John", 3, 16);
        Scripture _scripture = new Scripture(_reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        _scripture.Display();

        do
        {
            Console.WriteLine("Press Enter to continue type 'quit' to exit.");
            string input = Console.ReadLine().ToLower();
            if (input == "quit")
            {
                break;
            }
            else
            {
                _scripture.HideRandomWord();
                _scripture.Display();
                if (_scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words are hidden.");
                }
            }
        } while (!_scripture.AllWordsHidden());
    }
}