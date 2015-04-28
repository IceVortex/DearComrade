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
            if (GetComponent<canBuild>().buildingName == "World Trade Center")
            {
                GameResources.instance.createBuilding<WTC>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Laboratory")
            {
                GameResources.instance.createBuilding<Laboratory>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Police Station")
            {
                GameResources.instance.createBuilding<PoliceStation>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Public Space")
            {
                GameResources.instance.createBuilding<PublicSpace>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Workplace")
            {
                GameResources.instance.createBuilding<Workplace>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Educational Building")
            {
                GameResources.instance.createBuilding<EducationalBuilding>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Military Outpost")
            {
                GameResources.instance.createBuilding<MilitaryOutpost>(prefab, gen.generate());
            }
        }
    }

    
}
