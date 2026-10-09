using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        _count = 0;

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountDown(5);

        Console.WriteLine();

        GetListFromUser();

        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }


    public List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();
        string currentResponse = "";

        _count = 0;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        Console.WriteLine("Start typing your responses. Press Enter after each one.");
        Console.Write("> ");

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    if (!string.IsNullOrWhiteSpace(currentResponse))
                    {
                        responses.Add(currentResponse);
                        _count++;
                    }

                    currentResponse = "";

                    if (DateTime.Now < endTime)
                    {
                        Console.WriteLine();
                        Console.Write("> ");
                    }
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (currentResponse.Length > 0)
                    {
                        currentResponse = currentResponse.Substring(
                            0, currentResponse.Length - 1
                        );

                        Console.Write("\b \b");
                    }
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    currentResponse += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
            else
            {
                Thread.Sleep(50);
            }
        }

        if (!string.IsNullOrWhiteSpace(currentResponse))
        {
            responses.Add(currentResponse);
            _count++;
        }

        Console.WriteLine();
        return responses;
    }

}