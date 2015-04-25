using UnityEngine;
using System.Collections;

public class Factory : ABuilding
{
    public float factoryPower;

    public Factory()
    {
        name = "Factory";
        description = "mutherfuckin' fectari";
        foodCost = 0;
        moneyCost = 10;
        buildingMaterialsCost = 30;
        factoryPower = GameResources.instance.factoryMaterialsT;
    }

    public override void Effect()
    {
        GameResources.instance.buildingMaterials += factoryPower;
        LoggingSystem.Instance.materialsGained += factoryPower;
    }
}
