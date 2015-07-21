using UnityEngine;
using System.Collections;

public class PublicSpace : ABuilding
{

    public PublicSpace()
    {
        name = "Public Space";
        shortDescription = "Public spaces increase your approval by 10 and decrease your approval decay rate by 10%.";
        longDescription = "Public spaces are used by your citizens to relax. Therefore, they increase your approval by 10 and decrease your approval decay rate by 10%. Linking a house to public spaces, gives you 0.5 approval.";
        flavorText = "So jus' chill, 'til the next episode.";
        foodCost = 0;
        moneyCost = 70;
        buildingMaterialsCost = 100;
    }

    public override void Initialize(int index, AResources resource)
    {
        base.Initialize(index, resource);
        res.approval += 10;
    }

}
