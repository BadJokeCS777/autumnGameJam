using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class ThoughtChanger : MonoBehaviour
{
    [SerializeField] private DialogPlay _dialogPlay;
    [SerializeField] private DropPlace[] _dropPlaces;
    [SerializeField] private ThoughtChange _rodomir;
    [SerializeField] private ThoughtChange _agaphia;
    [SerializeField] private TextZone _dialogText;
    [SerializeField, TextArea] private string _newDialogText1;
    [SerializeField, Min(0f)] private float _dialogReplaceInterval = 0.5f;
    [SerializeField, Min(0f)] private float _thoughtChangeDelay = 0.5f;
    [SerializeField, Min(0f)] private float _dialogChangeDelay = 2f;
    [SerializeField] private Animator _girlAnimator;
    [SerializeField] private Animator _boyAnimator;
    [SerializeField, Min(0f)] private float _ballsFadeDuration = 1f;
    [SerializeField] private CanvasGroup _girlBubble;

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
        yield return new WaitForSeconds(_thoughtChangeDelay);
        _agaphia.Change();
        yield return new WaitForSeconds(_dialogChangeDelay);
        _dialogText.SetText(_newDialogText1);
        yield return new WaitForSeconds(_dialogChangeDelay);

        _girlBubble.DOFade(0f, _ballsFadeDuration);
        _rodomir.Reset();

        yield return new WaitForSeconds(_ballsFadeDuration);
        
        _girlAnimator.SetTrigger("BallsKick");
        yield return new WaitForSeconds(1f);
        _boyAnimator.SetTrigger("BallsKick");
        _rodomir.Change();
        yield return new WaitForSeconds(_dialogChangeDelay);
        
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