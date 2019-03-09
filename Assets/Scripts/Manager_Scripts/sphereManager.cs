using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using VRStandardAssets.Menu;

public class sphereManager : MonoBehaviour {


    public delegate void moveAction();
    public static event moveAction moveSelected;

    public Texture initialTexture;
    public GameObject[] initialInfoButtons;
    public GameObject[] initialMoveButtons;
    public GameObject[] initialGoInsideButtons;

    //public Transform PanelPrefab;
    public GameObject DPanels;
    public GameObject sphere;

    private GameObject PanelInstance;

    private Transform sphereHolder;
    private Transform DPanelHolder;
    private List<Vector3> gridPositions = new List<Vector3>();


    private Renderer rend;

    void InstantiateButtons(GameObject[] moveButtons, GameObject[] infoButtons, GameObject[] goInsideButtons)
    {
        foreach (GameObject move in moveButtons)
        {
            MoveLocInteractive moveScript = move.GetComponent<MoveLocInteractive>();

            if (PanelInstance.transform.Find(moveScript.myPanel) != null)
            {
                Transform panel = PanelInstance.transform.Find(moveScript.myPanel);
                GameObject newButton = Instantiate(move, panel.position, panel.rotation);
                //MoveLocInteractive script = newButton.GetComponent<MoveLocInteractive>();
                //script.enabled = true;
                newButton.transform.SetParent(panel);
                newButton.transform.Translate(new Vector3(moveScript.xOffset, moveScript.yOffset));
            }
            else
            {
                Debug.Log("A button was not properly assigned a panel");
            }
        }

        foreach (GameObject info in infoButtons)
        {
            DisplayInfoInteractive infoScript = info.GetComponent<DisplayInfoInteractive>();

            if (PanelInstance.transform.Find(infoScript.myPanel) != null)
            {
                Transform panel = PanelInstance.transform.Find(infoScript.myPanel);
                GameObject newButton = Instantiate(info, panel.position, panel.rotation);
                //ENABLE SCRIPT HERE///////////////////////////////////////////////////////////////////////////////
                newButton.transform.SetParent(panel);
                newButton.transform.Translate(new Vector3(infoScript.xOffset, infoScript.yOffset));
                //newButton.transform.LookAt(DPanels.transform);
            }
            else
            {
                Debug.Log("A button was not properly assigned a panel");
            }
        }

        foreach (GameObject inside in goInsideButtons)
        {
            GoInsideInteractive goInsideScript = inside.GetComponent<GoInsideInteractive>();

            if (PanelInstance.transform.Find(goInsideScript.myPanel) != null)
            {
                Transform panel = PanelInstance.transform.Find(goInsideScript.myPanel);
                GameObject newButton = Instantiate(inside, panel.position, panel.rotation);
                newButton.transform.SetParent(panel);
                newButton.transform.Translate(new Vector3(goInsideScript.xOffset, goInsideScript.yOffset));
            }
            else
            {
                Debug.Log("A button was not properly assigned a panel");
            }
        }
    }

    public void SphereInit()
    {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(0f, 0f, 0f);
        sphere.transform.localScale = new Vector3(1000f, 1000f, 1000f);
        sphere.AddComponent<ReverseNormals>();
        sphere.AddComponent<changeTexture>();
        rend = sphere.GetComponent<Renderer>();
        rend.material.mainTexture = initialTexture;
        rend.material.shader = Shader.Find("Unlit/Texture");

        PanelInstance = Instantiate(DPanels, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
        PanelInstance.transform.SetParent(sphere.transform);

        InstantiateButtons(initialMoveButtons, initialInfoButtons, initialGoInsideButtons);
        //DPanels.transform.SetParent(sphere.transform);
    }

    void DestroyPanelChildren()
    {
        int x = 1;
        foreach (Transform panel in PanelInstance.transform)
        {
            foreach (Transform child in panel)
            {
                GameObject.Destroy(child.gameObject);
            }
            print("Hit a panel" + x);
            x++;
        }
    }

    public void SphereSetup(GameObject[] moveButtons, GameObject[] infoButtons, GameObject[] goInsideButtons)
    {
        DestroyPanelChildren();
        InstantiateButtons(moveButtons, infoButtons, goInsideButtons);
    }
    
        

    /**public void switchMaterial(Texture newTexture)
    {
        if (moveSelected != null)
        {
            moveSelected();
        }
    }**/
}
