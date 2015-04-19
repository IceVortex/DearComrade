using UnityEngine;
using System.Collections;

public class WTC : ABuilding
{

    public WTC()
    {
        name = "World Trade Center";
        description = "mutherfuckin' WTC";
        foodCost = 0;
        moneyCost = 50;
        buildingMaterialsCost = 100;
    }

    public override void Effect()
    {
    }
}
