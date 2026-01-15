using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DummyBookmark : MonoBehaviour
{
    public InputActionReference bookmarkButton;

    // Start is called before the first frame update
    void Start()
    {
        bookmarkButton.action.started += BookmarkPressed;
    }

    void BookmarkPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Bookmark button pressed!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
