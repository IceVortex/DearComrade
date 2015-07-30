using UnityEngine;
using System.Collections;

public class ExecutiveBuilding : ABuilding
{
    public int cdFestival = 8, cdPublicSpeech = 8, cdFoodRatio = 3;
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

    public override void Initialize(int i, AResources resource)
    {
        base.Initialize(i, resource);
        res.maximumCitizens = numberOfCitizens;
    }

    public override void Effect()
    {
        if (cdFestival > 0)
            cdFestival--;
        if (cdPublicSpeech > 0)
            cdPublicSpeech--;
        if (cdFoodRatio > 0)
            cdFoodRatio--;

        res.money += res.goldPerTurn * res.citizens * (res.taxRate / 100);

        if(res is PlayerResources)
            LoggingSystem.Instance.moneyGained += res.goldPerTurn * res.citizens * (res.taxRate / 100);

        if (res.citizens - res.maximumCitizens < res.maxHomelessCitizens)
            res.citizens += res.numberOfCitizensPerTurn;

        res.approval -= res.flatApproval * (res.approvalDecayRate / 100);

        //Log the citizens, money and approval gained/lost

        if (res is PlayerResources)
        {
            LoggingSystem.Instance.citizensGained += 100;
            LoggingSystem.Instance.baseApprovalLost = res.flatApproval * (res.approvalDecayRate / 100);
        }

        res.flatApproval += res.flatApprovalDecayIncreasePerTurn;
    }

    public bool canBuyFoodRatio()
    {
        if (res.food >= 100 && cdFoodRatio == 0)
            return true;
        return false;
    }

    public bool canBuyFestival()
    {
        if (festivalFoodCost * (res.triggeredEventCostRate / 100) <= res.food &&
            festivalMoneyCost * (res.triggeredEventCostRate / 100) <= res.money && 
            cdFestival == 0)
            return true;
        return false;
    }

    public bool canBuyPublicSpeech()
    {
        if (publicSpeecFoodCost * (res.triggeredEventCostRate / 100) <= res.food &&
            publicSpeechMoneyCost * (res.triggeredEventCostRate / 100) <= res.money && 
            cdPublicSpeech == 0)
            return true;
        return false;
    }

    public void buyFestival()
    {
        cdFestival = 8;
        res.approval += res.festivalApproval;
        res.food -= festivalFoodCost * (res.triggeredEventCostRate / 100);
        res.money -= festivalMoneyCost * (res.triggeredEventCostRate / 100);
    }

    public void buyPublicSpeech()
    {
        cdPublicSpeech = 8;
        res.approval += res.publichSpeechApproval;
        res.food -= publicSpeecFoodCost * (res.triggeredEventCostRate / 100);
        res.money -= publicSpeechMoneyCost * (res.triggeredEventCostRate / 100);
    }

    public void increasedFoodRatio(int food)
    {
        cdFoodRatio = 3;
        res.food -= food;
        res.approval += res.foodRatioApproval * food;
    }

}
