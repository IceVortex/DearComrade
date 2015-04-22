using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class canBuild : MonoBehaviour {

    public CanvasGroup overlay;
    public bool requirementsMet;
    public string buildingName;
    public Vector3 costs;
    public Text bName, details;

    void Start()
    {
        if (buildingName == "House")
        {
            costs = GameResources.instance.cost<House>();
        }
        if (buildingName == "Farm")
        {
            costs = GameResources.instance.cost<Farm>();
        }
        if (buildingName == "Factory")
        {
            costs = GameResources.instance.cost<Factory>();
        }
        if (buildingName == "Hospital")
        {
            costs = GameResources.instance.cost<Hospital>();
        }
        if (buildingName == "WTC")
        {
            costs = GameResources.instance.cost<WTC>();
        }
        if (buildingName == "Laboratory")
        {
            costs = GameResources.instance.cost<Laboratory>();
        }
        if (buildingName == "Police Station")
        {
            costs = GameResources.instance.cost<PoliceStation>();
        }
        if (buildingName == "Public Space")
        {
            costs = GameResources.instance.cost<PublicSpace>();
        }
        if (buildingName == "Workplace")
        {
            costs = GameResources.instance.cost<Workplace>();
        }
        if (buildingName == "Educational Building")
        {
            costs = GameResources.instance.cost<EducationalBuilding>();
        }

        if (costs.x != 0)
        {
            details.text = "Costs: Food - " + costs.x.ToString() + " Materials - " + costs.y.ToString() + " Money - " + costs.z.ToString() + "\n";
        }
        else
            details.text = "Costs: Materials - " + costs.y.ToString() + " Money - " + costs.z.ToString();

    }

	void Update () {

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
            if (GameResources.instance.canBuy<Hospital>())
                requirementsMet = true;
        }
        if (buildingName == "WTC")
        {
            if (GameResources.instance.canBuy<WTC>())
                requirementsMet = true;
        }
        if (buildingName == "Laboratory")
        {
            if (GameResources.instance.canBuy<Laboratory>())
                requirementsMet = true;
        }
        if (buildingName == "Police Station")
        {
            if (GameResources.instance.canBuy<PoliceStation>())
                requirementsMet = true;
        }
        if (buildingName == "Public Space")
        {
            if (GameResources.instance.canBuy<PublicSpace>())
                requirementsMet = true;
        }
        if (buildingName == "Workplace")
        {
            if (GameResources.instance.canBuy<Workplace>())
                requirementsMet = true;
        }
        if (buildingName == "Educational Building")
        {
            if (GameResources.instance.canBuy<EducationalBuilding>())
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
