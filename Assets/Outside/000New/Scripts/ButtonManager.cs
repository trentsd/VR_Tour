using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interactive360
{


    public class ButtonManager : MonoBehaviour
    {

        //FOR TESTING
        //public GameObject testMoveButton1;
        //public GameObject testMoveButton2;

        public SphereManager sphereManager;
        public GameManager gameManager;

        public GameObject directionalPanels;

        public Button[] moveButtons;
        public Button[] infoButtons;
        public Button[] goInsideButtons;

        private AudioSource audioPlayer;

        // Start is called before the first frame update
        void Start()
        {
            bindButtons();
            audioPlayer = this.GetComponent<AudioSource>();
            StartCoroutine(EDITORTESTING1());
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator EDITORTESTING1()
        {
            yield return new WaitForSecondsRealtime(10);
            infoButtons[0].onClick.Invoke();
            yield return new WaitForSecondsRealtime(10);
            infoButtons[1].onClick.Invoke();
            yield return new WaitForSecondsRealtime(10);
            moveButtons[0].onClick.Invoke();

            for (int i = 2; i < 15; i++)
            {
                switch (i)
                {
                    case 5:
                    case 10:
                    case 11:
                    case 12:
                        infoButtons[0].onClick.Invoke();
                        yield return new WaitForSecondsRealtime(15);
                        break;
                    default:
                        break;
                }
                moveButtons[1].onClick.Invoke();
                yield return new WaitForSecondsRealtime(2);
            }

            yield return new WaitForSecondsRealtime(2);
            infoButtons[0].onClick.Invoke();
            yield return new WaitForSecondsRealtime(10);
            infoButtons[1].onClick.Invoke();
            yield return new WaitForSecondsRealtime(10);
            moveButtons[0].onClick.Invoke();

            for (int i = 14; i > 1; i--)
            {
                switch (i)
                {
                    case 5:
                    case 10:
                    case 11:
                    case 12:
                        infoButtons[0].onClick.Invoke();
                        yield return new WaitForSecondsRealtime(15);
                        break;
                    default:
                        break;
                }
                moveButtons[0].onClick.Invoke();
                yield return new WaitForSecondsRealtime(2);
            }

            yield return new WaitForSecondsRealtime(10);
            infoButtons[0].onClick.Invoke();
            yield return new WaitForSecondsRealtime(10);
            infoButtons[1].onClick.Invoke();
            yield return new WaitForSecondsRealtime(10);
            goInsideButtons[0].onClick.Invoke();
        }

        IEnumerator EDITORTESTING2()
        {
            yield return new WaitForSecondsRealtime(5);
            infoButtons[0].onClick.Invoke();
            yield return new WaitForSecondsRealtime(3);
            moveButtons[0].onClick.Invoke();
            yield return new WaitForSecondsRealtime(3);
            moveButtons[0].onClick.Invoke();
            yield return new WaitForSecondsRealtime(3);
            infoButtons[0].onClick.Invoke();

        }

        IEnumerator EDITORTESTING3()
        {
            yield return new WaitForSecondsRealtime(2);
            goInsideButtons[0].onClick.Invoke();
        }

        void placeNewMoveButtons(DetailsMoveButt callingMButtonDetails)
        {
            this.moveButtons = new Button[callingMButtonDetails.myMoveButtons.Length];

            for (int i = 0; i < callingMButtonDetails.myMoveButtons.Length; i++)
            {
                DetailsMoveButt mDetails = callingMButtonDetails.myMoveButtons[i].GetComponent<DetailsMoveButt>();

                if (directionalPanels.transform.Find(mDetails.myPanel) != null)
                {
                    Transform panel = directionalPanels.transform.Find(mDetails.myPanel);
                    GameObject newButton = Instantiate(callingMButtonDetails.myMoveButtons[i], panel.position, panel.rotation);
                    newButton.transform.SetParent(panel);
                    newButton.transform.Translate(new Vector3(mDetails.xOffset, mDetails.yOffset));

                    this.moveButtons[i] = newButton.GetComponent<Button>();
                }
                else
                {
                    Debug.Log("A move button was not properly assigned to a panel");
                }
            }
        }

        void placeNewInfoButtons(DetailsMoveButt callingMButtonDetails)
        {
            this.infoButtons = new Button[callingMButtonDetails.myInfoButtons.Length];

            for (int i = 0; i < callingMButtonDetails.myInfoButtons.Length; i++)
            {
                DetailsInfoButt iDetails = callingMButtonDetails.myInfoButtons[i].GetComponent<DetailsInfoButt>();

                if (directionalPanels.transform.Find(iDetails.myPanel) != null)
                {
                    Transform panel = directionalPanels.transform.Find(iDetails.myPanel);
                    GameObject newButton = Instantiate(callingMButtonDetails.myInfoButtons[i], panel.position, panel.rotation);
                    newButton.transform.SetParent(panel);
                    newButton.transform.Translate(new Vector3(iDetails.xOffset, iDetails.yOffset));

                    this.infoButtons[i] = newButton.GetComponent<Button>();
                }
                else
                {
                    Debug.Log("An info button was not properly assigned to a panel");
                }
            }
        }

        void placeNewGoInsideButtons(DetailsMoveButt callingMButtonDetails)
        {
            this.goInsideButtons = new Button[callingMButtonDetails.myGoInsideButtons.Length];

            for (int i = 0; i < callingMButtonDetails.myGoInsideButtons.Length; i++)
            {
                DetailsGoInsideButt gDetails = callingMButtonDetails.myGoInsideButtons[i].GetComponent<DetailsGoInsideButt>();

                if (directionalPanels.transform.Find(gDetails.myPanel) != null)
                {
                    Transform panel = directionalPanels.transform.Find(gDetails.myPanel);
                    GameObject newButton = Instantiate(callingMButtonDetails.myGoInsideButtons[i], panel.position, panel.rotation);
                    newButton.transform.SetParent(panel);
                    newButton.transform.Translate(new Vector3(gDetails.xOffset, gDetails.yOffset));

                    this.goInsideButtons[i] = newButton.GetComponent<Button>();
                }
                else
                {
                    Debug.Log("A goInside button was not properly assigned to a panel");
                }
            }
        }

        void placeAllNewButtons(DetailsMoveButt callingMButtonDetails)
        {
            placeNewMoveButtons(callingMButtonDetails);
            placeNewInfoButtons(callingMButtonDetails);
            placeNewGoInsideButtons(callingMButtonDetails);
        }

        void destroyPanelChildren()
        {
            int x = 1;
            foreach (Transform panel in directionalPanels.transform)
            {
                foreach (Transform child in panel)
                {
                    GameObject.Destroy(child.gameObject);
                }
                print("Hit a panel " + x);
                x++;
            }

        }

        void displayInfo(Button iButton)
        {

            if (iButton.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                if (audioPlayer.isPlaying)
                {
                    audioPlayer.Stop();
                }
                iButton.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                iButton.transform.GetChild(0).gameObject.SetActive(true);

                iButton.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = iButton.GetComponent<DetailsInfoButt>().pictureToShow;

                if (audioPlayer.isPlaying)
                {
                    audioPlayer.Stop();
                }
                audioPlayer.clip = iButton.GetComponent<DetailsInfoButt>().soundClip;
                audioPlayer.Play();

                iButton.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = iButton.GetComponent<DetailsInfoButt>().infoTextToDisplay;

            }
            
        }

        public void bindButtons()
        {
            foreach (Button mButton in this.moveButtons)
            {
                mButton.onClick.AddListener(() => sphereManager.changeTexture(mButton.GetComponent<DetailsMoveButt>()));
                mButton.onClick.AddListener(() => this.loadMoveButton(mButton.GetComponent<DetailsMoveButt>()));
            }

            foreach (Button iButton in this.infoButtons)
            {
                iButton.onClick.AddListener(() => this.displayInfo(iButton));
            }

            foreach (Button gButton in this.goInsideButtons)
            {
                gButton.onClick.AddListener(() => gameManager.SelectScene(gButton.GetComponent<DetailsGoInsideButt>().sceneToLoad));
            }
        }

        public void loadMoveButton(DetailsMoveButt details)
        {

            if (audioPlayer.isPlaying)
            {
                audioPlayer.Stop();
            }

            destroyPanelChildren();

            placeAllNewButtons(details);

            bindButtons();


        }
    }
}
