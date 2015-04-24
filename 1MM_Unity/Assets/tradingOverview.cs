using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tradingOverview : MonoBehaviour {

    public GameObject WTCGO;
    public WTC wtc;

    public void buyFood()
    {
        if(GameResources.instance.food>=100)
            wtc.buyFood(100);
    }

    public void buyMaterials()
    {
        if (GameResources.instance.buildingMaterials >= 100)
            wtc.buyMaterials(100);
    }

    public void sellFood()
    {
        if (GameResources.instance.money >= 100)
            wtc.sellFood(100);
    }

    public void sellMaterials()
    {
        if (GameResources.instance.money >= 100)
            wtc.sellMaterials(100);
    }

	void Start () {
	    
	}
	
	void Update () {
        if (!WTCGO && GameObject.FindGameObjectWithTag("WTC"))
        {
            WTCGO = GameObject.FindGameObjectWithTag("WTC");
            wtc = (WTC)GameResources.instance.buildings[WTCGO.GetComponent<IdManager>().buildingIndex];
        }
	}
}
