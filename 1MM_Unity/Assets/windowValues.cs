using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class windowValues : MonoBehaviour {

    public Text bName, bDescription, bMax, bFlavorText;
    public Image bIcon;
    public Sprite[] icons;
    public CanvasGroup[] buttonSet;
    public bool showExtraTab;
    public CanvasGroup extraTab;

    public void changeButtonSet(CanvasGroup active)
    {
        for (int i = 0; i < buttonSet.Length; i++)
        {
            buttonSet[i].alpha = 0;
            buttonSet[i].interactable = false;
            buttonSet[i].blocksRaycasts = false;
        }
        active.alpha = 1;
        active.interactable = true;
        active.blocksRaycasts = true;
    }

    public void updateValues(string n, string desc, int max, string flavorText)
    {
        bName.text = n;
        bDescription.text = desc;
        bMax.text = max.ToString();
        bFlavorText.text = flavorText;

        if (n == "Executive Buildings")
        {
            bIcon.sprite = icons[0];
            changeButtonSet(buttonSet[0]);
        }

        if (n == "Houses")
        {
            bIcon.sprite = icons[1];
            changeButtonSet(buttonSet[1]);
        }

        if (n == "Farms")
        {
            bIcon.sprite = icons[2];
            changeButtonSet(buttonSet[1]);
        }

        if (n == "Factories")
        {
            bIcon.sprite = icons[3];
            changeButtonSet(buttonSet[1]);
        }

        if (n == "World Trade Center")
        {
            bIcon.sprite = icons[4];
            changeButtonSet(buttonSet[2]);
        }

        if (n == "Hospitals")
        {
            bIcon.sprite = icons[5];
            changeButtonSet(buttonSet[4]);
        }

        if (n == "Public Spaces")
        {
            bIcon.sprite = icons[6];
            changeButtonSet(buttonSet[4]);
        }

        if (n == "Educational Buildings")
        {
            bIcon.sprite = icons[7];
            changeButtonSet(buttonSet[4]);
        }

        if (n == "Police Stations")
        {
            bIcon.sprite = icons[8];
            changeButtonSet(buttonSet[4]);
        }

        if (n == "Workplaces")
        {
            bIcon.sprite = icons[9];
            changeButtonSet(buttonSet[4]);
        }

        if (n == "Laboratories")
        {
            bIcon.sprite = icons[10];
            changeButtonSet(buttonSet[3]);
        }

    }

    public void toggleExtraTab()
    {
        extraTab.gameObject.GetComponent<hide>().toggle();
    }


}
