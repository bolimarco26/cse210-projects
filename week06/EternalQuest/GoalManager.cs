
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.IO;



public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public int GetScore()
    {
        return _score;
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }


    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            return;
        }

        Goal goal = _goals[index];

        if (goal is SimpleGoal && goal.IsComplete())
        {
            return;
        }

        if (goal is ChecklistGoal checklist && checklist.IsComplete())
        {
            return;
        }

        bool wasComplete = goal.IsComplete();

        goal.RecordEvent();

        _score += goal.GetPoints();

        if (goal is ChecklistGoal checklistGoal &&
            !wasComplete && checklistGoal.IsComplete())
        {
            _score += checklistGoal.GetBonus();
        }
    }


    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            System.Console.WriteLine(
                $"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }




    public void SaveGoals(string filename)
    {
        using StreamWriter outputFile = new StreamWriter(filename);

        outputFile.WriteLine(_score);

        foreach (Goal goal in _goals)
        {
            outputFile.WriteLine(goal.GetStringRepresentation());
        }

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0 || !int.TryParse(lines[0], out int savedScore))
        {
            Console.WriteLine("Invalid save file.");
            return;
        }

        List<Goal> loadedGoals = new List<Goal>();

        try
        {
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');

                switch (parts[0])
                {
                    case "SimpleGoal":
                        {
                            if (parts.Length != 5)
                                throw new FormatException();

                            SimpleGoal goal = new SimpleGoal(
                                parts[1], parts[2],
                                int.Parse(parts[3]));

                            if (parts[4] == "1")
                                goal.RecordEvent();

                            loadedGoals.Add(goal);
                            break;
                        }

                    case "EternalGoal":
                        {
                            if (parts.Length != 4)
                                throw new FormatException();

                            loadedGoals.Add(new EternalGoal(
                                parts[1], parts[2],
                                int.Parse(parts[3])));
                            break;
                        }

                    case "ChecklistGoal":
                        {
                            if (parts.Length != 7)
                                throw new FormatException();

                            ChecklistGoal goal = new ChecklistGoal(
                                parts[1], parts[2],
                                int.Parse(parts[3]),
                                int.Parse(parts[5]),
                                int.Parse(parts[6]));

                            int completed = int.Parse(parts[4]);

                            for (int j = 0; j < completed; j++)
                            {
                                goal.RecordEvent();
                            }

                            loadedGoals.Add(goal);
                            break;
                        }

                    default:
                        throw new FormatException();
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid save file format.");
            return;
        }

        _goals = loadedGoals;
        _score = savedScore;

        Console.WriteLine("Goals loaded successfully!");
    }

}
