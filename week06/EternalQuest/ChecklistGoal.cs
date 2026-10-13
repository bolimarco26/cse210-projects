
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(
        string shortName,
        string description,
        int points,
        int target,
        int bonus)
        : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";

        return $"{checkbox} {GetShortName()} - {GetDescription()} " +
               $"({_amountCompleted}/{_target})";
    }


    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetBaseStringRepresentation()}|" +
               $"{_amountCompleted}|{_target}|{_bonus}";
    }




    public int GetBonus()
    {
        return _bonus;
    }
}
