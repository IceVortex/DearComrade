using UnityEngine;
using System.Collections;

public class researchOverview : MonoBehaviour {

    public GameObject laboratoryGO;
    public Laboratory lab;
    public bool foundLab;

	void Start () {
	
	}
	
	void Update () {
        if (!laboratoryGO && GameObject.FindGameObjectWithTag("Laboratory"))
        {
            laboratoryGO = GameObject.FindGameObjectWithTag("Laboratory");
            lab = (Laboratory)GameResources.instance.buildings[laboratoryGO.GetComponent<IdManager>().buildingIndex];
            foundLab = true;
        }
	}
}
