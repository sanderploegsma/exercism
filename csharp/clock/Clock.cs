public class Clock
{
    private const int MaxValue = 24 * 60;
    private readonly int _minutes;
    
    public Clock(int hours, int minutes)
    {
        var corrected = hours * 60 + minutes;
        while (corrected < 0)
        {
            corrected += MaxValue;
        }
        _minutes = corrected % MaxValue;
    }

    public Clock Add(int minutesToAdd) => new Clock(0, _minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => new Clock(0, _minutes - minutesToSubtract);
    
    public override string ToString()
    {
        var hours = (_minutes / 60) % 24;
        var minutes = _minutes % 60;
        return $"{hours:D2}:{minutes:D2}";
    }
    
    public override bool Equals(object obj)
    {
        if (obj is Clock other)
        {
            return _minutes == other._minutes;
        }

        return false;
    }

    public override int GetHashCode() => _minutes;
}
