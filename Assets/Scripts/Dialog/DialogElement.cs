using System;
using UnityEngine;

[Serializable]
public class DialogElement
{
    [SerializeField, TextArea] private string _dialogMessage;
    [SerializeField, TextArea] private string _thought;
    [SerializeField] private TextZone _thoughtText;

    private TextZone _typingZone;

    public bool IsReady => _typingZone.IsReady;

    public void Init(TextZone dialog)
    {
        _typingZone = _thought.Length > 0 ? _thoughtText : dialog;
    }
    
    public void SetTexts()
    {
        _typingZone.SetText(_thought.Length > 0 ? _thought : _dialogMessage);
    }
}