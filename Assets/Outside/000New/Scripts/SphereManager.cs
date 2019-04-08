using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour
{

    public GameObject sphere;
    Renderer rend;

    // Start is called before the first frame update
    void Awake()
    {
        rend = sphere.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeTexture(DetailsMoveButt details)
    {
        rend.material.mainTexture = details.myToTexture;
    }

}
