using UnityEngine;
using System.Collections;

public class Workplace : ABuilding
{

    public Workplace()
    {
        name = "Workplaces";
        shortDescription = "Workplaces are the backbone of the economy and having plenty of them helps improving the country. These increase your approval by 30 and decrease the approval decay rate by 10%. ";
        longDescription = "Workplaces are the backbone of the economy and having plenty of them helps improving the country. These increase your approval by 30 and decrease the approval decay rate by 10%. Linking a house to workplaces increase the gold gained per citizen by 0.001.";
        flavorText = "Work It Harder, Make It Better, Do It Faster, Makes Us stronger";
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
