using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BookmarkBoard : MonoBehaviour
{
    public static BookmarkBoard Instance;

    [Header("Setup")]
    public Transform gridContainer;       // The Grid Layout Group
    public GameObject uiWrapperPrefab;    // The invisible UI box
    public float scaleCorrection = 250f;   // Scale multiplier for the board copy
    public float zOffset = -50f;          // How far the object floats in front of board

    // TRACKING SYSTEM: Maps ID -> The Object on the Wall
    private Dictionary<string, GameObject> activeBookmarks = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    public void ToggleBookmark(BookmarkableItem item)
    {
        if (item == null) return;

        // CHECK: Is it already on the board?
        if (activeBookmarks.ContainsKey(item.uniqueID))
        {
            // --- REMOVE ---
            GameObject objectToRemove = activeBookmarks[item.uniqueID];
            Destroy(objectToRemove); // Delete the wrapper (and the cube inside it)
            activeBookmarks.Remove(item.uniqueID); // Forget it
            Debug.Log($"Removed: {item.uniqueID}");
        }
        else
        {
            // --- ADD ---
            // 1. Create the Seat (Wrapper) in the Grid
            GameObject newWrapper = Instantiate(uiWrapperPrefab, gridContainer);

            // 2. Spawn the Copy inside the wrapper
            GameObject copy = Instantiate(item.boardPrefab, newWrapper.transform);

            // 3. Fix Position (3D inside 2D)
            copy.transform.localPosition = new Vector3(0, 0, zOffset);
            copy.transform.localRotation = Quaternion.Euler(0, 45, 0); // Nice angle
            copy.transform.localScale = Vector3.one * scaleCorrection;

            // 4. Cleanup (Remove logic from the copy so it's just visual)
            Destroy(copy.GetComponent<BookmarkableItem>());
            Destroy(copy.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRSimpleInteractable>());

            // 5. Remember it
            activeBookmarks.Add(item.uniqueID, newWrapper);
            Debug.Log($"Added: {item.uniqueID}");
        }
    }
}

