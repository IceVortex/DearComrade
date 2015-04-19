using UnityEngine;
using System.Collections;

public class Farm : ABuilding
{

    public Farm()
    {
        name = "Farm";
        description = "mutherfuckin' furm";
        foodCost = 30;
        moneyCost = 10;
        buildingMaterialsCost = 30;
    }

    public override void Effect()
    {
        GameResources.instance.food += 10;
    }
}
