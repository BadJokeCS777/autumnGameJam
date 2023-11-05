using System;
using TMPro;
using UnityEngine;

public class ThoughtChanger : MonoBehaviour
{
    [SerializeField] private DialogPlay _dialogPlay;
    
    [SerializeField] private DropPlace[] _dropPlaces;
    [SerializeField] private ThoughtChange _rodomir;
    [SerializeField] private ThoughtChange _agaphia;
    [SerializeField] private TMP_Text _dialogText;
    [SerializeField, TextArea] private string _newDialogText;

    public event Action ThoughtChanged;
    
    private void Start()
    {
        foreach (DropPlace dropPlace in _dropPlaces)
            dropPlace.Dropped += DropPlaceOnDropped;
    }

    private void DropPlaceOnDropped()
    {
        foreach (DropPlace dropPlace in _dropPlaces)
            dropPlace.Dropped -= DropPlaceOnDropped;
        
        _dialogPlay.Stop();
        
        _rodomir.Change();
        _agaphia.Change();

        _dialogText.text = _newDialogText;
        
        ThoughtChanged?.Invoke();
    }
    
    #if UNITY_EDITOR
    [ContextMenu(nameof(SetDropPlaces))]
    private void SetDropPlaces()
    {
        _dropPlaces = FindObjectsOfType<DropPlace>();
    }
    #endif
}