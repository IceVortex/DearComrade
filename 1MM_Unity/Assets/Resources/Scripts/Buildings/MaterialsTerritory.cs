using UnityEngine;
using System.Collections;

public class MaterialsTerritory : ABuilding
{
    public float territory = 15;

    public MaterialsTerritory()
    {
        name = "Materials Teritory";
        shortDescription = "Materials teritories generate 15 materials each turn.";
        longDescription = "Materials teritories generate 15 food each turn.";
        flavorText = "You can find any type of materials here. Even boyfriend materials.";
        foodCost = 0;
        moneyCost = 0;
        buildingMaterialsCost = 0;
        territory = 15;
    }

    public override void Effect()
    {
        GameResources.instance.buildingMaterials += territory;
        LoggingSystem.Instance.materialsGained += territory;
    }
}
