using UnityEngine;
using System.Collections;

public class SetCursor : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private Ray ray;
    void SetCursorTexture(Texture2D texture)
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
    void start()
    {
        SetCursorTexture(cursorTexture);
    }

}