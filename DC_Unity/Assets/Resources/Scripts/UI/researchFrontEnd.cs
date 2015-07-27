using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class researchFrontEnd : MonoBehaviour {

    public CanvasGroup alreadyResearched, researchButton;
    public Text researchName, description, costs;
    public int researchNumber;
    public researchOverview ro;
    public AResources resources;

    public void research()
    {
        bool ok = false;
        if (ro.lab.titles[researchNumber] == "Fertility")
        {
            if (resources.researchPoints >= 1)
            {
                ro.lab.researchFertility();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Industrial Revolution")
        {
            if (resources.researchPoints >= 1)
            {
                ro.lab.researchIndustrialRevolution();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Space Conservation")
        {
            if (resources.researchPoints >= 1)
            {
                ro.lab.researchSpaceConservation();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "The Proletariat")
        {
            if (resources.researchPoints >= 1)
            {
                ro.lab.researchTheProletariat();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Nanocarbon Materials")
        {
            if (resources.researchPoints >= 1)
            {
                ro.lab.researchNanocarbonMaterials();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Bargaining")
        {
            if (resources.researchPoints >= 1)
            {
                ro.lab.researchBargaining();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Shelters")
        {
            if (resources.researchPoints >= 1)
            {
                ro.lab.researchShelters();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Social Gatherings")
        {
            if (resources.researchPoints >= 1)
            { 
                ro.lab.researchSocialGatherings();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Oratory")
        {
            if (resources.researchPoints >= 1)
            {
                ro.lab.researchOratory();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Food Feast")
        {
            if (resources.researchPoints >= 1)
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

    #region Old Research
    /*public void research()
    {
        bool ok = false;
        if (ro.lab.titles[researchNumber] == "Fertility")
        {
            if (resources.buildingMaterials >= ro.lab.fertilityMaterialsCost && resources.food >= ro.lab.fertilityFoodCost && resources.money >= ro.lab.fertilityMoneyCost)
            {
                ro.lab.researchFertility();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Industrial Revolution")
        {
            if (resources.buildingMaterials >= ro.lab.industrialRevolutionMaterialsCost && resources.food >= ro.lab.industrialRevolutionFoodCost && resources.money >= ro.lab.industrialRevolutionMoneyCost)
            {
                ro.lab.researchIndustrialRevolution();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Space Conservation")
        {
            if (resources.buildingMaterials >= ro.lab.spaceConservationMaterialsCost && resources.food >= ro.lab.spaceConservationFoodCost && resources.money >= ro.lab.spaceConservationMoneyCost)
            {
                ro.lab.researchSpaceConservation();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "The Proletariat")
        {
            if (resources.buildingMaterials >= ro.lab.theProletariatMaterialsCost && resources.food >= ro.lab.theProletariatFoodCost && resources.money >= ro.lab.theProletariatMoneyCost)
            {
                ro.lab.researchTheProletariat();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Nanocarbon Materials")
        {
            if (resources.buildingMaterials >= ro.lab.nanocarbonMaterialsMaterialsCost && resources.food >= ro.lab.nanocarbonMaterialsFoodCost && resources.money >= ro.lab.nanocarbonMaterialsMoneyCost)
            {
                ro.lab.researchNanocarbonMaterials();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Bargaining")
        {
            if (resources.buildingMaterials >= ro.lab.bargainingMaterialsCost && resources.food >= ro.lab.bargainingFoodCost && resources.money >= ro.lab.bargainingMoneyCost)
            {
                ro.lab.researchBargaining();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Shelters")
        {
            if (resources.buildingMaterials >= ro.lab.improvedSheltersMaterialsCost && resources.food >= ro.lab.improvedSheltersFoodCost && resources.money >= ro.lab.improvedSheltersMoneyCost)
            {
                ro.lab.researchShelters();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Social Gatherings")
        {
            if (resources.buildingMaterials >= ro.lab.socialGatheringsMaterialsCost && resources.food >= ro.lab.socialGatheringsFoodCost && resources.money >= ro.lab.socialGatheringsMoneyCost)
            {
                ro.lab.researchSocialGatherings();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Oratory")
        {
            if (resources.buildingMaterials >= ro.lab.oratoryMaterialsCost && resources.food >= ro.lab.oratoryFoodCost && resources.money >= ro.lab.oratoryMoneyCost)
            {
                ro.lab.researchOratory();
                ok = true;
            }
        }
        if (ro.lab.titles[researchNumber] == "Food Feast")
        {
            if (resources.buildingMaterials >= ro.lab.foodFeastMaterialsCost && resources.food >= ro.lab.foodFeastFoodCost && resources.money >= ro.lab.foodFeastMoneyCost)
            {
                ro.lab.researchFoodFeast();
                ok = true;
            }
        }

        if (ok)
        {
            alreadyResearched.alpha = 1;
            alreadyResearched.interactable = true;
            alreadyResearched.blocksRaycasts = true;

            researchButton.alpha = 0;
            researchButton.interactable = false;
            alreadyResearched.blocksRaycasts = false;
        }

    }*/
    #endregion

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
            //costs.text = "Costs: " + ro.lab.costs[researchNumber].x + " Food, " + ro.lab.costs[researchNumber].y + " Money, " + ro.lab.costs[researchNumber].z + " Materials.";
        }
    }
    
}
