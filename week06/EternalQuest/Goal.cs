
public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} - {_description}";
    }

    public abstract string GetStringRepresentation();

    protected string GetBaseStringRepresentation()
    {
        return $"{_shortName}|{_description}|{_points}";
    }

    public int GetPoints()
    {
        return _points;
    }

    protected string GetShortName()
    {
        return _shortName;
    }

    protected string GetDescription()
    {
        return _description;
    }
}

