using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private DialogPlay _dialogPlay;

    private void Start()
    {
        _dialogPlay.Init();
        _dialogPlay.Begin();
    }
}
