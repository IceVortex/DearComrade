﻿using UnityEngine;
using System.Collections;

public class Hospital : ABuilding
{

    public Hospital()
    {
        name = "Hospital";
        shortDescription = "Hospitals increase your approval by 40 and decrease the approval decay by 10%.";
        longDescription = "Hospitals are absolutely essential to your country so your citizens stay healthy. Hospitals increase your approval by 40 and decrease the approval decay by 10%. Linking a house to a hospital decreases the flat approval decay by 1. You can link only 2 houses to this building.";
        flavorText = "How do vaccines cause autism? They don't.";
        foodCost = 0;
        moneyCost = 245;
        buildingMaterialsCost = 350;
    }

    public override void Initialize(int index, AResources resource)
    {
        base.Initialize(index, resource);
        res.approval += 40;
        res.approvalDecayRate -= 10f;
    }

}
