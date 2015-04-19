using UnityEngine;
using System.Collections;

public class Laboratory : ABuilding
{

    public Laboratory()
    {
        name = "Laboratories";
        description = "mutherfuckin' lab";
        foodCost = 0;
        moneyCost = 75;
        buildingMaterialsCost = 150;
    }

    public override void Effect()
    {
    }
}
