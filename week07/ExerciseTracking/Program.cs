
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running = new Running(
            new DateTime(2026, 11, 3), 30, 4.8);

        Cycling cycling = new Cycling(
            new DateTime(2026, 11, 3), 30, 20);

        Swimming swimming = new Swimming(
            new DateTime(2026, 11, 3), 30, 40);

        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
