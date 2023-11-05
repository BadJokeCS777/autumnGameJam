using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct ThoughtChange
{
    [SerializeField, TextArea] private string _newPhrase;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;
    [SerializeField] private Color _imageActiveColor;

    private Color _defaultColor;

    public void Init()
    {
        _defaultColor = _image.color;
    }

    public void Reset()
    {
        _text.text = "";
    }
    
    public void Change()
    {
        _text.text = _newPhrase;
        _image.color = _imageActiveColor;
    }

    public void Finish()
    {
        _image.color = _defaultColor;
    }
}