using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class canBuild : MonoBehaviour {

    public CanvasGroup overlay;
    public bool requirementsMet;
    public string buildingName;

    public Text bName, details;

    void Start()
    {
        details.text = "Cost: ";
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
