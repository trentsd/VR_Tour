using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//to be attached to the First Person Controller
public class ScoreUpdater : MonoBehaviour
{
    public Text countText;
    public Text winText;
    private int count;

    void Start()
    {
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Items Found: " + count.ToString() +"/3";
        if (count >= 3)
        {
            countText.text = "All items found!";
        }
    }
}
