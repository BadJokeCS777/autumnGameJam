using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Transform _draggingParent;
    [SerializeField] private CanvasGroup _canvasGroup;

    private Vector3 _position;
    private Transform _transform;
    private Transform _parent;

    private void Awake()
    {
        _transform = transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _position = _transform.position;
        _parent = _transform.parent;
        _transform.SetParent(_draggingParent);
        
        _transform.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _transform.SetParent(_parent);
        _transform.position = _position;
        _canvasGroup.blocksRaycasts = true;

        if ( EventSystem.current.TryGetComponentInRaycasts(eventData, out DropPlace dropPlace))
        {
            dropPlace.OnDrop(eventData);
        }
    }
}