using UnityEngine;
using System.Collections;

public class EducationalBuilding : ABuilding
{

    public EducationalBuilding()
    {
        name = "Educational Buildings";
        description = "mutherfuckin' eb";
        foodCost = 0;
        moneyCost = 125;
        buildingMaterialsCost = 250;
    }

    public override void Effect()
    {
        GameResources.instance.approval += 10;
        //GameResources.instance.maximumApprovalDecay -= 0.1f;
    }
}
