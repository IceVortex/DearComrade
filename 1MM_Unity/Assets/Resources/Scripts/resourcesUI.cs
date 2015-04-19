using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class resourcesUI : MonoBehaviour {

    public Text food, citizens, bm, money;

	void Update () {
        food.text = "Food: " + GameResources.instance.food.ToString();
        citizens.text = "Citizens: " + GameResources.instance.citizens.ToString() + "/" + GameResources.instance.maximumCitizens.ToString();
        bm.text = "Materials: " + GameResources.instance.buildingMaterials.ToString();
        money.text = "Money: " + GameResources.instance.money.ToString();
	}
}
