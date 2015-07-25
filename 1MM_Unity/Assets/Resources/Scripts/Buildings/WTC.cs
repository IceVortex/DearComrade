using UnityEngine;
using System.Collections;

public class WTC : ABuilding
{

    public WTC()
    {
        name = "World Trade Center";
        shortDescription = "The World Trade Center lets you sell food and materials or buy more food and materials.";
        longDescription = "By using this building you can trade food and materials for money or buy more food and materials using your currency. Linking a house to the WTC increases your sell rate.";
        flavorText = "Beware of the planes.";
        foodCost = 0;
        moneyCost = 75;
        buildingMaterialsCost = 150;
    }

    public override void Effect()
    {
    }

    public void buyFood(int money)
    {
        res.money -= money;
        res.food += money * (res.buyRate / 100);
    }

    public void buyMaterials(int money)
    {
        res.money -= money;
        res.buildingMaterials += money * (res.buyRate / 100);
    }

    public void sellFood(int food)
    {
        res.food -= food;
        res.money += food * (res.sellRate / 100);
    }

    public void sellMaterials(int materials)
    {
        res.buildingMaterials -= materials;
        res.money += materials * (res.sellRate / 100);
    }
}
