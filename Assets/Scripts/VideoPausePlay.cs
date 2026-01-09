using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class VideoPausePlay : MonoBehaviour
{
    private VideoPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
