
using System;
using System.Globalization;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();


    public virtual string GetSummary()
    {
        CultureInfo culture = CultureInfo.GetCultureInfo("en-US");

        return $"{_date.ToString("dd MMM yyyy", culture)} " +
               $"{GetType().Name} ({_minutes} min) - " +
               $"Distance: {GetDistance().ToString("F2", culture)} km, " +
               $"Speed: {GetSpeed().ToString("F2", culture)} kph, " +
               $"Pace: {GetPace().ToString("F2", culture)} min per km";
    }


    protected int GetMinutes()
    {
        return _minutes;
    }
}
