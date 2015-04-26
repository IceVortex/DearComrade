using UnityEngine;
using System.Collections;

public class WTC : ABuilding
{

    public WTC()
    {
        name = "World Trade Center";
        shortDescription = "By using this building you can trade food and materials for money or buy more food and materials using your currency.";
        longDescription = "By using this building you can trade food and materials for money or buy more food and materials using your currency. Linking a house to the WTC increases your sell rate, linking a factory or a farm increases your buy rate for both food and materials.";
        flavorText = "Beware of the planes.";
        foodCost = 0;
        moneyCost = 50;
        buildingMaterialsCost = 100;
    }

    public override void Effect()
    {
    }

    public void buyFood(int money)
    {
        GameResources.instance.money -= money;
        GameResources.instance.food += money * (GameResources.instance.buyRate / 100);
    }

    public void buyMaterials(int money)
    {
        GameResources.instance.money -= money;
        GameResources.instance.buildingMaterials += money * (GameResources.instance.buyRate / 100);
    }

    public void sellFood(int food)
    {
        GameResources.instance.food -= food;
        GameResources.instance.money += food * (GameResources.instance.sellRate / 100);
    }

    public void sellMaterials(int materials)
    {
        GameResources.instance.buildingMaterials -= materials;
        GameResources.instance.money += materials * (GameResources.instance.sellRate / 100);
    }
}
