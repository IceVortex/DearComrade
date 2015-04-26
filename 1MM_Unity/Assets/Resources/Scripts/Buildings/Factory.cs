using UnityEngine;
using System.Collections;

public class Factory : ABuilding
{
    public float factoryPower;

    public Factory()
    {
        name = "Factory";
        shortDescription = "Factories are used to generate 10 materials each turn.";
        longDescription = "Factories are used to generate 10 materials each turn. You can also link a house to a factory and you will gain an additional 5 materials each turn. The effect also applies if you link a factory to a house.";
        flavorText = "However, in object-oriented programming, a factory is an object for creating other objects.";
        foodCost = 0;
        moneyCost = 3;
        buildingMaterialsCost = 25;
        factoryPower = GameResources.instance.factoryMaterialsT;
    }

    public override void Effect()
    {
        GameResources.instance.buildingMaterials += factoryPower;
        LoggingSystem.Instance.materialsGained += factoryPower;
    }
}
