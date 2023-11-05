using UnityEngine;

public class TutorialAnimations : MonoBehaviour
{
    [SerializeField] private ThoughtChanger _thoughtChanger;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _thoughtChanger.ThoughtChanged += OnThoughtChanged;
    }

    private void OnThoughtChanged()
    {
        _thoughtChanger.ThoughtChanged -= OnThoughtChanged;
        _animator.SetTrigger("FinishTutorial");
    }
}