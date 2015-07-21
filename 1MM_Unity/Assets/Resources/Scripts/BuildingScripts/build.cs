using UnityEngine;
using System.Collections;

public class build : MonoBehaviour {

    public GameObject prefab;
    public BuildingGeneration gen;
    public AResources resources;
	
    public void createBuilding()
    {
        if (GetComponent<canBuild>().requirementsMet)
        {
            if (GetComponent<canBuild>().buildingName == "House")
            {
                resources.createBuilding<House>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Farm")
            {
                resources.createBuilding<Farm>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Factory")
            {
                resources.createBuilding<Factory>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Hospital")
            {
                resources.createBuilding<Hospital>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "World Trade Center")
            {
                resources.createBuilding<WTC>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Laboratory")
            {
                resources.createBuilding<Laboratory>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Police Station")
            {
                resources.createBuilding<PoliceStation>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Public Space")
            {
                resources.createBuilding<PublicSpace>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Workplace")
            {
                resources.createBuilding<Workplace>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Educational Building")
            {
                resources.createBuilding<EducationalBuilding>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().buildingName == "Military Outpost")
            {
                resources.createBuilding<MilitaryOutpost>(prefab, gen.generate());
            }
        }
    }

    
}
