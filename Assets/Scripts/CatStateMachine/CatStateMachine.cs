using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatStateMachine 
{
    private readonly Cat _cat;
    private readonly IEqualityComparer<Mood> _moodsEqualityComparer;
    private readonly IEqualityComparer<Impact> _impactsEqualityComparer;

    private readonly Dictionary<CatStateTransition, CatTransitionData> _transitions =
        new Dictionary<CatStateTransition, CatTransitionData>();

    private Mood _currentMood;
    private CatTransitionData _currentTransition;
    private float _transitionEndTime = float.MinValue;

    public CatStateMachine(Cat cat,
        IEqualityComparer<Mood> moodsEqualityComparer,
        IEqualityComparer<Impact> impactEqualityComparer)
    {
        _cat = cat;
        _moodsEqualityComparer = moodsEqualityComparer;
        _impactsEqualityComparer = impactEqualityComparer;
    }

    public void Start(Mood startMood)
    {
        _currentMood = startMood;
        _cat.ChangeMood(startMood);
    }
    public void Update()
    {
        if (_currentTransition != null && Time.time > _transitionEndTime)
        {
            StopCurrentTransition();
        }
    }

    public void NextState(Impact impact)
    {
        if (_currentTransition != null)
        {
            _currentTransition.Reaction.OnActionBeingPerformed(_cat);
            return;
        }

        var transition = new CatStateTransition(_currentMood, impact,
            _moodsEqualityComparer, _impactsEqualityComparer);


        if(!_transitions.TryGetValue(transition,out var nextState))
        {
            Debug.LogError($"There's no transition from {_currentMood} by {impact} impact");
        }

        StartTransition(nextState);
    }

    private void StartTransition(CatTransitionData transitionData)
    {
        _currentTransition = transitionData;
        _currentTransition.Reaction.OnReactionStart(_cat);
        _transitionEndTime = Time.time + transitionData.Reaction.duration;
    }

    private void StopCurrentTransition()
    {
        _currentMood = _currentTransition.DestionationMood;
        _currentTransition.Reaction.OnReactionEnd(_cat, _currentMood);
        _currentTransition = null;
    }

    public void AddTransition(Mood from, Impact by, Mood to, Reaction reaction)
    {
        var transition = new CatStateTransition(from, by, _moodsEqualityComparer, _impactsEqualityComparer);
        _transitions.Add(transition, new CatTransitionData(to, reaction));
    }

}
