using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class statistics : MonoBehaviour {


    public AResources resources;
    public int nrOfBuildings, nrOfFarms, nrOfHouses, nrOfFactories, nrOfTerritories;
    public float foodPerTurn, moneyPerTurn, materialsPerTurn, approvalDecayRate, currentApprovalDecay;
    public int nrOfResearches, timeUntilResearch, timeUntilFestival, timeUntilPS, timeUntilIFR;

    public Text TnrOfBuildings, TnrOfFarms, TnrOfHouses, TnrOfFactories,
        TnrOfTerritories, TfoodPerTurn, TmoneyPerTurn, TmaterialsPerTurn, TapprovalDecayRate, TcurrentApprovalDecay,
        TnrOfResearches, TtimeUntilResearch, TtimeUntilFestival, TtimeUntilPS, TtimeUntilIFR; 

    public void updateStatistics()
    {
        nrOfBuildings = resources.currentIndex;
        nrOfFarms = resources.numberOfBuildings("Farm");
        nrOfFactories = resources.numberOfBuildings("Factory");
        nrOfHouses = resources.numberOfBuildings("House");
        nrOfTerritories = resources.numberOfBuildings("Food Territory") +
            resources.numberOfBuildings("Materials Territory") +
            resources.numberOfBuildings("Citizens Territory");

        foodPerTurn = resources.resourcePerTurn("food");
        materialsPerTurn = resources.resourcePerTurn("materials");
        moneyPerTurn = resources.resourcePerTurn("money");
        approvalDecayRate = resources.approvalDecayRate;
        currentApprovalDecay = resources.flatApproval * (resources.approvalDecayRate / 100);

        nrOfResearches = resources.researchesMade;

        //if(GameObject.FindGameObjectWithTag("Laboratory"))
            //timeUntilResearch = 7 - GameObject.FindGameObjectWithTag("Laboratory").GetComponent<Laboratory>().researchPointCount % 7;
        //timeUntilFestival = GameObject.FindGameObjectWithTag("Executive").GetComponent<ExecutiveBuilding>().cdFestival;
        //timeUntilPS = GameObject.FindGameObjectWithTag("Executive").GetComponent<ExecutiveBuilding>().cdPublicSpeech;
        //timeUntilIFR = GameObject.FindGameObjectWithTag("Executive").GetComponent<ExecutiveBuilding>().cdFoodRatio;

        TnrOfBuildings.text = nrOfBuildings.ToString();
        TnrOfFarms.text = nrOfFarms.ToString();
        TnrOfHouses.text = nrOfHouses.ToString();
        TnrOfFactories.text = nrOfFactories.ToString();
        TnrOfTerritories.text = nrOfTerritories.ToString();
        TfoodPerTurn.text = foodPerTurn.ToString();
        TmoneyPerTurn.text = moneyPerTurn.ToString();
        TmaterialsPerTurn.text = materialsPerTurn.ToString();
        TapprovalDecayRate.text = approvalDecayRate.ToString();
        TcurrentApprovalDecay.text = currentApprovalDecay.ToString();
        TnrOfResearches.text = nrOfResearches.ToString();
        TtimeUntilResearch.text = timeUntilResearch.ToString();
        TtimeUntilFestival.text = timeUntilFestival.ToString();
        TtimeUntilPS.text = timeUntilPS.ToString();
        TtimeUntilIFR.text = timeUntilIFR.ToString();

    }

    void Start()
    {
        updateStatistics();
    }
	
}
