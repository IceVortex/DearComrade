using UnityEngine;
using System.Collections;

public class EducationalBuilding : ABuilding
{

    public EducationalBuilding()
    {
        name = "Educational Building";
        description = "mutherfuckin' eb";
        foodCost = 0;
        moneyCost = 125;
        buildingMaterialsCost = 250;
    }

    public override void Initialize(int index)
    {
        base.Initialize(index);
        GameResources.instance.approval += 10;
        GameResources.instance.approvalDecayRate -= 10f;
    }

}
