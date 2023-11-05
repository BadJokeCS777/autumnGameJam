using UnityEngine;

public class CursorSwap : MonoBehaviour
{
    [SerializeField] private Texture2D _default;
    [SerializeField] private Texture2D _click;

    private void Start()
    {
        Cursor.SetCursor(_default, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(_click, Vector2.zero, CursorMode.ForceSoftware);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(_default, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}