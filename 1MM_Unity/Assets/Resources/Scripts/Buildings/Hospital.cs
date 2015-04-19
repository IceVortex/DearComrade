using UnityEngine;
using System.Collections;

public class Hospital : ABuilding
{

    public Hospital()
    {
        name = "Hospitals";
        description = "mutherfuckin' hospital";
        foodCost = 0;
        moneyCost = 350;
        buildingMaterialsCost = 700;
    }

    public override void Effect()
    {
        GameResources.instance.approval += 40;
        //GameResources.instance.maximumApprovalDecay -= 0.4f;
    }
}
