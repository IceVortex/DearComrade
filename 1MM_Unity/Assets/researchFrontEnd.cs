using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class researchFrontEnd : MonoBehaviour {

    public CanvasGroup alreadyResearched, researchButton;
    public Text researchName, description, costs;
    public int researchNumber;
    public researchOverview ro;

    public void research()
    {
        bool ok = false;
        if (ro.lab.titles[researchNumber] == "Fertility")
        {
            if (GameResources.instance.buildingMaterials >= ro.lab.fertilityMaterialsCost && GameResources.instance.food >= ro.lab.fertilityFoodCost && GameResources.instance.money >= ro.lab.fertilityMoneyCost)
            {
                ro.lab.researchFertility();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Industrial Revolution")
        {
            if (GameResources.instance.buildingMaterials >= ro.lab.industrialRevolutionMaterialsCost && GameResources.instance.food >= ro.lab.industrialRevolutionFoodCost && GameResources.instance.money >= ro.lab.industrialRevolutionMoneyCost)
            {
                ro.lab.researchIndustrialRevolution();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Space Conservation")
        {
            if (GameResources.instance.buildingMaterials >= ro.lab.spaceConservationMaterialsCost && GameResources.instance.food >= ro.lab.spaceConservationFoodCost && GameResources.instance.money >= ro.lab.spaceConservationMoneyCost)
            {
                ro.lab.researchSpaceConservation();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "The Proletariat")
        {
            if (GameResources.instance.buildingMaterials >= ro.lab.theProletariatMaterialsCost && GameResources.instance.food >= ro.lab.theProletariatFoodCost && GameResources.instance.money >= ro.lab.theProletariatMoneyCost)
            {
                ro.lab.researchTheProletariat();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Nanocarbon Materials")
        {
            if (GameResources.instance.buildingMaterials >= ro.lab.nanocarbonMaterialsMaterialsCost && GameResources.instance.food >= ro.lab.nanocarbonMaterialsFoodCost && GameResources.instance.money >= ro.lab.nanocarbonMaterialsMoneyCost)
            {
                ro.lab.researchNanocarbonMaterials();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Bargaining")
        {
            if (GameResources.instance.buildingMaterials >= ro.lab.bargainingMaterialsCost && GameResources.instance.food >= ro.lab.bargainingFoodCost && GameResources.instance.money >= ro.lab.bargainingMoneyCost)
            {
                ro.lab.researchBargaining();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Shelters")
        {
            if (GameResources.instance.buildingMaterials >= ro.lab.improvedSheltersMaterialsCost && GameResources.instance.food >= ro.lab.improvedSheltersFoodCost && GameResources.instance.money >= ro.lab.improvedSheltersMoneyCost)
            {
                ro.lab.researchShelters();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Social Gatherings")
        {
            if (GameResources.instance.buildingMaterials >= ro.lab.socialGatheringsMaterialsCost && GameResources.instance.food >= ro.lab.socialGatheringsFoodCost && GameResources.instance.money >= ro.lab.socialGatheringsMoneyCost)
            { 
                ro.lab.researchSocialGatherings();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Oratory")
        {
            if (GameResources.instance.buildingMaterials >= ro.lab.oratoryMaterialsCost && GameResources.instance.food >= ro.lab.oratoryFoodCost && GameResources.instance.money >= ro.lab.oratoryMoneyCost)
            {
                ro.lab.researchOratory();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Food Feast")
        {
            if (GameResources.instance.buildingMaterials >= ro.lab.foodFeastMaterialsCost && GameResources.instance.food >= ro.lab.foodFeastFoodCost && GameResources.instance.money >= ro.lab.foodFeastMoneyCost)
            {
                ro.lab.researchFoodFeast();
                ok = true;
            }
        }

        if(ok)
        { 
            alreadyResearched.alpha = 1;
            alreadyResearched.interactable = true;
            alreadyResearched.blocksRaycasts = true;

            researchButton.alpha = 0;
            researchButton.interactable = false;
            alreadyResearched.blocksRaycasts = false;
        }
     
    }

    void Start()
    {
        int.TryParse(gameObject.name, out researchNumber);
        ro = GetComponentInParent<researchOverview>();

    }

    void Update()
    {
        if (ro.foundLab)
        {
            researchName.text = ro.lab.titles[researchNumber];
            description.text = ro.lab.descriptions[researchNumber];
            costs.text = "Costs: " + ro.lab.costs[researchNumber].x + " Food, " + ro.lab.costs[researchNumber].y + " Money, " + ro.lab.costs[researchNumber].z + " Materials.";
        }
    }
    
}
