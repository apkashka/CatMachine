using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    [SerializeField] private Text _debutText = null;
    [SerializeField] private Image _progressImage = null;
    [SerializeField] private Reaction _reactionBase = null;
    [SerializeField] private Image _indicator = null;

    public void Start()
    {
      StartCoroutine(ShowReaction(_reactionBase));
    }
    public void StartReaction(Reaction reaction)
    {
        StopAllCoroutines();
        StartCoroutine(ShowReaction(reaction));
    }

    public void StartReaction(string reaction)
    {
        _debutText.text = reaction;
    }

    public void EndReaction()
    {
        StopAllCoroutines();
        StartCoroutine(ShowReaction(_reactionBase));
    }


    IEnumerator ShowReaction(Reaction reaction)
    {
        _debutText.text = reaction.reactionTrigger;
        float t = 0;
        while (t < reaction.duration)
        {
            t += Time.deltaTime;
            _progressImage.fillAmount = t / reaction.duration;
            yield return null;
        }
        _progressImage.fillAmount = 1;
    }

    public void ChangeMood(Mood mood)
    { 
        switch (mood)
        {
            case Mood.Bad:
                _indicator.color = Color.red;
                break;
            case Mood.Good:
                _indicator.color = Color.yellow;
                break;
            case Mood.Excellent:
                _indicator.color = Color.green;
                break;
        }

    }
}
