using UnityEngine;

public class BookmarkableItem : MonoBehaviour
{
    [Tooltip("Unique ID (e.g., 'Engine_Cube'). MUST be unique for every object.")]
    public string uniqueID;

    [Tooltip("Drag the prefab you want to appear on the board here.")]
    public GameObject boardPrefab;

    // Helper: Auto-generate an ID if you forget
    private void OnValidate()
    {
        if (string.IsNullOrEmpty(uniqueID)) uniqueID = System.Guid.NewGuid().ToString();
    }
}