using UnityEngine;
using System.Collections;

public class ABuilding {
    
    public string name, shortDescription, longDescription, flavorText;
    public int listIndex, comradeIndex = 0;
    public float foodCost, moneyCost, buildingMaterialsCost;
    public AResources res;
    public GameObject sceneBuilding;

    public virtual void Effect()
    { }

    public virtual void Initialize(int index, AResources resource)
    {
        listIndex = index;
        res = resource;
        substractCost();
    }

    public void substractCost()
    {
        res.food -= foodCost * (res.buildingCostRate / 100);
        res.money -= moneyCost * (res.buildingCostRate / 100);
        res.buildingMaterials -= buildingMaterialsCost * (res.buildingCostRate / 100);
    }

}
