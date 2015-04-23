using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class buildingValues
{
    public buildingValues()
    { }

    public string buildingName(string building)
    {
        if (building == "Executive Building")
        {
            ExecutiveBuilding x = new ExecutiveBuilding();
            return x.name;
        }

        if (building == "House")
        {
            House x = new House();
            return x.name;
        }

        else if (building == "Farm")
        {
            Farm x = new Farm();
            return x.name;
        }

        else if (building == "Factory")
        {
            Factory x = new Factory();
            return x.name;
        }

        else if (building == "Executive Building")
        {
            ExecutiveBuilding x = new ExecutiveBuilding();
            return x.name;
        }

        else if (building == "Educational Building")
        {
            EducationalBuilding x = new EducationalBuilding();
            return x.name;
        }

        else if (building == "Hospital")
        {
            Hospital x = new Hospital();
            return x.name;
        }

        else if (building == "Laboratory")
        {
            Laboratory x = new Laboratory();
            return x.name;
        }

        else if (building == "Police Station")
        {
            PoliceStation x = new PoliceStation();
            return x.name;
        }

        else if (building == "Workplace")
        {
            Workplace x = new Workplace();
            return x.name;
        }

        else if (building == "Public Space")
        {
            PublicSpace x = new PublicSpace();
            return x.name;
        }

        else if (building == "World Trade Center")
        {
            WTC x = new WTC();
            return x.name;
        }

        else
            return "";
    }

    public string buildingDescription(string building)
    {
        if (building == "Executive Building")
        {
            ExecutiveBuilding x = new ExecutiveBuilding();
            return x.description;
        }

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

        else if(building == "Executive Building")
        {
            ExecutiveBuilding x = new ExecutiveBuilding();
            return x.description;
        }

        else if(building == "Educational Building")
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

        else if(building == "Police Station")
        {
            PoliceStation x = new PoliceStation();
            return x.description;
        }

        else if (building == "Workplace")
        {
            Workplace x = new Workplace();
            return x.description;
        }

        else if(building == "Public Space")
        {
            PublicSpace x = new PublicSpace();
            return x.description;
        }

        else if(building == "World Trade Center")
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

        else if(building == "Executive Building")
        {
            return GameResources.instance.cost<ExecutiveBuilding>();
        }

        else if(building == "Educational Building")
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

        else if(building == "Police Station")
        {
            return GameResources.instance.cost<PoliceStation>();
        }

        else if (building == "Workplace")
        {
            return GameResources.instance.cost<Workplace>();
        }

        else if(building == "Public Space")
        {
            return GameResources.instance.cost<PublicSpace>();
        }

        else if(building == "World Trade Center")
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
