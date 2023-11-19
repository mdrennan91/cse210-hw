using System.Reflection.Metadata;

public class GoalManager
{
    private List<Goal> goals;
    private int goalPoints;

    public GoalManager()
    {
        goals = new List<Goal>();
        goalPoints = 0;
    }

    public int DisplayPoints()
    {
        int totalPoints = 0;
        foreach (var goal in goals)
        {
            totalPoints += goal.goalPoints;
        }
        return goalPoints;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordGoalProgress(int index)
    {
        if (index >= 0 && index < goals.Count)
        {
            goals[index].RecordProgress();
            goalPoints += goals[index].goalPoints;
        }
    }

    public void DisplayGoals()
    {
        if (goals.Count > 0)
        {
            for (int i = 0; i < goals.Count; i++)
            {
                string completionStatus = goals[i].IsCompleted() ? "[X]" : "[ ]";
                Console.WriteLine($"{i + 1}. {completionStatus} {goals[i].Display()}");
            }

        }
        else
        {
            Console.WriteLine("\nYour goals are: ");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(goalPoints);
            foreach (var goal in goals)
            {
                outputFile.WriteLine(goal.Save());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        goals.Clear();

        try
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length > 0 && int.TryParse(lines[0], out int loadedPoints))
            {
                goalPoints = loadedPoints;

                for (int i = 1; i < lines.Length; i++)
                {
                    Goal loadedGoal = CreateGoalFromString(lines[i]);
                    if (loadedGoal != null)
                    {
                        goals.Add(loadedGoal);
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File '{filename}' not found. No goals loaded.");
        }
    }
    public void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("You need to create goals before recording an event.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        DisplayGoals();

        Console.Write("Which goal did you accomplish? (Enter the goal number): ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex >= 1 && goalIndex <= goals.Count)
        {
            goalIndex--; 
            RecordGoalProgress(goalIndex);

            Console.WriteLine($"Congratulations! You have earned {goals[goalIndex].goalPoints} points!");
            Console.WriteLine($"You now have {DisplayPoints()} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal number. Event recording canceled.");
        }
    }

    private Goal CreateGoalFromString(string goalString)
    {
        string[] parts = goalString.Split(':');
        if (parts.Length >= 2)
        {
            string[] details = parts[1].Split(',');

            if (details.Length >= 3)
            {
                string goalType = parts[0];
                string name = details[0];
                string description = details[1];
                int goalPoints = int.Parse(details[2]);
                string isCheckedOff =  details[3];

                switch (goalType)
                {
                    case "SimpleGoal":
                        return new SimpleGoal(name, description, goalPoints, isCheckedOff);
                    case "EternalGoal":
                        return new EternalGoal(name, description, goalPoints);
                    case "ChecklistGoal":
                        int bonusPoints, completedTimes, requiredTimes;

                        if (details.Length >= 6 &&
                            int.TryParse(details[4], out bonusPoints) &&
                            int.TryParse(details[5], out completedTimes) &&
                            int.TryParse(details[6], out requiredTimes))
                        {
                            return new ChecklistGoal(name, description, goalPoints, requiredTimes, bonusPoints, completedTimes);
                        }
                        break;
                }
            }
        }

        Console.WriteLine($"Error loading goal: {goalString}");
        return null;
    }

    
}