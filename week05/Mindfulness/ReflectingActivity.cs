using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you learned something important.",
            "Think of a time when you overcame a challenge."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "What did you learn from this experience?",
            "How did you feel when it was over?",
            "What made this experience difficult?",
            "How can you apply what you learned?",
            "What would you do differently next time?",
            "Who helped you during this experience?",
            "What personal strength did you discover?"
        };
    }


    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        DisplayPrompt();

        Console.WriteLine();
        Console.WriteLine("Reflect on this experience silently.");

        DisplayQuestions(endTime);

        DisplayEndingMessage();
    }


    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);

        return _questions[index];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
    }


    public void DisplayQuestions(DateTime endTime)
    {
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.WriteLine($"Question: {GetRandomQuestion()}");

            double remainingSeconds = (endTime - DateTime.Now).TotalSeconds;

            if (remainingSeconds <= 0)
            {
                break;
            }

            int pauseSeconds = Math.Min(5, (int)Math.Ceiling(remainingSeconds));

            ShowSpinner(pauseSeconds);
        }
    }

}