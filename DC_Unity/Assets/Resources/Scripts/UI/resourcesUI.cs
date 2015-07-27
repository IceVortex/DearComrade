using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class resourcesUI : MonoBehaviour {

    public Text food, citizens, bm, money, troops, researchPoints;
    public AResources resources;

	void Update () {
        food.text = "Food: " + System.Math.Round(resources.food,2).ToString();
        citizens.text = "Citizens: " + System.Math.Round(resources.citizens,2).ToString() + "/" + System.Math.Round(resources.maximumCitizens,2).ToString();
        bm.text = "Materials: " + System.Math.Round(resources.buildingMaterials,2).ToString();
        money.text = "Money: " + System.Math.Round(resources.money,2).ToString();
        troops.text = "Troops: " + System.Math.Round(resources.troops,2).ToString() + "/" + System.Math.Round(resources.maximumTroops,2).ToString();
        researchPoints.text = "Research Points: " + System.Math.Round(resources.researchPoints, 2).ToString();
    }

    public void displayTooltip(GameObject tooltip)
    {
        tooltip.GetComponent<hide>().toggle();
    }

    public void hideTooltip(GameObject tooltip)
    {
        tooltip.GetComponent<hide>().toggle();
    }
}
