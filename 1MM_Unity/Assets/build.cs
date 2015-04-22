using UnityEngine;
using System.Collections;

public class build : MonoBehaviour {

    public GameObject prefab;
    public testBuildingGeneration gen;
	
    public void createBuilding()
    {
        if (GetComponent<canBuild>().requirementsMet)
        {
            if (GetComponent<canBuild>().name == "House")
            {
                GameResources.instance.createBuilding<House>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().name == "Farm")
            {
                GameResources.instance.createBuilding<Farm>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().name == "Factory")
            {
                GameResources.instance.createBuilding<Factory>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().name == "Hospital")
            {
                GameResources.instance.createBuilding<Hospital>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().name == "WTC")
            {
                GameResources.instance.createBuilding<WTC>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().name == "Laboratory")
            {
                GameResources.instance.createBuilding<Laboratory>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().name == "Police Station")
            {
                GameResources.instance.createBuilding<PoliceStation>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().name == "Public Space")
            {
                GameResources.instance.createBuilding<PublicSpace>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().name == "Workplace")
            {
                GameResources.instance.createBuilding<Workplace>(prefab, gen.generate());
            }
            if (GetComponent<canBuild>().name == "Educational Building")
            {
                GameResources.instance.createBuilding<EducationalBuilding>(prefab, gen.generate());
            }
        }
    }

    
}
