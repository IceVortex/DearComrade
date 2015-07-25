using UnityEngine;
using System.Collections;

public class MilitaryOutpost : ABuilding
{

    public MilitaryOutpost()
    {
        name = "Military Outpost";
        shortDescription = "The Military Outpost lets you create troops.";
        longDescription = "The Military Outpost lets you create troops. Linking a house to the outpost grants you 300 troops but substracts 300 citizens. You also receive a stackable 8% chance to conquer a territory every turn, which is an improved version of a house, farm or factory.";
        flavorText = "Men at arms, women at legs.";
        foodCost = 0;
        moneyCost = 50;
        buildingMaterialsCost = 100;
    }

    public override void Effect()
    {
        if (res.troops <= res.maximumTroops)
        {
            if (res.maximumTroops - res.troops > 100)
                res.troops += 100;
            else
                res.troops = res.maximumTroops;
        }
    }
}
