using TMPro;
using UnityEngine;

public class ThoughtChanger : MonoBehaviour
{
    [SerializeField] private DropPlace[] _dropPlaces;
    [SerializeField] private ThoughtChange _rodomir;
    [SerializeField] private ThoughtChange _agaphia;
    [SerializeField] private TMP_Text _dialogText;
    [SerializeField, TextArea] private string _newDialogText;
 
    private void Start()
    {
        foreach (DropPlace dropPlace in _dropPlaces)
            dropPlace.Dropped += DropPlaceOnDropped;
    }

    private void DropPlaceOnDropped()
    {
        Debug.Log("dropped");
        
        foreach (DropPlace dropPlace in _dropPlaces)
            dropPlace.Dropped -= DropPlaceOnDropped;
        
        _rodomir.Change();
        _agaphia.Change();

        _dialogText.text = _newDialogText;
    }
    
    #if UNITY_EDITOR
    [ContextMenu(nameof(SetDropPlaces))]
    private void SetDropPlaces()
    {
        _dropPlaces = FindObjectsOfType<DropPlace>();
    }
    #endif
}