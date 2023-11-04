using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
         Dragable dragable = eventData.pointerDrag.GetComponent<Dragable>();
         dragable.SetNewParent(transform);
    }
}
