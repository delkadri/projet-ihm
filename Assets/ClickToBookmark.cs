using UnityEngine;

public class ClickToBookmark : MonoBehaviour
{
    // This works for VR (XR Simple Interactable calls this)
    public void OnClick()
    {
        Toggle();
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
            BookmarkBoard.Instance.ToggleBookmark(item);
        }
        else
        {
            Debug.LogError("Missing BookmarkBoard Instance or BookmarkableItem component!");
        }
    }
}