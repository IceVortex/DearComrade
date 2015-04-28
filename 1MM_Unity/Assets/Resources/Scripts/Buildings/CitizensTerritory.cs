using UnityEngine;
using System.Collections;

public class CitizensTerritory : ABuilding
{

    public CitizensTerritory()
    {
        name = "Citizens Territory";
        shortDescription = "Citizens teritories increase the number of maximum citizens by 450.";
        longDescription = "Citizens teritories increase the number of maximum citizens by 450.";
        flavorText = "I swear they are not slaves.";
        foodCost = 0;
        moneyCost = 0;
        buildingMaterialsCost = 0;
    }

    public override void Initialize(int index)
    {
        base.Initialize(index);
        GameResources.instance.maxHomelessCitizens += 450;
    }
}
