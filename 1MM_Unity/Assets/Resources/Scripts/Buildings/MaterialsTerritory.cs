using UnityEngine;
using System.Collections;

public class MaterialsTerritory : ABuilding
{
    public float territory = 15;

    public MaterialsTerritory()
    {
        name = "Materials Territory";
        shortDescription = "Materials territories generate 15 materials each turn.";
        longDescription = "Materials territories generate 15 materials each turn.";
        flavorText = "You can find any type of materials here. Even boyfriend materials.";
        foodCost = 0;
        moneyCost = 0;
        buildingMaterialsCost = 0;
        territory = 15;
    }

    public override void Effect()
    {
        res.buildingMaterials += territory;
        if (res is GameResources)
            LoggingSystem.Instance.materialsGained += territory;
    }
}
