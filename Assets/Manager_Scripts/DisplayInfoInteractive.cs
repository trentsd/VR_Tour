using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Menu
{
    // This script is for loading scenes from the main menu.
    // Each 'button' will be a rendering showing the scene
    // that will be loaded and use the SelectionRadial.
    public class DisplayInfoInteractive : MonoBehaviour
    {
        public event Action<MoveLocInteractive> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.

        public string myPanel;
        public string infoTextToDisplay;
        public Sprite pictureToShow;
        public AudioSource soundClip;
        public GameObject mainCamera;
        public GameObject InfoText;
        public GameObject UIPicture;
        public float xOffset;
        public float yOffset;
        [SerializeField] private Text infoTextBox;
        [SerializeField] private Image pictureBox;

        [SerializeField] private string textToDisplay;
        public float StartDelay = 2f;
        public float typeDelay = 0.01f;

        //[SerializeField] private string m_locationToLoad;                      // The name of the location to load.
        //[SerializeField] public String m_infoTextToDisplay;                   //Informational Text to display
        [SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
        [SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
        [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.


        private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.


        private void OnEnable()
        {
            mainCamera = GameObject.Find("MainCamera");
            m_SelectionRadial = mainCamera.GetComponent<SelectionRadial>();
            InfoText = GameObject.Find("InfoText");
            infoTextBox = InfoText.GetComponent<Text>();
            UIPicture = GameObject.Find("PictureBox");
            pictureBox = UIPicture.GetComponent<Image>();
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
        }


        private void HandleOver()
        {
            // When the user looks at the rendering of the scene, show the radial.
            m_SelectionRadial.Show();

            m_GazeOver = true;
        }


        private void HandleOut()
        {
            // When the user looks away from the rendering of the scene, hide the radial.
            m_SelectionRadial.Hide();

            m_GazeOver = false;
        }


        private void HandleSelectionComplete()
        {
            // If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
            if (m_GazeOver)
                StartCoroutine(ActivateButton());
        }


        
        private IEnumerator ActivateButton()
        {

            pictureBox.sprite = pictureToShow;

            soundClip.Play(0);

            yield return new WaitForSeconds(StartDelay);

            for (int i = 0; i < infoTextToDisplay.Length; i++)
            {
                infoTextBox.text = infoTextToDisplay.Substring(0, i+1);
                //infoText.text = infoTextToDisplay.Substring(0, i);
                print("PRINTING SOME STUUUUUF");
                yield return new WaitForSeconds(typeDelay);
            }

        }


    }
}