using UnityEngine;
using System.Collections;

public class ExecutiveBuilding : ABuilding
{
    public int taxes = 1, cdFestival = 0, cdPublicSpeech = 0;
    private int festivalFoodCost = 100, festivalMoneyCost = 75;
    private int publicSpeechMoneyCost = 75;
    private int numberOfCitizens = 400;
    public float goldPerTurn;

    public ExecutiveBuilding()
    {
        name = "Executive Building";
        description = "mutherfuckin' EB";
        foodCost = 0;
        moneyCost = 0;
        buildingMaterialsCost = 0;
        goldPerTurn = 0.01f;
    }

    public override void Initialize(int i)
    {
        base.Initialize(i);
        GameResources.instance.maximumCitizens = numberOfCitizens;
    }

    public override void Effect()
    {
        if (cdFestival > 0)
            cdFestival--;
        if (cdPublicSpeech > 0)
            cdPublicSpeech--;
        
        if(GameResources.instance.citizens - GameResources.instance.maximumCitizens < GameResources.instance.maxHomelessCitizens)
            GameResources.instance.citizens += 100;
        GameResources.instance.money += goldPerTurn * GameResources.instance.citizens;
        GameResources.instance.approval -= 1;
    }

    public bool canBuyFestival()
    {
        if (festivalFoodCost * (GameResources.instance.triggeredEventCostRate / 100) <= GameResources.instance.food &&
            festivalMoneyCost * (GameResources.instance.triggeredEventCostRate / 100) <= GameResources.instance.money && 
            cdFestival == 0)
            return true;
        return false;
    }

    public bool canBuyPublicSpeech()
    {
        if (publicSpeechMoneyCost * (GameResources.instance.triggeredEventCostRate / 100) <= GameResources.instance.money && 
            cdPublicSpeech == 0)
            return true;
        return false;
    }

    public void buyFestival()
    {
        cdFestival = 6;
        GameResources.instance.approval += GameResources.instance.festivalApproval;
        GameResources.instance.food -= festivalFoodCost * (GameResources.instance.triggeredEventCostRate / 100);
        GameResources.instance.money -= festivalMoneyCost * (GameResources.instance.triggeredEventCostRate / 100);
        //GameResources.instance.money += (int)Random.Range(10f, 30f);
    }

    public void buyPublicSpeech()
    {
        cdPublicSpeech = 1;
        GameResources.instance.approval += GameResources.instance.publichSpeechApproval;
        GameResources.instance.money -= publicSpeechMoneyCost * (GameResources.instance.triggeredEventCostRate / 100);
    }

    public void increasedFoodRatio(int food)
    {
        GameResources.instance.food -= food;
        GameResources.instance.approval += GameResources.instance.foodRatioApproval * food;
    }

}
