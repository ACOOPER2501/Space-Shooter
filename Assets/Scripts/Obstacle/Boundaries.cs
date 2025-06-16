using UnityEngine;

public class Boundaries : MonoBehaviour
{
    //float thickness = 1f; // Thickness of the borders
    //These are public as to allow for adjustments in the Unity Editor
    public float thickness = 1f;
    public float bottomOffset = 1f;  // Distance to raise the bottom border above the screen edge

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera cam = Camera.main;
        Vector2 bottomLeft = cam.ScreenToWorldPoint(Vector3.zero);
        Vector2 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        float left = bottomLeft.x;
        float right = topRight.x;
        float top = topRight.y;
        float bottom = bottomLeft.y + bottomOffset;  // Raise bottom border

        CreateCollider("Top", new Vector2((left + right) / 2, top + thickness / 2), new Vector2(right - left, thickness));
        CreateCollider("Bottom", new Vector2((left + right) / 2, bottom - thickness / 2), new Vector2(right - left, thickness));
        CreateCollider("Left", new Vector2(left - thickness / 2, (bottomLeft.y + top) / 2), new Vector2(thickness, top - bottomLeft.y));
        CreateCollider("Right", new Vector2(right + thickness / 2, (bottomLeft.y + top) / 2), new Vector2(thickness, top - bottomLeft.y));
    }

    void CreateCollider(string name, Vector2 position, Vector2 size)
    {
        GameObject border = new GameObject(name);
        border.transform.parent = transform;
        border.transform.position = position;

        var col = border.AddComponent<BoxCollider2D>();
        col.size = size;
        col.isTrigger = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
