using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

    public statistics stats;

    public CanvasGroup buildTab, armyTab, statisticsTab;

    public void toggleTab(string tab)
    {
        if (tab == "build")
        {
            reset();
            buildTab.alpha = 1;
            buildTab.interactable = true;
            buildTab.blocksRaycasts = true;
        }
        if (tab == "army")
        {
            reset();
            armyTab.alpha = 1;
            armyTab.interactable = true;
            armyTab.blocksRaycasts = true;
        }
        if (tab == "stats")
        {
            stats.updateStatistics();
            reset();
            statisticsTab.alpha = 1;
            statisticsTab.interactable = true;
            statisticsTab.blocksRaycasts = true;
        }
    
    }

    void reset()
    {
        buildTab.alpha = 0;
        buildTab.interactable = false;
        buildTab.blocksRaycasts = false;

        armyTab.alpha = 0;
        armyTab.interactable = false;
        armyTab.blocksRaycasts = false;

        statisticsTab.alpha = 0;
        statisticsTab.interactable = false;
        statisticsTab.blocksRaycasts = false;
    }

}
