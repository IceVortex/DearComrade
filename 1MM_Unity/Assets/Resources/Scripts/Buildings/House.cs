using UnityEngine;
using System.Collections;

public class House : ABuilding {

    public float housePower;

    public House()
    {
        name = "House";
        description = "mutherfuckin' haus";
        foodCost = 0;
        moneyCost = 10;
        buildingMaterialsCost = 30;
        housePower = GameResources.instance.houseCitizensT;
    }

    public override void Initialize()
    {
        base.Initialize();
        GameResources.instance.maximumCitizens += housePower;
    }

    public override void Effect()
    {

    }
}
