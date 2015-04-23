using UnityEngine;
using System.Collections;

public class build : MonoBehaviour {

    public GameObject prefab;
    public testBuildingGeneration gen;
	
    public void createBuilding()
    {
        if (GetComponent<canBuild>().requirementsMet)
        {
            if (GetComponent<canBuild>().buildingName == "House")
            {
                GameResources.instance.createBuilding<House>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Farm")
            {
                GameResources.instance.createBuilding<Farm>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Factory")
            {
                GameResources.instance.createBuilding<Factory>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Hospital")
            {
                GameResources.instance.createBuilding<Hospital>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "WTC")
            {
                GameResources.instance.createBuilding<WTC>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Laboratory")
            {
                GameResources.instance.createBuilding<Laboratory>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "PoliceStation")
            {
                GameResources.instance.createBuilding<PoliceStation>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "PublicSpace")
            {
                print("stuff");
                GameResources.instance.createBuilding<PublicSpace>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Workplace")
            {
                GameResources.instance.createBuilding<Workplace>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "EducationalBuilding")
            {
                GameResources.instance.createBuilding<EducationalBuilding>(prefab, gen.generate());
            }
        }
    }

    
}
