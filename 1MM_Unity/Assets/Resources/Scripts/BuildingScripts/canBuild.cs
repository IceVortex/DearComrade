using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class canBuild : MonoBehaviour {

    public CanvasGroup overlay;
    public bool requirementsMet;
    public string buildingName;
    public Vector3 costs;
    public Text bName, details;
    public buildingValues buildingValues = new buildingValues();


    void Start()
    {
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
            if (GameResources.instance.canBuy<House>())
                requirementsMet = true;
        }

        if (buildingName == "Farm")
        {
            if (GameResources.instance.canBuy<Farm>())
                requirementsMet = true;
        }
        if (buildingName == "Factory")
        {
            if (GameResources.instance.canBuy<Factory>())
                requirementsMet = true;
        }
        if (buildingName == "Hospital")
        {
            if (GameResources.instance.canBuy<Hospital>() && buildingValues.numberOf(buildingName)<1)
                requirementsMet = true;
        }
        if (buildingName == "World Trade Center")
        {
            if (GameResources.instance.canBuy<WTC>() && buildingValues.numberOf(buildingName) < 1)
                requirementsMet = true;
        }
        if (buildingName == "Laboratory")
        {
            if (GameResources.instance.canBuy<Laboratory>() && buildingValues.numberOf(buildingName) < 1)
                requirementsMet = true;
        }
        if (buildingName == "Police Station")
        {
            if (GameResources.instance.canBuy<PoliceStation>() && buildingValues.numberOf(buildingName) < 1)
                requirementsMet = true;
        }
        if (buildingName == "Public Space")
        {
            if (GameResources.instance.canBuy<PublicSpace>() && buildingValues.numberOf(buildingName) < 1)
                requirementsMet = true;
        }
        if (buildingName == "Workplace")
        {
            if (GameResources.instance.canBuy<Workplace>() && buildingValues.numberOf(buildingName) < 1)
                requirementsMet = true;
        }
        if (buildingName == "Educational Building")
        {
            if (GameResources.instance.canBuy<EducationalBuilding>() && buildingValues.numberOf(buildingName) < 1)
                requirementsMet = true;
        }
        if (buildingName == "Military Outpost")
        {
            if (GameResources.instance.canBuy<MilitaryOutpost>() && buildingValues.numberOf(buildingName) < 1)
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
