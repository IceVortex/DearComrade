using UnityEngine;
using System.Collections;

public class riggedBuild : MonoBehaviour {

    private bool safe = false;

	void Start () {
	
	}


	void Update () 
    {
		if (Input.GetKey (KeyCode.S))
			safe = true;

		if (Input.GetKey (KeyCode.W) && safe) {
			GameResources.instance.approval = 150;
			GameResources.instance.troops = 3500;
		}

		if (Input.GetKey (KeyCode.L) && safe) {
			GameResources.instance.approval = -100;
		}

		if (Input.GetKeyDown (KeyCode.R) && safe) {
			GameResources.instance.buildingMaterials+=100;
			GameResources.instance.food+=100;
			GameResources.instance.money+=100;
		}
	}
}
