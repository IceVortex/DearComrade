using UnityEngine;
using System.Collections;

public class Workplace : ABuilding
{

    public Workplace()
    {
        name = "Workplace";
        description = "mutherfuckin' work";
        foodCost = 0;
        moneyCost = 275;
        buildingMaterialsCost = 550;
    }

    public override void Initialize(int index)
    {
        base.Initialize(index);
        GameResources.instance.approval += 30;
        GameResources.instance.approvalDecayRate -= 10f;
    }

}
