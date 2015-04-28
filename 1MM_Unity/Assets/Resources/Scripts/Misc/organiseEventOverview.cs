using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class organiseEventOverview : MonoBehaviour {

    public ExecutiveBuilding eb;
    public GameObject ebGO;
    public CanvasGroup[] overlays;

    public void festival()
    {
        if (eb.canBuyFestival())
            eb.buyFestival();
    }

    public void speech()
    {
        if (eb.canBuyPublicSpeech())
            eb.buyPublicSpeech();
    }

    public void rations()
    {
        if (GameResources.instance.food >= 100)
            eb.increasedFoodRatio(100);
    }

    void Start()
    {
        eb = (ExecutiveBuilding)GameResources.instance.buildings[0];
    }

    void Update()
    {
        if (eb.canBuyFestival())
        {
            overlays[0].alpha = 0;
            overlays[0].interactable = false;
            overlays[0].blocksRaycasts = false;
        }
        else
        {
            overlays[0].alpha = 1;
            overlays[0].interactable = true;
            overlays[0].blocksRaycasts = true;
        }

        if (eb.canBuyPublicSpeech())
        {
            overlays[1].alpha = 0;
            overlays[1].interactable = false;
            overlays[1].blocksRaycasts = false;
        }
        else
        {
            overlays[1].alpha = 1;
            overlays[1].interactable = true;
            overlays[1].blocksRaycasts = true;
        }

        if (GameResources.instance.food>=100)
        {
            overlays[2].alpha = 0;
            overlays[2].interactable = false;
            overlays[2].blocksRaycasts = false;
        }
        else
        {
            overlays[2].alpha = 1;
            overlays[2].interactable = true;
            overlays[2].blocksRaycasts = true;
        }

    }

}
