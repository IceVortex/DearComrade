using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class eventsRead : MonoBehaviour {

    XmlReader reader;
    XmlReaderSettings settings;
    public string source;
    public TextAsset text;
    public int eventNumber;
    public bool trigger;
    public AResources resources;
    public int numberOfEvents;

    public Text title, description, effect;

    [System.Serializable]
    public struct gameEvent{

        public int nr;
        public string description, n, required, resource, type;
        public int modifier;

    };

    public gameEvent thisEvent, lastEvent;

    void Awake()
    {
        settings = new XmlReaderSettings();
        settings.IgnoreWhitespace = true;
        text = (TextAsset)Resources.Load(source, typeof(TextAsset));
        reader = XmlReader.Create(new StringReader(text.text), settings);

    }

    public void getRandomEvent()
    {
        reader = XmlReader.Create(new StringReader(text.text), settings);
        int x = Random.Range(1, numberOfEvents + 1);
        getToEvent(x);
        
        if (lastEvent.type == thisEvent.type)
        {
            getRandomEvent();
        }
        else if (thisEvent.required != "none")
        {
            if (!resources.buildingConstructedCheck(thisEvent.required))
                getRandomEvent();
            else
            {
                interpretData();
                lastEvent = thisEvent;
            }
            
        }
        
        else
        {
            interpretData();
            lastEvent = thisEvent;
        }
    }

    public void getToEvent(int x)
    {
        while (reader.Read())
        {
            if (reader.Name == "nr")
            {
                break;
            }

        }

        reader.Read();

        int.TryParse(reader.Value, out eventNumber);

        if (eventNumber != x)
            getToEvent(x);
        else
        {
            readWholeEvent();
        }
    }

    void readWholeEvent()
    {
        
        while(reader.Read())
        { 
            if (reader.Name == "event" && reader.NodeType == XmlNodeType.EndElement)
            {
                trigger = false;
                break;
            }


            if (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.Name)
                {
                    case "required":
                        reader.Read();
                        thisEvent.required = reader.Value;
                        break;
                    case "name":
                        reader.Read();
                        thisEvent.n = reader.Value;
                        break;
                    case "description":
                        reader.Read();
                        thisEvent.description = reader.Value;
                        break;
                    case "resource":
                        reader.Read();
                        thisEvent.resource = reader.Value;
                        break;
                    case "type":
                        reader.Read();
                        thisEvent.type = reader.Value;
                        break;
                    case "modifier":
                        reader.Read();
                        int.TryParse(reader.Value, out thisEvent.modifier);
                        break;

                }
                
            }
        }

    }

    public void eventEffect()
    {
        if (GetComponent<eventsRead>().thisEvent.type == "stalemate" && GetComponent<eventsRead>().thisEvent.resource == "food")
        {
            if (resources is PlayerResources)
            {
                resources.food -= LoggingSystem.Instance.foodGained;
                LoggingSystem.Instance.foodGained = 0;
            }
            else
            {
                resources.food -= resources.resourcePerTurn("food");
            }
        }

        if (GetComponent<eventsRead>().thisEvent.type == "stalemate" && GetComponent<eventsRead>().thisEvent.resource == "all")
        {
            if (resources is PlayerResources)
            {
                resources.food -= LoggingSystem.Instance.foodGained;
                resources.buildingMaterials -= LoggingSystem.Instance.materialsGained;
                resources.money -= LoggingSystem.Instance.moneyGained;
                LoggingSystem.Instance.foodGained = 0;
                LoggingSystem.Instance.materialsGained = 0;
                LoggingSystem.Instance.moneyGained = 0;
            }
            else
            {
                resources.food -= resources.resourcePerTurn("food");
                resources.buildingMaterials -= resources.resourcePerTurn("materials");
                resources.money -= resources.resourcePerTurn("money");
            }
        }

        if (GetComponent<eventsRead>().thisEvent.type == "halved")
        {
            if (resources is PlayerResources)
            {
                resources.food -= LoggingSystem.Instance.foodGained / 2;
                LoggingSystem.Instance.foodGained = LoggingSystem.Instance.foodGained / 2;
            }
            else
            {
                resources.food -= resources.resourcePerTurn("food") / 2;
            }
        }
    }

    void interpretData()
    {
        thisEvent.nr = eventNumber;
        float x = new float();
        if (resources is PlayerResources)
        {
            title.text = thisEvent.n;
            description.text = thisEvent.description;
        }
        if (thisEvent.type == "stalemate")
        {
            if (thisEvent.resource == "all" && resources is PlayerResources)
                effect.text = "Effect: You don't gain any resources this turn.";
            if (thisEvent.resource == "food" && resources is PlayerResources)
                effect.text = "Effect: You don't gain food this turn.";
            x = 0;
        }
        else if (thisEvent.type == "negative")
        {
            if (thisEvent.resource != "all" && resources is PlayerResources)
                effect.text = "Effect: You lose " + thisEvent.modifier.ToString() + " " + thisEvent.resource + ".";
            else if (resources is PlayerResources)
                effect.text = "Effect: You lose " + thisEvent.modifier.ToString() + " of all resources.";
            x = -1;
        }
        else if (thisEvent.type == "positive")
        {
            if (thisEvent.resource != "all" && resources is PlayerResources)
                effect.text = "Effect: You gain " + thisEvent.modifier.ToString() + " " + thisEvent.resource + ".";
            else if (resources is PlayerResources)
                effect.text = "Effect: You gain " + thisEvent.modifier.ToString() + " of all resources.";
            x = 1;
        }
        else if (thisEvent.type == "halved")
        {
            x = 0.5f;
            if (resources is PlayerResources)
                effect.text = "Effect: You gain only half of your normal food income.";
        }

        if (thisEvent.resource == "approval")
        {
            if (resources is PlayerResources)
                LoggingSystem.Instance.approvalGained += x * thisEvent.modifier;
            resources.approval += x * thisEvent.modifier;
        }

        if (thisEvent.resource == "food" || thisEvent.resource == "all")
        {
            if (resources is PlayerResources)
                LoggingSystem.Instance.foodGained += x * thisEvent.modifier;
            resources.food += x * thisEvent.modifier;
        }

        if (thisEvent.resource == "money" || thisEvent.resource == "all")
        {
             if (resources is PlayerResources)
                LoggingSystem.Instance.moneyGained += x * thisEvent.modifier;
            resources.money += x * thisEvent.modifier;
        }

        if (thisEvent.resource == "materials" || thisEvent.resource == "all")
        {
             if (resources is PlayerResources)
                LoggingSystem.Instance.materialsGained += x * thisEvent.modifier;
            resources.buildingMaterials += x * thisEvent.modifier;
        }
        if (thisEvent.resource == "citizens")
        {
            if (resources is PlayerResources)
                LoggingSystem.Instance.citizensGained += x * thisEvent.modifier;
            resources.citizens += x * thisEvent.modifier;
        }

        

    }
}
