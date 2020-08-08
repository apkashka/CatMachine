using UnityEditor.Compilation;
using UnityEngine;

[CreateAssetMenu]
public class Reaction : ScriptableObject
{
    public float duration;
    public string reactionTrigger;
    public string subReactionTrigger;
    public void OnReactionStart(Cat cat)
    {
        cat.StartReaction(this);
    }
    public void OnActionBeingPerformed(Cat cat)
    {
        if (subReactionTrigger != string.Empty)
        {
            cat.StartReaction(subReactionTrigger);
        }
    }
    public void OnReactionEnd(Cat cat, Mood mood)
    {
        cat.EndReaction();
        cat.ChangeMood(mood);
    }
}
