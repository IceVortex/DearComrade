using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class buildingValues
{
    public buildingValues()
    { }

    public string buildingDescription(string building)
    {

        if(building == "House")
        {
            House x = new House();
            return x.description;
        }

        else if(building == "Farm")
        {
            Farm x = new Farm();
            return x.description;
        }

        else if(building == "Factory")
        {
            Factory x = new Factory();
            return x.description;
        }

        else if(building == "ExecutiveBuilding")
        {
            ExecutiveBuilding x = new ExecutiveBuilding();
            return x.description;
        }

        else if(building == "EducationalBuilding")
        {
            EducationalBuilding x = new EducationalBuilding();
            return x.description;
        }

        else if(building == "Hospital")
        {
            Hospital x = new Hospital();
            return x.description;
        }

        else if(building == "Laboratory")
        {
            Laboratory x = new Laboratory();
            return x.description;
        }

        else if(building == "PoliceStation")
        {
            PoliceStation x = new PoliceStation();
            return x.description;
        }

        else if (building == "Workplace")
        {
            Workplace x = new Workplace();
            return x.description;
        }

        else if(building == "PublicSpace")
        {
            PublicSpace x = new PublicSpace();
            return x.description;
        }

        else if(building == "WTC")
        {
            WTC x = new WTC();
            return x.description;
        }

        else
            return "";
    }

    public Vector3 buildingCost(string building)
    {

        if(building == "House")
        {
            return GameResources.instance.cost<House>();
        }

        else if(building == "Farm")
        {
            return GameResources.instance.cost<Farm>();
        }

        else if(building == "Factory")
        {
            return GameResources.instance.cost<Factory>();
        }

        else if(building == "ExecutiveBuilding")
        {
            return GameResources.instance.cost<ExecutiveBuilding>();
        }

        else if(building == "EducationalBuilding")
        {
            return GameResources.instance.cost<EducationalBuilding>();
        }

        else if(building == "Hospital")
        {
            return GameResources.instance.cost<Hospital>();
        }

        else if(building == "Laboratory")
        {
            return GameResources.instance.cost<Laboratory>();
        }

        else if(building == "PoliceStation")
        {
            return GameResources.instance.cost<PoliceStation>();
        }

        else if (building == "Workplace")
        {
            return GameResources.instance.cost<Workplace>();
        }

        else if(building == "PublicSpace")
        {
            return GameResources.instance.cost<PublicSpace>();
        }

        else if(building == "WTC")
        {
            return GameResources.instance.cost<WTC>();
        }

        else
            return Vector3.zero;
    }

    public int numberOf(string type)
    {
        int count = 0;
        foreach(ABuilding building in GameResources.instance.buildings)
        {
            if (building.GetType().ToString() == type)
                count++;
        }

        return count;
    }
}
