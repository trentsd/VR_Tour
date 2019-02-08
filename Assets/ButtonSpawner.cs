using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ButtonSpawner : MonoBehaviour {

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

    private Transform panelHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    public Transform BowTrans;
    public GameObject t_infoButton;

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

    public void SetupScene(int level)
    {
        BowTrans = this.gameObject.transform.GetChild(0);
        GameObject a = (GameObject)Instantiate(t_infoButton);
        a.transform.SetParent(BowTrans.transform, false);
    }
}
