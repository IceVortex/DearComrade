using UnityEngine;
using System.Collections;

public class Hospital : ABuilding
{

    public Hospital()
    {
        name = "Hospital";
        description = "mutherfuckin' hospital";
        foodCost = 0;
        moneyCost = 350;
        buildingMaterialsCost = 700;
    }

    public override void Initialize(int index)
    {
        base.Initialize(index);
        GameResources.instance.approval += 40;
        GameResources.instance.approvalDecayRate -= 10f;
    }

}
