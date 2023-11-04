using System;
using TMPro;
using UnityEngine;

[Serializable]
public struct ThoughtChange
{
    [SerializeField, TextArea] private string _newPhrase;
    [SerializeField] private TMP_Text _text;

    public void Change()
    {
        _text.text = _newPhrase;
    }
}