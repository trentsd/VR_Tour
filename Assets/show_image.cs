using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_image : MonoBehaviour
{
    public Animator animator;
    public int stop;

    bool hasExited = false;


    void Start()
    {
        animator.enabled = true;
        animator.SetBool("play", false);
        animator.SetBool("reverse", false);

        hasExited = false;

        animator.GetComponent<Renderer>().enabled = false;
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

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
    }

    void closeTv()
    {
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
