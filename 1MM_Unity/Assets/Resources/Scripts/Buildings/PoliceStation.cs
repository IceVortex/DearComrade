using UnityEngine;
using System.Collections;

public class PoliceStation : ABuilding
{

    public PoliceStation()
    {
        name = "Police Stations";
        description = "mutherfuckin' ps";
        foodCost = 0;
        moneyCost = 200;
        buildingMaterialsCost = 400;
    }

    public override void Initialize(int index)
    {
        base.Initialize(index);
        GameResources.instance.approval += 20;
        GameResources.instance.approvalDecayRate -= 10f;
    }

}
