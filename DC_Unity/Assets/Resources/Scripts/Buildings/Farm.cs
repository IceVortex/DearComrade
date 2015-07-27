using UnityEngine;
using System.Collections;

public class Farm : ABuilding
{
    public float farmPower; 
    
    public Farm()
    {
        name = "Farm";
        shortDescription = "Food farms are used to generate 10 food each turn.";
        longDescription = "Food farms are used to generate 10 food each turn. You can also link a house to a food farm and you will gain an additional 5 food each turn. This effect also applies if you link a food farm to a house.";
        flavorText = "Remember when farms generated 15 food each turn? Pepperidge Farm remembers.";
        foodCost = 35;//50
        moneyCost = 3;
        buildingMaterialsCost = 20;
        //farmPower = res.farmFoodT;
    }

    public override void Initialize(int i, AResources resource)
    {
        base.Initialize(i, resource);
        farmPower = res.farmFoodT;
    }

    public override void Effect()
    {
        res.food += farmPower;
        if(res is GameResources)
        LoggingSystem.Instance.foodGained += farmPower;
    }
}
