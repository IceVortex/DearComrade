using UnityEngine;
using System.Collections;

public class Factory : ABuilding
{

    public Factory()
    {
        name = "Factory";
        description = "mutherfuckin' fectari";
        foodCost = 0;
        moneyCost = 10;
        buildingMaterialsCost = 30;
    }

    public override void Effect()
    {
        GameResources.instance.buildingMaterials += 10;
    }
}
