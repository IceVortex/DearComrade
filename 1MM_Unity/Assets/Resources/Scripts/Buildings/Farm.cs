using UnityEngine;
using System.Collections;

public class Farm : ABuilding
{
    public float farmPower; 
    
    public Farm()
    {
        name = "Food Farms";
        shortDescription = "Food farms are used to generate 10 food each turn.";
        longDescription = "Food farms are used to generate 10 food each turn. You can also link a house to a food farm and you will gain an additional 5 food each turn. This effect also applies if you link a food farm to a house.";
        flavorText = "Remember when farms generated 15 food each turn? Pepperidge Farm remembers.";
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
