using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class Test : MonoBehaviour {

    public Canvas UI, StoryUI;
    public Text reply;
    public XmlReader reader;
    public XmlReaderSettings settings;
    public string source;
    public TextAsset text;
    public bool pressed = false, triggerScene2, triggerScene1, triggerScene3;

    public CanvasGroup p1, p2, p3;

    void Awake()
    {
        Camera.main.GetComponent<keyboardInput>().inStory = true;
        triggerScene1 = true;

        disableUI();

        settings = new XmlReaderSettings();
        settings.IgnoreWhitespace = true;
        text = (TextAsset)Resources.Load(source, typeof(TextAsset));
        reader = XmlReader.Create(new StringReader(text.text), settings);

    }

    void Start()
    {
        getToFirstLine();
        UI.enabled = false;
    
    }

    public void disableUI()
    {
        StoryUI.enabled = true;
        UI.enabled = false;
        Time.timeScale = 0;
    }

    public void getToFirstLine()
    {
        while (reader.Read())
        {
            if (reader.Name == "jeebus" || reader.Name == "bb")
            {
                if (reader.Name == "jeebus")
                {
                    p1.alpha = 1;
                    p2.alpha = 0;
                    p3.alpha = 0;
                }
                else
                {
                    p1.alpha = 0;
                    p2.alpha = 0;
                    p3.alpha = 1;
                }

                break;
            }

        }
        reader.Read();
        reply.text = reader.Value;
        Camera.main.GetComponent<keyboardInput>().inStory = true;
    }

	void Update () {


        if (triggerScene1 && Input.GetKeyDown(KeyCode.Space) && StoryUI.enabled == true)
        {
            Camera.main.GetComponent<keyboardInput>().inStory = true;
            while(reader.Read())
            {
                if (reader.Name == "scene2")
                {
                    triggerScene1 = false;
                    Camera.main.GetComponent<keyboardInput>().inStory = false;
                    UI.enabled = true;
                    StoryUI.enabled = false;
                    Time.timeScale = 1;
                    break;
                }


                if (reader.NodeType != XmlNodeType.EndElement && (reader.Name == "jeebus" || reader.Name =="god"))
                {
                    switch (reader.Name)
                    { 
                        case "jeebus":
                            p1.alpha = 1;
                            p2.alpha = 0;
                            p3.alpha = 0;
                            reader.Read();

                            reply.text = reader.Value;

                            break;

                        case "god":
                            p1.alpha = 0;
                            p2.alpha = 1;
                            p3.alpha = 0;
                            reader.Read();

                            reply.text = reader.Value;

                            break;
                    }
                    break;
                }
                
            }
        }

        if (triggerScene2 && Input.GetKeyDown(KeyCode.Space))
        {
            Camera.main.GetComponent<keyboardInput>().inStory = true;
            while (reader.Read())
            {
                if (reader.Name == "scene2" && reader.NodeType == XmlNodeType.EndElement)
                {
                    triggerScene2 = false;
                    Camera.main.GetComponent<keyboardInput>().inStory = false;
                    UI.enabled = true;
                    StoryUI.enabled = false;
                    Time.timeScale = 1;
                    break;
                }

                if (reader.NodeType != XmlNodeType.EndElement && (reader.Name == "jeebus" || reader.Name =="bb"))
                {
                    switch (reader.Name)
                    { 
                        case "jeebus":
                            p1.alpha = 1;
                            p2.alpha = 0;
                            p3.alpha = 0;
                            reader.Read();

                            reply.text = reader.Value;

                            break;

                        case "bb":
                            p1.alpha = 0;
                            p2.alpha = 0;
                            p3.alpha = 1;
                            reader.Read();

                            reply.text = reader.Value;

                            break;
                    }
                    break;
                }
            }

        }

        if (triggerScene3 && Input.GetKeyDown(KeyCode.Space))
        {
            Camera.main.GetComponent<keyboardInput>().inStory = true;
            while (reader.Read())
            {
                if (reader.Name == "scene3" && reader.NodeType == XmlNodeType.EndElement)
                {
                    Application.LoadLevel("Main Menu");
                    break;
                }

                if (reader.NodeType != XmlNodeType.EndElement && (reader.Name == "jeebus" || reader.Name == "god" || reader.Name == "end"))
                {
                    switch (reader.Name)
                    {
                        case "jeebus":
                            p1.alpha = 1;
                            p2.alpha = 0;
                            p3.alpha = 0;
                            reader.Read();

                            reply.text = reader.Value;

                            break;

                        case "god":
                            p1.alpha = 0;
                            p2.alpha = 1;
                            p3.alpha = 0;
                            reader.Read();

                            reply.text = reader.Value;

                            break;
                        case "end":
                            p1.alpha = 0;
                            p2.alpha = 0;
                            p3.alpha = 0;
                            reader.Read();

                            reply.text = reader.Value;
                            break;
                    }
                    break;
                }

            }
        }
        
	}
}
