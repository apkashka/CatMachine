using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditorInternal;

public class CatStateTransition
{
    private readonly Mood _fromMood;
    private readonly Impact _onImpact;
    private readonly IEqualityComparer<Mood> _moodsEqualityComparer;
    private readonly IEqualityComparer<Impact> _impactsEqualityComparer;

    public CatStateTransition(Mood fromMood, Impact onImpact,
        IEqualityComparer<Mood> moodsEqualityComparer,
        IEqualityComparer<Impact> impactsEqualityComparer)
    {
        _fromMood = fromMood;
        _onImpact = onImpact;
        _moodsEqualityComparer = moodsEqualityComparer;
        _impactsEqualityComparer = impactsEqualityComparer;
    }

    public override int GetHashCode()
    {
        return 17 + 31 * _moodsEqualityComparer.GetHashCode(_fromMood)
           + 31 * _impactsEqualityComparer.GetHashCode(_onImpact);
    }
    public override bool Equals(object obj)
    {
        return obj is CatStateTransition other
            && _moodsEqualityComparer.Equals(_fromMood, other._fromMood)
            && _impactsEqualityComparer.Equals(_onImpact, other._onImpact); 
    }
}
