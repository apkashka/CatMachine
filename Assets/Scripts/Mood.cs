using System.Collections;
using System.Collections.Generic;

public enum Mood
{
    Bad,
    Good,
    Excellent
}
public class MoodComparer : EqualityComparer<Mood>
{
    public override bool Equals(Mood x, Mood y)
    {
        return (int)x == (int)y;
    }

    public override int GetHashCode(Mood obj)
    {
        return 17 + 31 * (int)obj;
    }
}
