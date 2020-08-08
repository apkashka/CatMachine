using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject _buttonPref = null;
    [SerializeField] private Transform _content = null;

    public Button CreateButton()
    {
        return Instantiate(_buttonPref, _content).GetComponent<Button>();
    }
}
