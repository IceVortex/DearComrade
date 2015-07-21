using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class canBuild : MonoBehaviour {

    public CanvasGroup overlay;
    public bool requirementsMet;
    public string buildingName;
    public Vector3 costs;
    public Text bName, details;
    public AResources resources;
    public buildingValues buildingValues = new buildingValues();

    void Start()
    {
        buildingValues.res(resources);
        costs = buildingValues.buildingCost(buildingName);
    }


	void Update () {
        costs = buildingValues.buildingCost(buildingName);
        if (costs.x != 0)
        {
            details.text = "Costs: Food - " + costs.x.ToString() + " Materials - " + costs.y.ToString() + " Money - " + costs.z.ToString() + "\n" + "Owned amount: " + buildingValues.numberOf(buildingName).ToString() + "\n" + buildingValues.buildingShortDescription(buildingName);
        }
        else
            details.text = "Costs: Materials - " + costs.y.ToString() + " Money - " + costs.z.ToString() + "\n" + "Owned amount: " + buildingValues.numberOf(buildingName).ToString() + "\n" + buildingValues.buildingShortDescription(buildingName);


        requirementsMet = false;

        if (buildingName == "House")
        {
            if (resources.canBuy<House>())
                requirementsMet = true;
        }

        if (buildingName == "Farm")
        {
            if (resources.canBuy<Farm>())
                requirementsMet = true;
        }
        if (buildingName == "Factory")
        {
            if (resources.canBuy<Factory>())
                requirementsMet = true;
        }
        if (buildingName == "Hospital")
        {
            if (resources.canBuy<Hospital>() && buildingValues.numberOf(buildingName) < 1)
                requirementsMet = true;
        }
        if (buildingName == "World Trade Center")
        {
            if (resources.canBuy<WTC>() && buildingValues.numberOf(buildingName) < 1)
                requirementsMet = true;
        }
        if (buildingName == "Laboratory")
        {
            if (resources.canBuy<Laboratory>() && buildingValues.numberOf(buildingName) < 1)
                requirementsMet = true;
        }
        if (buildingName == "Police Station")
        {
            if (resources.canBuy<PoliceStation>() && buildingValues.numberOf(buildingName) < 1)
                requirementsMet = true;
        }
        if (buildingName == "Public Space")
        {
            if (resources.canBuy<PublicSpace>() && buildingValues.numberOf(buildingName) < 1)
                requirementsMet = true;
        }
        if (buildingName == "Workplace")
        {
            if (resources.canBuy<Workplace>() && buildingValues.numberOf(buildingName) < 1)
                requirementsMet = true;
        }
        if (buildingName == "Educational Building")
        {
            if (resources.canBuy<EducationalBuilding>() && buildingValues.numberOf(buildingName) < 1)
                requirementsMet = true;
        }
        if (buildingName == "Military Outpost")
        {
            if (resources.canBuy<MilitaryOutpost>() && buildingValues.numberOf(buildingName) < 1)
                requirementsMet = true;
        }


        if (requirementsMet)
        {
            overlay.alpha = 0;
            overlay.interactable = false;
            overlay.blocksRaycasts = false;
        }
        else
        {
            overlay.alpha = 1;
            overlay.interactable = true;
            overlay.blocksRaycasts = true;
        }

	}
}
