using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateApproval : MonoBehaviour {

    public Image fillerGreen, fillerRed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(GameResources.instance.approval >= 0)
        {    
            fillerGreen.fillAmount = GameResources.instance.approval / 200;
            fillerRed.fillAmount = 0f;
        }
        else
        {
            fillerRed.fillAmount = -GameResources.instance.approval / 200;
            fillerGreen.fillAmount = 0f;
        }
	}
}
