using System;
using System.Threading;
public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }


    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        bool breatheIn = true;

        while (DateTime.Now < endTime)
        {
            double remainingSeconds = (endTime - DateTime.Now).TotalSeconds;

            if (remainingSeconds <= 0)
            {
                break;
            }

            int pauseSeconds = Math.Min(4, (int)Math.Ceiling(remainingSeconds));

            if (breatheIn)
            {
                Console.Write("\nBreathe in... ");
            }
            else
            {
                Console.Write("\nBreathe out... ");
            }

            DateTime pauseEnd = DateTime.Now.AddSeconds(pauseSeconds);

            while (DateTime.Now < pauseEnd && DateTime.Now < endTime)
            {
                int countdown = (int)Math.Ceiling(
                    Math.Min(
                        (pauseEnd - DateTime.Now).TotalSeconds,
                        (endTime - DateTime.Now).TotalSeconds
                    )
                );

                Console.Write(countdown);
                Thread.Sleep(1000);

                Console.Write("\b \b");
            }

            breatheIn = !breatheIn;
        }

        Console.WriteLine();
        DisplayEndingMessage();
    }

}