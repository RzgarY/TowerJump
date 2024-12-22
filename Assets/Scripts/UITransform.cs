using UnityEngine;

public class UITransform : MonoBehaviour
{
    public Transform player;  // Reference to the player for positioning
    private RectTransform uiTransform;
    public Vector2 offset;  // The offset to adjust UI position relative to the player

    void Start()
    {
        uiTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Position the UI element relative to the player with an offset
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(player.position);
        uiTransform.position = screenPosition + (Vector3)offset;  // Apply the offset
    }
}
