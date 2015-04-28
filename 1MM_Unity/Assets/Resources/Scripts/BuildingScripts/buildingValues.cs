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

        else if (building == "Military Outpost")
        {
            MilitaryOutpost x = new MilitaryOutpost();
            return x.name;
        }

        else if(building == "Food Territory")
        {
            FoodTerritory x = new FoodTerritory();
            return x.name;
        }

        else if (building == "Materials Territory")
        {
            MaterialsTerritory x = new MaterialsTerritory();
            return x.name;
        }

        else if (building == "Citizens Territory")
        {
            CitizensTerritory x = new CitizensTerritory();
            return x.name;
        }

        else
            return "";
    }

    public string buildingShortDescription(string building)
    {
        if (building == "Executive Building")
        {
            ExecutiveBuilding x = new ExecutiveBuilding();
            return x.shortDescription;
        }

        if(building == "House")
        {
            House x = new House();
            return x.shortDescription;
        }

        else if(building == "Farm")
        {
            Farm x = new Farm();
            return x.shortDescription;
        }

        else if(building == "Factory")
        {
            Factory x = new Factory();
            return x.shortDescription;
        }

        else if(building == "Executive Building")
        {
            ExecutiveBuilding x = new ExecutiveBuilding();
            return x.shortDescription;
        }

        else if(building == "Educational Building")
        {
            EducationalBuilding x = new EducationalBuilding();
            return x.shortDescription;
        }

        else if(building == "Hospital")
        {
            Hospital x = new Hospital();
            return x.shortDescription;
        }

        else if(building == "Laboratory")
        {
            Laboratory x = new Laboratory();
            return x.shortDescription;
        }

        else if(building == "Police Station")
        {
            PoliceStation x = new PoliceStation();
            return x.shortDescription;
        }

        else if (building == "Workplace")
        {
            Workplace x = new Workplace();
            return x.shortDescription;
        }

        else if(building == "Public Space")
        {
            PublicSpace x = new PublicSpace();
            return x.shortDescription;
        }

        else if(building == "World Trade Center")
        {
            WTC x = new WTC();
            return x.shortDescription;
        }

        else if (building == "Military Outpost")
        {
            MilitaryOutpost x = new MilitaryOutpost();
            return x.shortDescription;
        }

        else if (building == "Food Territory")
        {
            FoodTerritory x = new FoodTerritory();
            return x.shortDescription;
        }

        else if (building == "Materials Territory")
        {
            MaterialsTerritory x = new MaterialsTerritory();
            return x.shortDescription;
        }

        else if (building == "Citizens Territory")
        {
            CitizensTerritory x = new CitizensTerritory();
            return x.shortDescription;
        }

        else
            return "";
    }

    public string buildingLongDescription(string building)
    {

        if (building == "House")
        {
            House x = new House();
            return x.longDescription;
        }

        else if (building == "Farm")
        {
            Farm x = new Farm();
            return x.longDescription;
        }

        else if (building == "Factory")
        {
            Factory x = new Factory();
            return x.longDescription;
        }

        else if (building == "Executive Building")
        {
            ExecutiveBuilding x = new ExecutiveBuilding();
            return x.longDescription;
        }

        else if (building == "Educational Building")
        {
            EducationalBuilding x = new EducationalBuilding();
            return x.longDescription;
        }

        else if (building == "Hospital")
        {
            Hospital x = new Hospital();
            return x.longDescription;
        }

        else if (building == "Laboratory")
        {
            Laboratory x = new Laboratory();
            return x.longDescription;
        }

        else if (building == "Police Station")
        {
            PoliceStation x = new PoliceStation();
            return x.longDescription;
        }

        else if (building == "Workplace")
        {
            Workplace x = new Workplace();
            return x.longDescription;
        }

        else if (building == "Public Space")
        {
            PublicSpace x = new PublicSpace();
            return x.longDescription;
        }

        else if (building == "World Trade Center")
        {
            WTC x = new WTC();
            return x.longDescription;
        }

        else if (building == "Military Outpost")
        {
            MilitaryOutpost x = new MilitaryOutpost();
            return x.longDescription;
        }


        else if (building == "Food Territory")
        {
            FoodTerritory x = new FoodTerritory();
            return x.longDescription;
        }

        else if (building == "Materials Territory")
        {
            MaterialsTerritory x = new MaterialsTerritory();
            return x.longDescription;
        }

        else if (building == "Citizens Territory")
        {
            CitizensTerritory x = new CitizensTerritory();
            return x.longDescription;
        }

        else
            return "";
    }

    public string buildingFlavorText(string building)
    {

        if (building == "House")
        {
            House x = new House();
            return x.flavorText;
        }

        else if (building == "Farm")
        {
            Farm x = new Farm();
            return x.flavorText;
        }

        else if (building == "Factory")
        {
            Factory x = new Factory();
            return x.flavorText;
        }

        else if (building == "Executive Building")
        {
            ExecutiveBuilding x = new ExecutiveBuilding();
            return x.flavorText;
        }

        else if (building == "Educational Building")
        {
            EducationalBuilding x = new EducationalBuilding();
            return x.flavorText;
        }

        else if (building == "Hospital")
        {
            Hospital x = new Hospital();
            return x.flavorText;
        }

        else if (building == "Laboratory")
        {
            Laboratory x = new Laboratory();
            return x.flavorText;
        }

        else if (building == "Police Station")
        {
            PoliceStation x = new PoliceStation();
            return x.flavorText;
        }

        else if (building == "Workplace")
        {
            Workplace x = new Workplace();
            return x.flavorText;
        }

        else if (building == "Public Space")
        {
            PublicSpace x = new PublicSpace();
            return x.flavorText;
        }

        else if (building == "World Trade Center")
        {
            WTC x = new WTC();
            return x.flavorText;
        }

        else if (building == "Military Outpost")
        {
            MilitaryOutpost x = new MilitaryOutpost();
            return x.flavorText;
        }


        else if (building == "Food Territory")
        {
            FoodTerritory x = new FoodTerritory();
            return x.flavorText;
        }

        else if (building == "Materials Territory")
        {
            MaterialsTerritory x = new MaterialsTerritory();
            return x.flavorText;
        }

        else if (building == "Citizens Territory")
        {
            CitizensTerritory x = new CitizensTerritory();
            return x.flavorText;
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

        else if (building == "Military Outpost")
        {
            return GameResources.instance.cost<MilitaryOutpost>();
        }

        else
            return Vector3.zero;
    }

    public int numberOf(string n)
    {
        int count = 0;
        foreach(ABuilding building in GameResources.instance.buildings)
        {
            if (building.name == n)
                count++;
        }

        return count;
    }
}
