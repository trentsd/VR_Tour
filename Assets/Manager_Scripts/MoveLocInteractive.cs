using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Menu
{
    // This script is for loading scenes from the main menu.
    // Each 'button' will be a rendering showing the scene
    // that will be loaded and use the SelectionRadial.
    public class MoveLocInteractive : MonoBehaviour
    {
        public event Action<MoveLocInteractive> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.

        public string myPanel;
        public Texture toTexture;
        public GameObject[] infoButtons;
        public GameObject[] moveButtons;
        public GameObject[] goInsideButtons;
        public GameObject mainCamera;
        public float xOffset;
        public float yOffset;
        Renderer rend;

        public GameObject managerObj;
        public GameManager manager;

        //[SerializeField] private string m_locationToLoad;                      // The name of the location to load.
        //[SerializeField] private Texture m_textureToLoad;                   //Texture to load
        [SerializeField] private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
        [SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
        [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.


        private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.


        

        private void OnEnable()
        {
            managerObj = GameObject.Find("GameManager");
            manager = managerObj.GetComponent<GameManager>();
            mainCamera = GameObject.Find("MainCamera");
            m_SelectionRadial = mainCamera.GetComponent<SelectionRadial>();
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
            {
                SendMessageUpwards("LoadNewTexture", toTexture);
                manager.loadArea(this.gameObject);
                //rend.material.mainTexture = toTexture;
            }
                //SendMessageUpwards("LoadNewTexture", toTexture);
                //StartCoroutine(ActivateButton());
        }


        /**
        private IEnumerator ActivateButton()
        {
            // If the camera is already fading, ignore.
            if (m_CameraFade.IsFading)
                yield break;

            // If anything is subscribed to the OnButtonSelected event, call it.
            if (OnButtonSelected != null)
                OnButtonSelected(this);

            // Wait for the camera to fade out.
            yield return StartCoroutine(m_CameraFade.BeginFadeOut(true));

            // Load the level.
            rend.material.mainTexture = m_textureToLoad;
        }**/

        
    }
}