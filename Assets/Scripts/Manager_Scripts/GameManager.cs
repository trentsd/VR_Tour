using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Menu;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public delegate void MoveClicked();
    public static event MoveClicked onClicked;

    public sphereManager sphereScript;

    [SerializeField] private Sprite blankSprite;
    [SerializeField] private Transform PlayerHUD;

    private int level = 0;

	// Use this for initialization
	void Awake () {
        sphereScript = GetComponent<sphereManager>();
        sphereScript.SphereInit();
	}

    public void loadArea(GameObject hitMoveButton)
    {
        MoveLocInteractive script = hitMoveButton.GetComponent<MoveLocInteractive>();
        sphereScript.SphereSetup(script.moveButtons, script.infoButtons, script.goInsideButtons);
        Text infoText = PlayerHUD.GetChild(0).GetChild(0).GetComponent<Text>();
        infoText.text = "";
        Image picture = PlayerHUD.GetChild(1).GetChild(0).GetComponent<Image>();
        picture.sprite = blankSprite;
    }

	public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
