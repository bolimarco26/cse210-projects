using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "What was the best part of my day?",
            "What did I learn today?",
            "Who was the most interesting person I interacted with today?",
            "What am I grateful for today?",
            "What was the strongest emotion I felt today?"
        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }
}