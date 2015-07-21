using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateApproval : MonoBehaviour {

    public Image fillerGreen, fillerRed;
    public AResources resources;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (resources.approval >= 0)
        {
            fillerGreen.fillAmount = resources.approval / 200;
            fillerRed.fillAmount = 0f;
        }
        else
        {
            fillerRed.fillAmount = -resources.approval / 200;
            fillerGreen.fillAmount = 0f;
        }

        if (fillerGreen.fillAmount >= 0.5F)
        {
            fillerGreen.fillAmount = 0.5F;
        }
        if (fillerRed.fillAmount >= 0.5F)
        {
            fillerRed.fillAmount = 0.5F;
        }

	}
}
