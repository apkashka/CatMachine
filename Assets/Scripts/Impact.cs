using System.Collections.Generic;

public enum Impact
{
    Play,
    Feed,
    Stroke,
    Kick
}
public class ImpactComparer : EqualityComparer<Impact>
{
    public override bool Equals(Impact x, Impact y)
    {
        return (int)x == (int)y;
    }

    public override int GetHashCode(Impact obj)
    {
        return 17 + 31 * (int)obj;
    }
}