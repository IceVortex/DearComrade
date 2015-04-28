using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class resourcesUI : MonoBehaviour {

    public Text food, citizens, bm, money, troops, researchPoints;

	void Update () {
        food.text = "Food: " + System.Math.Round(GameResources.instance.food,2).ToString();
        citizens.text = "Citizens: " + System.Math.Round(GameResources.instance.citizens,2).ToString() + "/" + System.Math.Round(GameResources.instance.maximumCitizens,2).ToString();
        bm.text = "Materials: " + System.Math.Round(GameResources.instance.buildingMaterials,2).ToString();
        money.text = "Money: " + System.Math.Round(GameResources.instance.money,2).ToString();
        troops.text = "Troops: " + System.Math.Round(GameResources.instance.troops,2).ToString() + "/" + System.Math.Round(GameResources.instance.maximumTroops,2).ToString();
        researchPoints.text = "Research Points: " + System.Math.Round(GameResources.instance.researchPoints, 2).ToString();
    }
}
