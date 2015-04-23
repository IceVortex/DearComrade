using UnityEngine;
using System.Collections;

public class ABuilding {
    
    public string name, description;
    public int listIndex, comradeIndex = 0;
    public float foodCost, moneyCost, buildingMaterialsCost;

    public virtual void Effect()
    { }

    public virtual void Initialize(int index)
    {
        listIndex = index;
        substractCost();
    }

    public void substractCost()
    {
        GameResources.instance.food -= foodCost * (GameResources.instance.buildingCostRate / 100);
        GameResources.instance.money -= moneyCost * (GameResources.instance.buildingCostRate / 100);
        GameResources.instance.buildingMaterials -= buildingMaterialsCost * (GameResources.instance.buildingCostRate / 100);
    }

}
