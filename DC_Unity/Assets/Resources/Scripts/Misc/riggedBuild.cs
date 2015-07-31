using UnityEngine;
using System.Collections;

public class riggedBuild : MonoBehaviour {

    private bool safe = false;
    public AResources resources;

	void Update () 
    {
		if (Input.GetKey (KeyCode.U))
			safe = true;

		if (Input.GetKey (KeyCode.I) && safe) {
            resources.approval = 150;
            resources.troops = 3500;
		}

		if (Input.GetKey (KeyCode.O) && safe) {
            resources.approval = -100;
		}

		if (Input.GetKeyDown (KeyCode.P) && safe) {
            resources.buildingMaterials += 100;
            resources.food += 100;
            resources.money += 100;
		}
	}
}
