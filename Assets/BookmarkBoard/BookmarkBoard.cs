using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BookmarkBoard : MonoBehaviour
{
    public static BookmarkBoard Instance;

    [Header("Setup")]
    public Transform gridContainer;       // The Grid Layout Group
    public GameObject uiWrapperPrefab;    // The invisible UI box
    public float zOffset = -50f;          // How far the object floats in front of board

    // TRACKING SYSTEM
    private Dictionary<string, GameObject> activeBookmarks = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
        Debug.Log($" BookmarkBoard awake: ");
    }

    public void ToggleBookmark(BookmarkableItem item)
    {
        if (item == null) return;

        // CHECK: Is it already on the board?
        if (activeBookmarks.ContainsKey(item.uniqueID))
        {
            // --- REMOVE ---
            Debug.Log($"BookmarkBoard ToggleBookmark() before remove: {item.uniqueID}");

            GameObject objectToRemove = activeBookmarks[item.uniqueID];
            Destroy(objectToRemove);
            activeBookmarks.Remove(item.uniqueID);
            Debug.Log($"Removed: {item.uniqueID}");
        }
        else
        {
            // --- ADD ---
            // 1. Create the Seat (Wrapper)
            GameObject newWrapper = Instantiate(uiWrapperPrefab, gridContainer);
            Debug.Log($" ADD 1.");

            // 2. Spawn the Copy
            GameObject copy = Instantiate(item.boardPrefab, newWrapper.transform);
            Debug.Log($" ADD 2.");

            // 3. Fix Position & Scale
            // *** THE FIX IS HERE (Added 'f') ***
            copy.transform.localScale = new Vector3(7, 10, 0.2f);
            copy.transform.localPosition = new Vector3(0, 0, zOffset);
            Debug.Log($" ADD 3.");

            // 4. Cleanup 
            Destroy(copy.GetComponent<BookmarkableItem>());
            Destroy(copy.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRSimpleInteractable>());
            Debug.Log($" ADD 4.");

            // 5. Remember it
            activeBookmarks.Add(item.uniqueID, newWrapper);
            Debug.Log($"Added: {item.uniqueID}");
        }
    }
}