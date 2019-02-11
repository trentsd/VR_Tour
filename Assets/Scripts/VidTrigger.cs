using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidTrigger : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer video_player;
    public Animator animator;
    public int stop;
    public GameObject screen;

    bool hasExited = false;


    void Start()
    {
        video_player.playOnAwake = false;
        animator.enabled = true;
        animator.SetBool("play", false);
        animator.SetBool("reverse", false);

        hasExited = false;

        animator.GetComponent<Renderer>().enabled = false;
        screen.GetComponent<Renderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        hasExited = false;
        animator.GetComponent<Renderer>().enabled = true;
        animStart();
        Invoke("playVid", 1f);
        
    }

    private void OnTriggerExit(Collider other)
    {
        hasExited = true;
        closeTv();
    }

    void animStart()
    {
        animator.SetBool("reverse", false);
        animator.SetBool("play", true);
    }

    void animReverse()
    {
        animator.SetBool("reverse", true);
        animator.SetBool("play", true);
    }

    void playVid()
    {
        if(!hasExited)
        {
            screen.GetComponent<Renderer>().enabled = true;
            video_player.Play();
        }
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
    }

    void closeTv()
    {
        video_player.Pause();
        video_player.Stop();
        screen.GetComponent<Renderer>().enabled = false;
        animReverse();
        Invoke("vanishTv", 1f);
    }

    void vanishTv()
    {
        animator.GetComponent<Renderer>().enabled = false;
        animator.SetBool("reverse", false);
        animator.SetBool("play", false);
    }

}
