using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler
{
    public event Action Dropped;
    
    public void OnDrop(PointerEventData eventData)
    {
         Dropped?.Invoke();
    }
}
