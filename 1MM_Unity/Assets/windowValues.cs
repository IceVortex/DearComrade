using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class windowValues : MonoBehaviour {

    public Text bName, bDescription, bMax, bFlavorText;
    public Image bIcon;
    public Sprite[] icons;
    public CanvasGroup[] buttonSet;
    public CanvasGroup extraTab;
    public string buildingName;
    public GameObject clickedByGO;

    public buildingValues values = new buildingValues();

    public void clicked(GameObject clickedBy)
    {
        buildingName = clickedBy.name;

        clickedByGO = clickedBy;

        extraTab.gameObject.GetComponent<hide>().setTrue();
        updateValues(buildingName, values.buildingLongDescription(buildingName), values.numberOf(buildingName), values.buildingFlavorText(buildingName));
    }

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

        if (n == "Executive Building")
        {
            bIcon.sprite = icons[0];
            changeButtonSet(buttonSet[1]);
            bMax.text = "Maximum amount: 1";
        }

        if (n == "House")
        {
            bIcon.sprite = icons[1];
            changeButtonSet(buttonSet[0]);
            bMax.text = "Maximum amount: Unlimited";
        }

        if (n == "Farm")
        {
            bIcon.sprite = icons[2];
            changeButtonSet(buttonSet[0]);
            bMax.text = "Maximum amount: Unlimited";
        }

        if (n == "Factory")
        {
            bIcon.sprite = icons[3];
            changeButtonSet(buttonSet[0]);
            bMax.text = "Maximum amount: Unlimited";
        }

        if (n == "World Trade Center")
        {
            bIcon.sprite = icons[4];
            changeButtonSet(buttonSet[2]);
            bMax.text = "Maximum amount: 1";
        }

        if (n == "Hospital")
        {
            bIcon.sprite = icons[5];
            changeButtonSet(buttonSet[4]);
            bMax.text = "Maximum amount: 1";
        }

        if (n == "Public Space")
        {
            bIcon.sprite = icons[6];
            changeButtonSet(buttonSet[4]);
            bMax.text = "Maximum amount: 1";
        }

        if (n == "Educational Building")
        {
            bIcon.sprite = icons[7];
            changeButtonSet(buttonSet[4]);
            bMax.text = "Maximum amount: 1";
        }

        if (n == "Police Station")
        {
            bIcon.sprite = icons[8];
            changeButtonSet(buttonSet[4]);
            bMax.text = "Maximum amount: 1";
        }

        if (n == "Workplace")
        {
            bIcon.sprite = icons[9];
            changeButtonSet(buttonSet[4]);
            bMax.text = "Maximum amount: 1";
        }

        if (n == "Laboratory")
        {
            bIcon.sprite = icons[10];
            changeButtonSet(buttonSet[3]);
            bMax.text = "Maximum amount: 1";
        }

    }

    public void toggleExtraTab()
    {
        extraTab.gameObject.GetComponent<hide>().toggle();
    }


}
