using UnityEngine;

public class ClickToBookmark : MonoBehaviour
{
    // This works for VR (XR Simple Interactable calls this)
    public void OnClick()
    {
        Debug.Log($" ClickToBookmark onCLick() before toggle: ");
        Toggle();
        Debug.Log($" ClickToBookmark onCLick() after toggle: ");

    }

    // This works for Mouse Testing (No VR needed)
    private void OnMouseDown()
    {
        Toggle();
    }

    private void Toggle()
    {
        var item = GetComponent<BookmarkableItem>();
        if (BookmarkBoard.Instance != null && item != null)
        {
            Debug.Log($" ClickToBookmark Toggle() before toggle: ");
            BookmarkBoard.Instance.ToggleBookmark(item);
            Debug.Log($" ClickToBookmark Toggle() after toggle ");

        }
        else
        {
            Debug.LogError("Missing BookmarkBoard Instance or BookmarkableItem component!");
        }
    }
}