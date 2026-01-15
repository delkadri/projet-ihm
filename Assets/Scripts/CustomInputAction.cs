using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInputAction : MonoBehaviour
{
    public InputActionReference customButton;
    public MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        customButton.action.started += ButtonWasPressed;
        customButton.action.canceled += ButtonWasReleased;
    }

    void ButtonWasPressed(InputAction.CallbackContext context)
    {
        mesh.enabled = false;
    }

    void ButtonWasReleased(InputAction.CallbackContext context)
    {
        mesh.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
