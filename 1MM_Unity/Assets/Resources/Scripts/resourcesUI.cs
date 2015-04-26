using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class resourcesUI : MonoBehaviour {

    public Text food, citizens, bm, money, troops, researchPoints;

	void Update () {
        food.text = "Food: " + GameResources.instance.food.ToString();
        citizens.text = "Citizens: " + GameResources.instance.citizens.ToString() + "/" + GameResources.instance.maximumCitizens.ToString();
        bm.text = "Materials: " + GameResources.instance.buildingMaterials.ToString();
        money.text = "Money: " + GameResources.instance.money.ToString();
        troops.text = "Troops: " + GameResources.instance.troops.ToString() + "/" + GameResources.instance.maximumTroops;
        researchPoints.text = "Research Points: " + GameResources.instance.researchPoints;
    }
}
