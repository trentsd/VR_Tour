using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoAudioController : MonoBehaviour
{
    public VideoPlayer video;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (video.frame > 120 && video.frame < 140)
        {
            video.SetDirectAudioMute(0, true);
        }
        else
        {
            video.SetDirectAudioMute(0, false);
        }

        Debug.Log(video.frame);
    }
}
