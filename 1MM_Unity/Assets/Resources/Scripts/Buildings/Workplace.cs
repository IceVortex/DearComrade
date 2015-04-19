using UnityEngine;
using System.Collections;

public class Workplace : ABuilding
{

    public Workplace()
    {
        name = "Workplaces";
        description = "mutherfuckin' work";
        foodCost = 0;
        moneyCost = 275;
        buildingMaterialsCost = 550;
    }

    public override void Effect()
    {
        GameResources.instance.approval += 30;
        //GameResources.instance.maximumApprovalDecay -= 0.1f;
    }
}
