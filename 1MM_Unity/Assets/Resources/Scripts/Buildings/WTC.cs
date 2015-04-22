using UnityEngine;
using System.Collections;

public class WTC : ABuilding
{

    public WTC()
    {
        name = "World Trade Center";
        description = "mutherfuckin' WTC";
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
