using System;
using System.Collections;
using UnityEngine;

public class ThoughtChanger : MonoBehaviour
{
    [SerializeField] private DialogPlay _dialogPlay;
    [SerializeField] private DropPlace[] _dropPlaces;
    [SerializeField] private ThoughtChange _rodomir;
    [SerializeField] private ThoughtChange _agaphia;
    [SerializeField] private TextZone _dialogText;
    [SerializeField, TextArea] private string _newDialogText1;
    [SerializeField, Min(0f)] private float _changeDelay = 2f;
    [SerializeField, Min(0f)] private float _dialogReplaceInterval = 0.5f;
    [SerializeField, Min(0f)] private float _ballsKickDelay = 0.5f;
    [SerializeField] private Animator _girlAnimator;
    [SerializeField] private Animator _boyAnimator;

    public event Action ThoughtChanged;
    
    private void Start()
    {
        _rodomir.Init();
        _agaphia.Init();
        
        foreach (DropPlace dropPlace in _dropPlaces)
            dropPlace.Dropped += DropPlaceOnDropped;
    }

    private void DropPlaceOnDropped()
    {
        foreach (DropPlace dropPlace in _dropPlaces)
            dropPlace.Dropped -= DropPlaceOnDropped;
        
        _dialogPlay.Stop();

        StartCoroutine(Changing());
    }

    private IEnumerator Changing()
    {
        _agaphia.Reset();
        yield return new WaitForSeconds(_dialogReplaceInterval);
        _dialogText.SetText("");
        yield return new WaitForSeconds(_dialogReplaceInterval);
        _agaphia.Change();
        yield return new WaitForSeconds(_changeDelay);
        _dialogText.SetText(_newDialogText1);
        yield return new WaitForSeconds(_changeDelay);

        _girlAnimator.SetTrigger("BallsKick");
        _boyAnimator.SetTrigger("BallsKick");
        yield return new WaitForSeconds(_ballsKickDelay);
        
        _rodomir.Reset();
        yield return new WaitForSeconds(_dialogReplaceInterval);
        _rodomir.Change();
        yield return new WaitForSeconds(_changeDelay);
        
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