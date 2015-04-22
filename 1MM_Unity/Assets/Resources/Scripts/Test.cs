using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class Test : MonoBehaviour {

    public Canvas UI, eventsUI;
    XmlReader reader;
    XmlReaderSettings settings;
    public string source;
    public TextAsset text;
    public int eventNumber;
    public bool trigger;

    public struct gameEvent{

        public int nr;
        public string description, n, required, resource, type;
        public float modifier;

    };

    public gameEvent thisEvent;

    void Awake()
    {
        Camera.main.GetComponent<keyboardInput>().events = true;
        disableUI();

        settings = new XmlReaderSettings();
        settings.IgnoreWhitespace = true;
        text = (TextAsset)Resources.Load(source, typeof(TextAsset));
        reader = XmlReader.Create(new StringReader(text.text), settings);

    }

    void Start()
    {
        UI.enabled = false;
    }

    public void disableUI()
    {
        eventsUI.enabled = true;
        UI.enabled = false;
        Time.timeScale = 0;
    }

    void getRandomEvent()
    {
        int x = Random.Range(1, 20);
        getToEvent(x);
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
            thisEvent.nr = eventNumber; 
            trigger = true;
            interpretData();
        }
        Camera.main.GetComponent<keyboardInput>().events = true;
    }

    void interpretData()
    { 
        
    }

	void Update () {

        if (trigger && Input.GetKeyDown(KeyCode.Space) && eventsUI.enabled == true)
        {
            Camera.main.GetComponent<keyboardInput>().events = true;
            while(reader.Read())
            {
                if (reader.Name == "event" && reader.NodeType == XmlNodeType.EndElement)
                {
                    trigger = false;
                    Camera.main.GetComponent<keyboardInput>().events = false;
                    UI.enabled = true;
                    eventsUI.enabled = false;
                    Time.timeScale = 1;
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
        }
        
	}
}
