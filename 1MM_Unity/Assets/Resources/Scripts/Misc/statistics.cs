using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class statistics : MonoBehaviour {


    public AResources resources;
    public int nrOfBuildings, nrOfFarms, nrOfHouses, nrOfFactories, nrOfTerritories;
    public float foodPerTurn, moneyPerTurn, materialsPerTurn, approvalDecayRate, currentApprovalDecay, buyRate, sellRate;
    public int nrOfResearches, timeUntilResearch, timeUntilFestival, timeUntilPS, timeUntilIFR;

    public Text TnrOfBuildings, TnrOfFarms, TnrOfHouses, TnrOfFactories,
        TnrOfTerritories, TfoodPerTurn, TmoneyPerTurn, TmaterialsPerTurn, TapprovalDecayRate, TcurrentApprovalDecay,
        TnrOfResearches, TtimeUntilResearch, TtimeUntilFestival, TtimeUntilPS, TtimeUntilIFR, TbuyRate, TsellRate; 

    public void updateStatistics()
    {
        nrOfBuildings = resources.currentIndex;
        nrOfFarms = resources.numberOfBuildings<Farm>();
        nrOfFactories = resources.numberOfBuildings<Factory>();
        nrOfHouses = resources.numberOfBuildings<House>();
        nrOfTerritories = resources.numberOfBuildings<FoodTerritory>() +
            resources.numberOfBuildings<MaterialsTerritory>() +
            resources.numberOfBuildings<CitizensTerritory>();

        foodPerTurn = resources.resourcePerTurn("food");
        materialsPerTurn = resources.resourcePerTurn("materials");
        moneyPerTurn = resources.resourcePerTurn("money");
        approvalDecayRate = resources.approvalDecayRate;
        currentApprovalDecay = resources.flatApproval * (resources.approvalDecayRate / 100);

        nrOfResearches = resources.researchesMade;

        if(GameObject.FindGameObjectWithTag("Laboratory"))
            timeUntilResearch = 7 - ((Laboratory)resources.buildings[GameObject.FindGameObjectWithTag("Laboratory").GetComponent<IdManager>().buildingIndex]).researchPointCount % 7;
        timeUntilFestival = ((ExecutiveBuilding)resources.buildings[GameObject.FindGameObjectWithTag("Executive").GetComponent<IdManager>().buildingIndex]).cdFestival;
        timeUntilPS = ((ExecutiveBuilding)resources.buildings[GameObject.FindGameObjectWithTag("Executive").GetComponent<IdManager>().buildingIndex]).cdPublicSpeech;
        timeUntilIFR = ((ExecutiveBuilding)resources.buildings[GameObject.FindGameObjectWithTag("Executive").GetComponent<IdManager>().buildingIndex]).cdFoodRatio;

        buyRate = resources.buyRate;
        sellRate = resources.sellRate;

        TnrOfBuildings.text = nrOfBuildings.ToString();
        TnrOfFarms.text = nrOfFarms.ToString();
        TnrOfHouses.text = nrOfHouses.ToString();
        TnrOfFactories.text = nrOfFactories.ToString();
        TnrOfTerritories.text = nrOfTerritories.ToString();
        TfoodPerTurn.text = foodPerTurn.ToString();
        TmoneyPerTurn.text = moneyPerTurn.ToString();
        TmaterialsPerTurn.text = materialsPerTurn.ToString();
        TapprovalDecayRate.text = approvalDecayRate.ToString()+"%";
        TcurrentApprovalDecay.text = currentApprovalDecay.ToString();
        TnrOfResearches.text = nrOfResearches.ToString();
        TtimeUntilResearch.text = timeUntilResearch.ToString();
        TtimeUntilFestival.text = timeUntilFestival.ToString();
        TtimeUntilPS.text = timeUntilPS.ToString();
        TtimeUntilIFR.text = timeUntilIFR.ToString();
        TbuyRate.text = buyRate.ToString()+"%";
        TsellRate.text = sellRate.ToString()+"%";
    }

    void Start()
    {
        updateStatistics();
    }
	
}
