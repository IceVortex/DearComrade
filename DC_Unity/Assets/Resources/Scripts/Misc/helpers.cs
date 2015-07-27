using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class helpers : MonoBehaviour {

    private string[] titlesList = { "-- Welcome Message --", "-- Movement --", "-- Resources --", "-- Getting started --", "-- Comradery --", "-- Tooltips --", 
                              "-- Events --", "-- Public interest buildings --", "-- The end of the public service announcement --" };
    private string[] descriptionsList = { "Greetings! The goal of the game is to reach 100 approval and 3000 troops. However, if you reach -100 approval instead, you lose the game. The game is turn based. To finish your turn click on the end turn button.", 
                                    "To move around just hold right click and drag the mouse.", 
                                    "The first 3 resources, food, materials and money are mainly used for construction.", 
                                    "We recommend you click on the building in the center of the screen and choose the build option then build at least a house, a farm, and most importantly a factory.", 
                                    "The Establish Comradery button lets you link buildings which grants you some bonuses.", 
                                    "We recommend you to read the descriptions of the buildings. Also, you should hover on the resources at the top of the screen. This will display a tooltip which offers some information.", 
                                    "At the end of each of your turn, a random event will occur. These can be favorable or unfavorable. For example some will grant approval but some will decrease your approval.", 
                                    "There are buildings which provide a flat amount of approval and also decrease the approval decay per turn, for example: Public Spaces or Educational Buildings. If you feel you are low on approval, we suggest you start building these.", 
                                    "We will let you discover the rest. Good Luck! :)" };
    public int currentHelper = 0;
    public Text title, description;

	void Start () {
        if (!PlayerPrefs.HasKey("helpersShowed") || PlayerPrefs.GetInt("helpersShowed") == 0)
        {
            GetComponent<hide>().toggle();
            PlayerPrefs.SetInt("helpersShowed", 1);
        }
        title.text = titlesList[currentHelper];
        description.text = descriptionsList[currentHelper];
	}

    public void next()
    {
        if(currentHelper != 8)
        {
            currentHelper++;
            title.text = titlesList[currentHelper];
            description.text = descriptionsList[currentHelper];
        }
    }

    public void previous()
    {
        if (currentHelper != 0)
        {
            currentHelper--;
            title.text = titlesList[currentHelper];
            description.text = descriptionsList[currentHelper];
        }
    }
}
