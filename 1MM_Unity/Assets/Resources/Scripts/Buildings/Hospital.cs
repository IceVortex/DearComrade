using UnityEngine;
using System.Collections;

public class Hospital : ABuilding
{

    public Hospital()
    {
        name = "Hospital";
        shortDescription = "Hospitals increase your approval by 40 and decrease the approval decay by 10%.";
        longDescription = "Hospitals are absolutely essential to your country. When you have hospitals, people are happy because they are treated okay. Hospitals increase your approval by 40 and decrease the approval decay by 10%. Linking a house to a hospital increases the maximum number of homeless citizens  by 50.";
        flavorText = "How do vaccines cause autism? They f***ing don't.";
        foodCost = 0;
        moneyCost = 245;
        buildingMaterialsCost = 350;
    }

    public override void Initialize(int index)
    {
        base.Initialize(index);
        GameResources.instance.approval += 40;
        GameResources.instance.approvalDecayRate -= 10f;
    }

}
