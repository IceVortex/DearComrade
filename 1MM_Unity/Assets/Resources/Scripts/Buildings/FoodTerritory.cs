﻿using UnityEngine;
using System.Collections;

public class FoodTerritory : ABuilding
{
    public float territory = 15;

    public FoodTerritory()
    {
        name = "Food Teritory";
        shortDescription = "Food teritories generate 15 food each turn.";
        longDescription = "Food teritories generate 15 food each turn.";
        flavorText = "Remember when food territories generated 15 food each turn? They always generated 15 food each turn.";
        foodCost = 0;
        moneyCost = 0;
        buildingMaterialsCost = 0;
        territory = 15;
    }

    public override void Effect()
    {
        GameResources.instance.food += territory;
        LoggingSystem.Instance.foodGained += territory;
    }
}
