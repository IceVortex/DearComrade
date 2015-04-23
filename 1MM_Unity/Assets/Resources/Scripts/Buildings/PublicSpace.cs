using UnityEngine;
using System.Collections;

public class PublicSpace : ABuilding
{

    public PublicSpace()
    {
        name = "PublicSpaces";
        description = "mutherfuckin' ps";
        foodCost = 0;
        moneyCost = 50;
        buildingMaterialsCost = 100;
    }

    public override void Initialize(int index)
    {
        base.Initialize(index);
        GameResources.instance.approval += 10;
    }

}
