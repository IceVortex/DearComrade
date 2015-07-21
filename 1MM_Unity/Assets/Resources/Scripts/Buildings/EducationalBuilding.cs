using UnityEngine;
using System.Collections;

public class EducationalBuilding : ABuilding
{

    public EducationalBuilding()
    {
        name = "Educational Building";
        shortDescription = "Educational Buildings increase your approval by 10 and decrease your approval decay rate by 10%.";
        longDescription = "Educational Buildings are vital to the development of your country since they educate the children. These increase your approval by 10 and decrease your approval decay rate by 10%. Linking a house to the educational buildings reduces the cost of constructing buildings by 2%.";
        flavorText = "You need to educate yourself so you won’t hate yourself, ‘cause being a fool is bad for yo’ health.";
        foodCost = 0;
        moneyCost = 140;
        buildingMaterialsCost = 200;
    }

    public override void Initialize(int index, AResources resource)
    {
        base.Initialize(index, resource);
        res.approval += 10;
        res.approvalDecayRate -= 10f;
    }

}
