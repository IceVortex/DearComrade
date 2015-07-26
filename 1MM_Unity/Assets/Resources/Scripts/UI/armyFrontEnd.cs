using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class armyFrontEnd : MonoBehaviour {

    public CanvasGroup armyButton;
    public Text defensive, offensive, increase;

    public AResources res;
    public int troopsToIncreaseBy, offensiveI, defensiveI;

    public void toggleArmyButton()
    {
        armyButton.interactable = true;
        armyButton.blocksRaycasts = true;
    }

    public void refreshDefensive()
    {
        defensiveI = (int)res.troops;
        defensive.text = defensiveI.ToString();
    }

    public void reset()
    {
        offensiveI = 0;
        offensive.text = "0";
    }

    public void confirm()
    {
        res.convertToAttackingTroops(troopsToIncreaseBy);
        increase.text = "0";
        offensiveI += troopsToIncreaseBy;
        defensiveI = (int)res.troops;
        troopsToIncreaseBy = 0;

        defensive.text = defensiveI.ToString();
        offensive.text = offensiveI.ToString();
    }

    public void increaseTroops(int mod)
    {
        
        if (troopsToIncreaseBy + (100 * mod) <= res.troops && mod == 1)
            troopsToIncreaseBy += 100 * mod;
        else if (troopsToIncreaseBy + (100 * mod) > res.troops && mod == 1)
            troopsToIncreaseBy = (int)res.troops;
        else if (troopsToIncreaseBy + (100 * mod) + offensiveI < 0 && mod == -1)
            troopsToIncreaseBy = 0;
        else if (troopsToIncreaseBy + (100 * mod) + offensiveI >= 0 && mod == -1)
            troopsToIncreaseBy += 100 * mod;

        increase.text = troopsToIncreaseBy.ToString();

    }

    public void trainTroops()
    { 
        
    }

}
