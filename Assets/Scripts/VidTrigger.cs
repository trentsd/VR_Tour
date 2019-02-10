using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidTrigger : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer video_player;

    public UnityEditor.Animations.AnimatorController animator;

    public int stop;


    // Start is called before the first frame update
    void Start()
    {
        video_player.playOnAwake = false;
   
    }

    private void OnTriggerEnter(Collider other)
    {
        video_player.Play();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
    }
}
