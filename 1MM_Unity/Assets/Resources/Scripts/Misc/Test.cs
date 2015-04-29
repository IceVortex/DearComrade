using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class Test : MonoBehaviour {

    XmlReader reader;
    XmlReaderSettings settings;
    public string source;
    public TextAsset text;
    public int eventNumber;
    public bool trigger;

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
        int x = Random.Range(1, 21);
        getToEvent(x);

        if (thisEvent.required != "none")
        {
            if(!GameResources.instance.buildingConsutructedCheck(thisEvent.required))
                getRandomEvent();
        }
        else if(lastEvent.type == thisEvent.type)
        {
            getRandomEvent();
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


    void interpretData()
    {
        thisEvent.nr = eventNumber;
        float x = new float();
        title.text = thisEvent.n;
        description.text = thisEvent.description;
        if (thisEvent.type == "stalemate")
        {
            if (thisEvent.resource == "all")
               effect.text = "Effect: You don't gain any resources this turn.";
            if (thisEvent.resource == "food")
                effect.text = "Effect: You don't gain food this turn.";
            x = 0;
        }
        else if (thisEvent.type == "negative")
        {
            if (thisEvent.resource != "all")
                effect.text = "Effect: You lose " + thisEvent.modifier.ToString() + " " + thisEvent.resource + ".";
            else
                effect.text = "Effect: You lose " + thisEvent.modifier.ToString() + " of all resources.";
            x = -1;
        }
        else if (thisEvent.type == "positive")
        {
            if(thisEvent.resource != "all")
                effect.text = "Effect: You gain " + thisEvent.modifier.ToString() + " " + thisEvent.resource + ".";
            else
                effect.text = "Effect: You gain " + thisEvent.modifier.ToString() + " of all resources.";
            x = 1;
        }
        else if (thisEvent.type == "halved")
        {
            x = 0.5f;
            effect.text = "Effect: You gain only half of your normal food income.";
        }

        if (thisEvent.resource == "approval")
        {
            LoggingSystem.Instance.approvalGained += x * thisEvent.modifier;
            GameResources.instance.approval += x * thisEvent.modifier;
        }

        if (thisEvent.resource == "food" || thisEvent.resource == "all")
        {
            LoggingSystem.Instance.foodGained += x * thisEvent.modifier;
            GameResources.instance.food += x * thisEvent.modifier;
        }

        if (thisEvent.resource == "money" || thisEvent.resource == "all")
        {
            LoggingSystem.Instance.moneyGained += x * thisEvent.modifier;
            GameResources.instance.money += x * thisEvent.modifier;
        }

        if (thisEvent.resource == "materials" || thisEvent.resource == "all")
        {
            LoggingSystem.Instance.materialsGained += x * thisEvent.modifier;
            GameResources.instance.buildingMaterials += x * thisEvent.modifier;
        }
        if (thisEvent.resource == "citizens")
        {
            LoggingSystem.Instance.citizensGained += x * thisEvent.modifier;
            GameResources.instance.citizens += x * thisEvent.modifier;
        }

        

    }

	void Update () {

        /*if (trigger)
        {
            //Camera.main.GetComponent<keyboardInput>().events = true;
            while(reader.Read())
            {
                if (reader.Name == "event" && reader.NodeType == XmlNodeType.EndElement)
                {
                    trigger = false;
                    //Camera.main.GetComponent<keyboardInput>().events = false;
                    //Time.timeScale = 1;
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
                        case "modifer":
                            reader.Read();
                            float.TryParse(reader.Value, out thisEvent.modifier);
                            break;

                    }
                    break;
                }
                
            }
        }*/
        
	}
}
