
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine($"Your score is {manager.GetScore()} points.");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.DisplayGoals();
                    break;
                case "3":
                    RecordEvent(manager);
                    break;

                case "4":
                    Console.Write("Enter the filename to save: ");
                    string saveFilename = Console.ReadLine() ?? "";

                    if (!string.IsNullOrWhiteSpace(saveFilename))
                    {
                        manager.SaveGoals(saveFilename);
                    }
                    else
                    {
                        Console.WriteLine("Filename cannot be empty.");
                    }
                    break;

                case "5":
                    Console.Write("Enter the filename to load: ");
                    string loadFilename = Console.ReadLine() ?? "";

                    if (!string.IsNullOrWhiteSpace(loadFilename))
                    {
                        manager.LoadGoals(loadFilename);
                    }
                    else
                    {
                        Console.WriteLine("Filename cannot be empty.");
                    }
                    break;

                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select a goal type: ");

        string type = Console.ReadLine() ?? "";

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter the description: ");
        string description = Console.ReadLine() ?? "";

        Console.Write("Enter the points: ");

        if (!int.TryParse(Console.ReadLine(), out int points) || points <= 0)
        {
            Console.WriteLine("Please enter a valid positive number.");
            return;
        }

        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, description, points));
                break;

            case "2":
                manager.AddGoal(new EternalGoal(name, description, points));
                break;

            case "3":
                Console.Write("Enter the required number of completions: ");

                if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
                {
                    Console.WriteLine("Please enter a valid positive number.");
                    return;
                }

                Console.Write("Enter the completion bonus: ");

                if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
                {
                    Console.WriteLine("Please enter a valid non-negative number.");
                    return;
                }

                manager.AddGoal(
                    new ChecklistGoal(name, description, points, target, bonus));
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        Console.WriteLine("Goal created successfully!");
    }

    static void RecordEvent(GoalManager manager)
    {
        manager.DisplayGoals();
        Console.Write("Enter the goal number to record: ");

        if (!int.TryParse(Console.ReadLine(), out int number))
        {
            Console.WriteLine("Invalid number.");
            return;
        }

        manager.RecordEvent(number - 1);
        Console.WriteLine("Event recorded.");
    }
}
