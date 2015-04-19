using UnityEngine;
using System.Collections;

public class ExecutiveBuilding : ABuilding
{
    public float taxes = 1;

    public ExecutiveBuilding()
    {
        name = "Executive Building";
        description = "mutherfuckin' EB";
        foodCost = 0;
        moneyCost = 0;
        buildingMaterialsCost = 0;
    }

    public override void Effect()
    {
        GameResources.instance.citizens += 100;
        GameResources.instance.money += 0.01f * GameResources.instance.citizens;
        GameResources.instance.approval -= 1;
    }
}
