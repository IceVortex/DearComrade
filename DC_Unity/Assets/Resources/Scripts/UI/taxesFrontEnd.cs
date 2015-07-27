using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class taxesFrontEnd : MonoBehaviour {

    public Text currentValue;
    public Slider rate;
    public AResources resources;

	
	void Update () {

        resources.taxRate = rate.value;
        resources.approvalDecayRate = rate.value;
        currentValue.text = "Current value: " + (int)rate.value + "%";
	}
}
