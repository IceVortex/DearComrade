using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class taxesFrontEnd : MonoBehaviour {

    public Text currentValue;
    public Slider rate;

	
	void Update () {

        GameResources.instance.taxRate = rate.value;
        currentValue.text = "Current value: " + (int)rate.value + "%";
	}
}
