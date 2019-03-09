using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns = 4;
    public int rows = 4;
    public Count moveButtonCount = new Count(1, 8);
    public Count infoButtonCount = new Count(0, 16);
    public GameObject[] moveButtons;
    public GameObject[] infoButtons;

    public GameObject Bow;
    public GameObject BowStar;
    public GameObject Starboard;
    public GameObject SternStar;
    public GameObject Stern;
    public GameObject SternPort;
    public GameObject Port;
    public GameObject BowPort;

    public GameObject t_InfoButton;
    private List<Vector3> gridPositions = new List<Vector3>();


    void InitialiseList()
    {
        gridPositions.Clear();
        float xf = -0.375f;
        float yf = -0.375f;

        for (int x = 0; x < columns; x++)
        {
            for (float y = 0; y < rows; y++)
            {
                gridPositions.Add(new Vector3(xf, yf, 0f));
                yf += 0.25f;
            }
            yf = -0.375f;
            xf += 0.25f;
        }
    }

    void PanelSetup()
    {
        Transform bowTrans = Bow.GetComponent<Transform>();
        float xf = -0.375f;
        float yf = 0.375f;
        float zf = 1.207f;

        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                GameObject toInstantiate = t_InfoButton;

                GameObject instance = Instantiate(toInstantiate, new Vector3(xf, yf, zf), Quaternion.identity) as GameObject;
                instance.transform.SetParent(Bow.transform);

                yf += 0.25f;
            }
            yf = 0.375f;
            xf += 0.25f;
        }
    }

    public void SetupScene(int level)
    {
        PanelSetup();
        InitialiseList();
    }

}
