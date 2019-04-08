using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class capsuleController : MonoBehaviour
{

    public VideoPlayer video;

    public Vector3 point0;
    public Vector3 point1;
    public Vector3 point2;
    public Vector3 point3;
    public Vector3 point4;
    public Vector3 point5;

    public float speed = 1.0f;

    public float mod0_1;
    public float mod1_2;
    public float mod2_3;
    public float mod3_4;
    public float mod4_5;

    public string infoTextToDisplay;
    public Sprite pictureToShow;

    public string sceneToFollow;

    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => displayInfo());
        gameObject.transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(sceneToFollow));
        //StartCoroutine(EDITORTESTING());

    }

    IEnumerator EDITORTESTING()
    {
        yield return new WaitForSecondsRealtime(25);
        gameObject.GetComponent<Button>().onClick.Invoke();
    }

        // Update is called once per frame
        void Update()
    {

        float step = speed * Time.deltaTime;

        if (video.frame >= 520 && video.frame < 526)
        {
            transform.position = point0;
        }

        if (video.frame >= 526 && video.frame < 601)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            transform.position = Vector3.MoveTowards(transform.position, point1, step * mod0_1);
        }
        else if (video.frame >= 601 && video.frame < 688)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            transform.position = Vector3.MoveTowards(transform.position, point2, step * mod1_2);
        }
        else if (video.frame >= 688 && video.frame < 740)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;
            transform.position = Vector3.MoveTowards(transform.position, point3, step * mod2_3);
        }
        else if (video.frame >= 740 && video.frame < 841)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.grey;
            transform.position = Vector3.MoveTowards(transform.position, point4, step * mod3_4);
        }
        else if (video.frame >= 841 && video.frame < 953)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            transform.position = Vector3.MoveTowards(transform.position, point5, step * mod4_5);
        }
        else if (video.frame > 953 && video.frame < 960)
        {
            transform.position = new Vector3(0.0f, -1000.0f, 0.0f);
        }


        transform.GetChild(0).transform.LookAt(Vector3.zero);
        //transform.GetChild(1).transform.LookAt(Vector3.zero);
    }

    public void displayInfo()
    {
        if (transform.GetChild(0).gameObject.activeInHierarchy)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);

            transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>().sprite = pictureToShow;

            transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = infoTextToDisplay;
        }
    }
}
