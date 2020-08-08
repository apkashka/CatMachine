using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CatTransitionSO[] _transitions = null;
    [SerializeField] private Cat _cat = null;
    [SerializeField] private InputManager _input=null;

    private CatStateMachine _stateMachine = null;
    
    void Start()
    {
        var moodEqualityComparer = new MoodComparer();
        var impactEqualityComparer = new ImpactComparer();
        
        _stateMachine = new CatStateMachine(_cat, moodEqualityComparer, impactEqualityComparer);
        foreach (var item in _transitions)
        {
            _stateMachine.AddTransition(item.from, item.by, item.to, item.reaction);
        }
        _stateMachine.Start(Mood.Good);

        CreateInputs();
    }

    void Update()
    {
        _stateMachine.Update();
    }

    private void CreateInputs()
    {
        foreach (Impact item in Enum.GetValues(typeof(Impact)))
        {
            var button = _input.CreateButton();
            button.name = item.ToString();
            button.GetComponentInChildren<Text>().text = item.ToString();
            button.onClick.AddListener(()=>_stateMachine.NextState(item));
        }
    }
}
