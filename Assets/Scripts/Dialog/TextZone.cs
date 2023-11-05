using System.Collections;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class TextZone : MonoBehaviour
{
    private readonly Regex _nameRegex = new("\\w*:\\s");
    
    [SerializeField] private TMP_Text _text;
    [SerializeField, Range(0f, 2f)] private float _delayByCharacter;
    
    public bool IsReady { get; private set; } = false;
    
    public void SetText(string text)
    {
        if (_delayByCharacter > 0f)
        {
            StartCoroutine(Typing(text));
            return;
        }
        
        _text.text = text;
    }

    private IEnumerator Typing(string text)
    {
        string typingText = "";

        if (_nameRegex.IsMatch(text))
        {
            typingText = _nameRegex.Match(text).Value;
            text = _nameRegex.Replace(text, "");
        }
        
        foreach (char c in text)
        {
            typingText += c;
            _text.text = typingText;

            yield return new WaitForSeconds(_delayByCharacter);
        }

        IsReady = true;
    }
}