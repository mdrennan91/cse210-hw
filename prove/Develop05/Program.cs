using System;
class Program
{
    static void Main()
    {
        GoalManager goal = new GoalManager();

        int choice;
        do
        {
            Console.WriteLine($"\n--- You have {goal.DisplayPoints()} points ---\n");
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateNewGoal(goal);
                        break;
                    case 2:
                        goal.DisplayGoals();
                        break;
                    case 3:
                        SaveGoals(goal);
                        break;
                    case 4:
                        LoadGoals(goal);
                        break;
                    case 5:
                        goal.RecordEvent();
                        break;
                    case 6:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        } while (choice != 6);
    }

    static void CreateNewGoal(GoalManager goal)
    {
        Console.WriteLine("\nGoal Menu");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Choose a goal type: ");

        if (int.TryParse(Console.ReadLine(), out int goalType))
        {
            Console.Write("Enter the name of your goal: ");
            string name = Console.ReadLine();

            Console.Write("Enter a short description of your goal: ");
            string description = Console.ReadLine();

            Console.Write("Enter the amount of points associated with this goal: ");
            if (int.TryParse(Console.ReadLine(), out int goalPoints))
            {
                switch (goalType)
                {
                    case 1:
                        goal.AddGoal(new SimpleGoal(name, description, goalPoints));
                        break;
                    case 2:
                        goal.AddGoal(new EternalGoal(name, description, goalPoints));
                        break;
                    case 3:
                        Console.Write("Enter the number of times this goal needs to be accomplished for a bonus: ");
                        if (int.TryParse(Console.ReadLine(), out int requiredTimes))
                        {
                            Console.Write("Enter the bonus points for accomplishing the goal that many times: ");
                            if (int.TryParse(Console.ReadLine(), out int bonusPoints))
                            {
                                goal.AddGoal(new ChecklistGoal(name, description, goalPoints, requiredTimes, bonusPoints));
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for bonus points. Goal creation canceled.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for required times. Goal creation canceled.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid goal type. Goal creation canceled.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input for points. Goal creation canceled.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for goal type. Goal creation canceled.");
        }
    }

    static void SaveGoals(GoalManager user)
    {
        Console.Write("Enter the filename for the goal file: ");
        string filename = Console.ReadLine();
        user.SaveGoals(filename);
        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals(GoalManager user)
    {
        Console.Write("Enter the filename for the goal: ");
        string filename = Console.ReadLine();
        user.LoadGoals(filename);
        Console.WriteLine("Goals loaded successfully.");
    }
}