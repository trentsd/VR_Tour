using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    public Text infoText;
    public Image pictureBox;

    private AudioSource audioPlayer;
    private float startDelay = 0f;
    private float typeDelay = 0.01f;

    // Start is called before the first frame update
    void Awake()
    {
        audioPlayer = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void updateImage(Sprite newImage)
    {
        pictureBox.sprite = newImage;
    }

    private void playInformationSound(AudioClip newSoundClip)
    {
        if (audioPlayer.isPlaying)
        {
            audioPlayer.Stop();
        }

        audioPlayer.clip = newSoundClip;
        audioPlayer.Play();
    }

    public void updateInformation(DetailsInfoButt details)
    {
        updateImage(details.pictureToShow);
        playInformationSound(details.soundClip);
        //StartCoroutine(startTextScroll(details.infoTextToDisplay));
    }

    
}
