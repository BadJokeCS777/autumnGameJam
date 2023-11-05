using UnityEngine;

public class DialogPlay : MonoBehaviour
{
    [SerializeField] private TextZone _dialogTextZone;
    [SerializeField] private DialogElement[] _elements;

    private bool _active = false;
    private int _index = -1;

    private void Update()
    {
        if (_active == false)
            return;

        if (_index >= _elements.Length - 1)
            return;
        
        if (_elements[_index].IsReady == false)
            return;
        
        if (Input.GetMouseButtonDown(0))
            PlayDialogElement();
    }

    public void Init()
    {
        foreach (DialogElement element in _elements)
            element.Init(_dialogTextZone);
    }
    
    public void Begin()
    {
        _active = true;
        PlayDialogElement();
    }

    public void Stop()
    {
        _active = false;
    }

    private void PlayDialogElement()
    {
        if (_elements.Length == 0)
            return;
        
        _elements[++_index].SetTexts();

        if (_index >= _elements.Length - 1)
            Stop();
    }
}