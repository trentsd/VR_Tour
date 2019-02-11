using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidTrigger : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer video_player;
    public Animator animator;
    public int stop;
    public GameObject screen;

    void Start()
    {
        video_player.playOnAwake = false;
        animator.enabled = true;
        animator.SetBool("bool", false);
        screen.GetComponent<Renderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        animStart();
        Invoke("playVid", 1f);
        
    }

    void animStart()
    {
        animator.SetBool("bool", true);
    }

    void playVid()
    {
        screen.GetComponent<Renderer>().enabled = true;
        video_player.Play();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
    }

}
