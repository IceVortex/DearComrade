using UnityEngine;
using System.Collections;

public class riggedBuild : MonoBehaviour {

    private bool safe = false;
    public AResources resources;

	void Start () {
	
	}


	void Update () 
    {
		if (Input.GetKey (KeyCode.S))
			safe = true;

		if (Input.GetKey (KeyCode.W) && safe) {
            resources.approval = 150;
            resources.troops = 3500;
		}

		if (Input.GetKey (KeyCode.L) && safe) {
            resources.approval = -100;
		}

		if (Input.GetKeyDown (KeyCode.R) && safe) {
            resources.buildingMaterials += 100;
            resources.food += 100;
            resources.money += 100;
		}
	}
}
