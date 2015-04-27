using UnityEngine;
using System.Collections;

public class MilitaryOutpost : ABuilding
{

    public MilitaryOutpost()
    {
        name = "Military Outpost";
        shortDescription = "The Military Outpost lets you create troops.";
        longDescription = "The Military Outpost lets you create troops. Troops are created by linking houses to the outpost. After that, you lose 300 maximum citizens which are added to the maximum number of troops and also 300 of your current citizens which are transformed into troops.";
        flavorText = "Men at arms, women at legs.";
        foodCost = 0;
        moneyCost = 50;
        buildingMaterialsCost = 100;
    }

}
