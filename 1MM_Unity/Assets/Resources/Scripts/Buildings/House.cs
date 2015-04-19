using UnityEngine;
using System.Collections;

public class House : ABuilding {


    public House()
    {
        name = "House";
        description = "mutherfuckin' haus";
        foodCost = 0;
        moneyCost = 10;
        buildingMaterialsCost = 30;
    }

    public override void Effect()
    {
        GameResources.instance.maximumCitizens += 300;
    }
}
