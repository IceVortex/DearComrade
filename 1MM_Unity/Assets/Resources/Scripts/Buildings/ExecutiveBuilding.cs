using UnityEngine;
using System.Collections;

public class ExecutiveBuilding : ABuilding
{
    public int taxes = 1, cdFestival = 0, cdPublicSpeech = 0;
    private int festivalFoodCost = 100, festivalMoneyCost = 75;
    private int publicSpeechMoneyCost = 75;
    private int numberOfCitizens = 400; 

    public ExecutiveBuilding()
    {
        name = "Executive Building";
        description = "mutherfuckin' EB";
        foodCost = 0;
        moneyCost = 0;
        buildingMaterialsCost = 0;
    }

    public override void Initialize()
    {
        base.Initialize();
        GameResources.instance.maximumCitizens = numberOfCitizens;
    }

    public override void Effect()
    {
        if (cdFestival > 0)
            cdFestival--;
        if (cdPublicSpeech > 0)
            cdPublicSpeech--;
        
        if(GameResources.instance.citizens - GameResources.instance.maximumCitizens < 200)
            GameResources.instance.citizens += 100;
        GameResources.instance.money += 0.01f * GameResources.instance.citizens;
        GameResources.instance.approval -= 1;
    }

    public bool canBuyFestival()
    {
        if (festivalFoodCost <= GameResources.instance.food && festivalMoneyCost <= GameResources.instance.money && cdFestival == 0)
            return true;
        return false;
    }

    public bool canBuyPublicSpeech()
    {
        if (publicSpeechMoneyCost <= GameResources.instance.money && cdPublicSpeech == 0)
            return true;
        return false;
    }

    public void buyFestival()
    {
        cdFestival = 6;
        GameResources.instance.approval += 3;
        GameResources.instance.food -= festivalFoodCost;
        GameResources.instance.money -= festivalMoneyCost;
        //GameResources.instance.money += (int)Random.Range(10f, 30f);
    }

    public void buyPublicSpeech()
    {
        cdPublicSpeech = 1;
        GameResources.instance.approval += 2;
        GameResources.instance.money -= publicSpeechMoneyCost;
    }

    public void increasedFoodRatio(int food)
    {
        GameResources.instance.food -= food;
        GameResources.instance.approval += 0.01f * food;
    }

    public override bool canBuy<building>()
    {
        building x = new building();
        if (GameResources.instance.food >= x.foodCost && GameResources.instance.money >= x.moneyCost &&
            GameResources.instance.buildingMaterials >= x.buildingMaterialsCost)
            return true;
        else
        return false;
    }
}
