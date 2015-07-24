using UnityEngine;
using System.Collections;

public class Workplace : ABuilding
{

    public Workplace()
    {
        name = "Workplace";
        shortDescription = "Workplaces increase your approval by 30 and decrease the approval decay rate by 10%. ";
        longDescription = "Workplaces are the backbone of the economy and having plenty of them helps improving the country. These increase your approval by 30 and decrease the approval decay rate by 10%. Linking a house to workplaces increase the gold gained per citizen by 0.005. You can only link 2 houses to this building.";
        flavorText = "Work It Harder, Make It Better, Do It Faster, Makes Us stronger";
        foodCost = 0;
        moneyCost = 210;
        buildingMaterialsCost = 300;
    }

    public override void Initialize(int index, AResources resource)
    {
        base.Initialize(index, resource);
        res.approval += 30;
        res.approvalDecayRate -= 10f;
    }

}
