using UnityEngine;
using System.Collections;

public class RobertTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(GameResources.instance.food);
        GameResources.instance.food = 10;
        Debug.Log(GameResources.instance.food);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
