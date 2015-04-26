using UnityEngine;
using System.Collections;

public class ExecutiveBuilding : ABuilding
{
    public int cdFestival = 0, cdPublicSpeech = 0;
    private int festivalFoodCost = 250, festivalMoneyCost = 200;
    private int publicSpeecFoodCost = 250, publicSpeechMoneyCost = 200;
    private int numberOfCitizens = 400;

    public ExecutiveBuilding()
    {
        name = "Executive Building";
        shortDescription = "The Executive Building is your command center. From here you can construct other buildings, manage your taxes and organise different types of events.";
        longDescription = "The Executive Building is your command center. From here you can construct other buildings, manage your taxes and organise different types of events.";
        flavorText = "All your base are belong to us.";
        foodCost = 0;
        moneyCost = 0;
        buildingMaterialsCost = 0;
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
        
        GameResources.instance.money += GameResources.instance.goldPerTurn * GameResources.instance.citizens * (GameResources.instance.taxRate / 100);
        LoggingSystem.Instance.moneyGained += GameResources.instance.goldPerTurn * GameResources.instance.citizens * (GameResources.instance.taxRate / 100);
        if (GameResources.instance.citizens - GameResources.instance.maximumCitizens < GameResources.instance.maxHomelessCitizens)
            GameResources.instance.citizens += 100;
        GameResources.instance.approval -= GameResources.instance.flatApproval * (GameResources.instance.approvalDecayRate / 100);

        //Log the citizens, money and approval gained/lost
        
        LoggingSystem.Instance.citizensGained += 100;
        LoggingSystem.Instance.baseApprovalLost = GameResources.instance.flatApproval * (GameResources.instance.approvalDecayRate / 100);


        GameResources.instance.flatApproval += 0.1f;
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
        if (publicSpeecFoodCost * (GameResources.instance.triggeredEventCostRate / 100) <= GameResources.instance.food &&
            publicSpeechMoneyCost * (GameResources.instance.triggeredEventCostRate / 100) <= GameResources.instance.money && 
            cdPublicSpeech == 0)
            return true;
        return false;
    }

    public void buyFestival()
    {
        cdFestival = 10;
        GameResources.instance.approval += GameResources.instance.festivalApproval;
        GameResources.instance.food -= festivalFoodCost * (GameResources.instance.triggeredEventCostRate / 100);
        GameResources.instance.money -= festivalMoneyCost * (GameResources.instance.triggeredEventCostRate / 100);
        //GameResources.instance.money += (int)Random.Range(10f, 30f);
    }

    public void buyPublicSpeech()
    {
        cdPublicSpeech = 10;
        GameResources.instance.approval += GameResources.instance.publichSpeechApproval;
        GameResources.instance.food -= publicSpeecFoodCost * (GameResources.instance.triggeredEventCostRate / 100);
        GameResources.instance.money -= publicSpeechMoneyCost * (GameResources.instance.triggeredEventCostRate / 100);
    }

    public void increasedFoodRatio(int food)
    {
        GameResources.instance.food -= food;
        GameResources.instance.approval += GameResources.instance.foodRatioApproval * food;
    }

}
