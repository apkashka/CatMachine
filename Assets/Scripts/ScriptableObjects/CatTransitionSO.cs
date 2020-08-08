using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CatTransitionSO : ScriptableObject
{
    public Mood from;
    public Impact by;
    public Mood to;
    public Reaction reaction;
}
