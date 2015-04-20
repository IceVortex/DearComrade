using UnityEngine;
using System.Collections;

public class ABuilding {
    
    public string name, description;
    public float foodCost, moneyCost, buildingMaterialsCost;

    public virtual void Effect()
    { }

    public virtual void Initialize()
    {
        substractCost();
    }

    public virtual bool canBuy<building>() where building : ABuilding, new()
    { return false; }

    public void substractCost()
    {
        GameResources.instance.food -= foodCost;
        GameResources.instance.money -= moneyCost;
        GameResources.instance.buildingMaterials -= buildingMaterialsCost;
    }

}
