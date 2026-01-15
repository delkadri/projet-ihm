using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.InputSystem;

public class NewVideoHandler : MonoBehaviour
{
    public InputActionReference pausePlayButton;
    public VideoPlayer player;

    public InputActionReference forwardButton;
    public InputActionReference backwardButton;

    // Start is called before the first frame update
    void Start()
    {
            // callback version
        // pausePlayButton.action.started += TogglePausePlay;
        // forwardButton.action.started += Forward;
        // backwardButton.action.started += Backward;
    }

    // void ButtonWasPressed(InputAction.CallbackContext context)
    // {
    //     player.Pause();
    // }

    // void ButtonWasReleased(InputAction.CallbackContext context)
    // {
    //     player.Play();
    // }

    // void ThumbstickMoved(InputAction.CallbackContext context)
    // {
    //     Vector2 extractedVector = context.ReadValue<Vector2>();
    //     Debug.Log("Thumbstick moved: " + extractedVector);
    //     if(extractedVector.x > 0.5f)
    //     {
    //         // Move forward 10 seconds
    //         player.time += 10;
    //     }
    //     else if(extractedVector.x < -0.5f)
    //     {
    //         // Move backward 10 seconds
    //         player.time -= 10;
    //     }
    // }

    void TogglePausePlay(InputAction.CallbackContext context)
    {
        if (player.isPlaying)
        {
            player.Pause();
        }
        else
        {
            player.Play();
        }
    }

    void Forward(InputAction.CallbackContext context)
    {
        player.time += 5;
    }

    void Backward(InputAction.CallbackContext context)
    {
        player.time -= 5;
    }

    public void TogglePausePlayUI()
    {
        // Debug.Log("Pause/Play");
        if (player.isPlaying)
        {
            player.Pause();
        }
        else
        {
            player.Play();
        }
    }

    public void ForwardUI()
    {
        // Debug.Log("Forward");
        player.time += 5;
    }

    public void BackwardUI()
    {
        // Debug.Log("Backward");
        player.time -= 5;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
