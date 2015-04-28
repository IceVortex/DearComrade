﻿using UnityEngine;
using System.Collections;

public class PoliceStation : ABuilding
{

    public PoliceStation()
    {
        name = "Police Station";
        shortDescription = "Police Stations increase your approval by 20 and decrease the approval decay rate by 10%.";
        longDescription = "Police Stations are essential for ensuring the security of your citizens. These increase your approval by 20 and decrease the approval decay rate by 10%. Linking a house to the police stations decreases the approval decay by 1%.";
        flavorText = "If the thug life chose you, the police also chooses to arrest you.";
        foodCost = 0;
        moneyCost = 175;
        buildingMaterialsCost = 250;
    }

    public override void Initialize(int index)
    {
        base.Initialize(index);
        GameResources.instance.approval += 20;
        GameResources.instance.approvalDecayRate -= 10f;
    }

}
