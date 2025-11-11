using System;

public class Time
{
    private byte _hours;
    private byte _minutes;

    public byte Hours
    {
        get { return _hours; }
        private set
        {
            if (value >= 0 && value < 24)
                _hours = value;
            else
                throw new ArgumentException("Часы должны быть в диапазоне 0-23");
        }
    }

    public byte Minutes
    {
        get { return _minutes; }
        private set
        {
            if (value >= 0 && value < 60)
                _minutes = value;
            else
                throw new ArgumentException("Минуты должны быть в диапазоне 0-59");
        }
    }
    public Time()
    {
        Hours = 0;
        Minutes = 0;
    }

    public Time(byte hours, byte minutes)
    {
        Hours = hours;
        Minutes = minutes;
    }
    public Time AddMinutes(uint minutesToAdd)
    {
        int totalMinutes = Hours * 60 + Minutes + (int)minutesToAdd;
        byte newHours = (byte)((totalMinutes / 60) % 24);
        byte newMinutes = (byte)(totalMinutes % 60);

        return new Time(newHours, newMinutes);
    }
    public Time SubtractMinutes(uint minutesToSubtract)
    {
        int totalMinutes = Hours * 60 + Minutes - (int)minutesToSubtract;
        while (totalMinutes < 0)
        {
            totalMinutes += 24 * 60;
        }

        byte newHours = (byte)((totalMinutes / 60) % 24);
        byte newMinutes = (byte)(totalMinutes % 60);

        return new Time(newHours, newMinutes);
    }

    public static Time operator ++(Time time)
    {
        return time.AddMinutes(1);
    }

    public static Time operator --(Time time)
    {
        return time.SubtractMinutes(1);
    }

    public static explicit operator byte(Time time)
    {
        return time.Hours;
    }

    public static implicit operator bool(Time time)
    {
        return time.Hours != 0 || time.Minutes != 0;
    }

    public static Time operator +(Time time, uint minutes)
    {
        return time.AddMinutes(minutes);
    }

    public static Time operator +(uint minutes, Time time)
    {
        return time.AddMinutes(minutes);
    }

    public static Time operator -(Time time, uint minutes)
    {
        return time.SubtractMinutes(minutes);
    }

    public static Time operator -(uint minutes, Time time)
    {
        Time tempTime = new Time(0, 0).AddMinutes(minutes);
        return tempTime.SubtractMinutes((uint)(time.Hours * 60 + time.Minutes));
    }

    public override string ToString()
    {
        return $"{Hours:D2}:{Minutes:D2}";
    }
}