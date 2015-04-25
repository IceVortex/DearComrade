using UnityEngine;
using System.Collections;

public class Farm : ABuilding
{
    public float farmPower; 
    
    public Farm()
    {
        name = "Farm";
        description = "mutherfuckin' furm";
        foodCost = 30;
        moneyCost = 10;
        buildingMaterialsCost = 30;
        farmPower = GameResources.instance.farmFoodT;
    }

    public override void Effect()
    {
        GameResources.instance.food += farmPower;
        LoggingSystem.Instance.foodGained += farmPower;
    }
}
