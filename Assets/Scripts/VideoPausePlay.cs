using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class VideoPausePlay : MonoBehaviour
{
    public InputActionReference customButton;
    public VideoPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        // player = GetComponent<VideoPlayer>();
        customButton.action.started += callbackPausePlay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void callbackPausePlay(InputAction.CallbackContext context)
    {
        ChangePausePlay();
    }

    /**
    * Toggle video pause/play
    * input : TriggerButton (any hand)
    */
    public void ChangePausePlay()
    {
        if (player.isPlaying)
        {
            // play pause sound
            player.Pause();
        }
        else
        {
            // play play sound
            player.Play();
        }
    }

    /**
    * Go forward 10 seconds
    * input : Stick to the right (any hand)
    */
    public void forward10Sec()
    {
        player.time += 10;
    }

    /**
    * Go back 10 seconds
    * input : Stick to the left (any hand)
    */
    public void rewind10Sec()
    {
        player.time -= 10;
    }
}
