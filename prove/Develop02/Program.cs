using System;
using System.IO;
/* Shows creativity and exceeds core requirements:
 * If the user has no journal entries and selects #2, the program prints "No journal entries available."
 * The program allows the user to create a file to save jouurnal entries to. File will be saved in their current directory filepath.      
 * The program stores all created files in a list. When user selects "Load", the program displays the list, allowing the user to select a file from the list of files.
 * The user has the option to exit out of the list of file options if they type "0".
 * Additional journal prompts were added from the assignment example.  
 */
class Program
{
    private static List<string> savedFiles = new List<string>();
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        Console.WriteLine("\nWelcome to the Journal Program!");
        
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("Enter your response: ");
                string response = Console.ReadLine();
                DateTime theCurrentTime = DateTime.Now;
                string date = theCurrentTime.ToShortDateString();
                journal.AddEntry(new Entry(prompt, response, date));
            }

            else if (choice == "2")
            {
                journal.DisplayEntries();
            }

            else if (choice == "3")
            {
                Console.Write("Enter a filename to save the journal: ");
                string saveFilename = Console.ReadLine();

                string fullFilePath = Path.Combine(Environment.CurrentDirectory, saveFilename);
                journal.SaveToJournal(fullFilePath);

                savedFiles.Add(saveFilename);
                Console.WriteLine("Journal saved successfully.");
            }

            else if (choice == "4")
            {
                Console.Write("\nAvailable saved journal files:\n");
                for (int i = 0; i < savedFiles.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {savedFiles[i]}");
                }

                Console.Write("Enter the number of the file to load (or 0 to cancel): ");
                int fileChoice = int.Parse(Console.ReadLine());

                if (fileChoice > 0 && fileChoice <= savedFiles.Count)
                {
                    string loadFilename = savedFiles[fileChoice - 1];
                    List<Entry> loadedEntries = Journal.ReadFromJournal(loadFilename);
                    Console.WriteLine("Journal loaded successfully.");

                    foreach (var entry in loadedEntries)
                    {
                        Console.WriteLine($"Date: {entry.date}");
                        Console.WriteLine($"Prompt: {entry.prompt}");
                        Console.WriteLine($"Journal Entry: {entry.response}");
                    }
                }

                else if (fileChoice == 0)
                {
                    Console.WriteLine("Load canceled.");
                }
                
                else
                {
                    Console.WriteLine("Invalid file choice.");
                }
            }


            else if (choice == "5")
            {
                isRunning = false;
                Console.WriteLine("Thanks for journaling today. Come back tomorrow!");
            }

            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
class Entry
{
    public string prompt;
    public string response;
    public string date;

    public Entry(string userPrompt, string userResponse, string dateCreated)
    {
        prompt = userPrompt;
        response = userResponse;
        date = dateCreated;
    }
}

class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What was the best part of your day today?",
        "What was the worst part of your day today?",
        "What did you eat today?",
        "What did you accomplish today?",
        "What is something you can do to improve on tomorrow?",
        "How much sleep did you get last night?",
        "Did you do any physical activity today?",
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}

class Journal
{
    private List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries available.");
        }

        else
        {
            foreach (var entry in _entries)
            {
                Console.WriteLine($"Date: {entry.date}");
                Console.WriteLine($"Prompt: {entry.prompt}");
                Console.WriteLine($"Journal Entry: {entry.response}");
                Console.WriteLine("");
            }
        }
    }

    public void SaveToJournal(string filePath)
    {   
        Console.WriteLine($"Saving to file: {filePath}.");
        
        using (StreamWriter outputFile = new StreamWriter(filePath))
        {
            foreach (var entry in _entries)
            {
                outputFile.WriteLine($"Date: {entry.date}");
                outputFile.WriteLine($"Prompt: {entry.prompt}");
                outputFile.WriteLine($"Journal Entry: {entry.response}");
                outputFile.WriteLine("");
            }
        }
    }

    public static List<Entry> ReadFromJournal(string filename)
    {
        Console.WriteLine($"\nJournal file: {filename}");
        List<Entry> entries = new List<Entry>();
        string[] lines = System.IO.File.ReadAllLines(filename);
        
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
        
        return entries;
    }
}