using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTexture : MonoBehaviour {

    private Renderer rend;

	// Use this for initialization
	void Awake () {
        rend = this.GetComponent<Renderer>();
	}
	
    void LoadNewTexture(Texture toTexture)
    {
        rend.material.mainTexture = toTexture;
    }
}
