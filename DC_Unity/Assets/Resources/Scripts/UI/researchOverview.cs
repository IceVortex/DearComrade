using UnityEngine;
using System.Collections;

public class researchOverview : MonoBehaviour {

    public GameObject laboratoryGO;
    public Laboratory lab;
    public bool foundLab;
    public AResources resources;

	void Start () {
	
	}
	
	void Update () {
        if (!laboratoryGO && GameObject.FindGameObjectWithTag("Laboratory"))
        {
            laboratoryGO = GameObject.FindGameObjectWithTag("Laboratory");
            lab = (Laboratory)resources.buildings[laboratoryGO.GetComponent<IdManager>().buildingIndex];
            foundLab = true;
        }
	}
}
