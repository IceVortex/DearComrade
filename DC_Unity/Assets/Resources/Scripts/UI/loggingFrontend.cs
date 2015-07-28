using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class loggingFrontend : MonoBehaviour {

    public Color positiveColor, negativeColor;
    public Text ResourcesValues, approvalValue, ArmyValues;
    public AResources resources;

    public void updateValues()
    {
        if (resources.approval >= 0)
            approvalValue.color = positiveColor;
        else
            approvalValue.color = negativeColor;
        approvalValue.text = System.Math.Round(resources.approval, 2).ToString();

        ResourcesValues.text = "Food: " + System.Math.Round(LoggingSystem.Instance.foodGained, 2).ToString() + "\n"
            + "Materials: " + System.Math.Round(LoggingSystem.Instance.materialsGained,2).ToString() + "\n"
            + "Money: " + System.Math.Round(LoggingSystem.Instance.moneyGained,2).ToString() + "\n"
            + "Approval: " + System.Math.Round((-LoggingSystem.Instance.baseApprovalLost + LoggingSystem.Instance.approvalGained),2).ToString()+"\n";

        ArmyValues.text = "";

        if (LoggingSystem.Instance.territoryRecieved == 1)
        {
            ResourcesValues.text += "Your army has conquered a Food Territory.";
        }
        if (LoggingSystem.Instance.territoryRecieved == 2)
        {
            ResourcesValues.text += "Your army has conquered a Materials Territory.";
        }
        if (LoggingSystem.Instance.territoryRecieved == 3)
        {
            ResourcesValues.text += "Your army has conquered a Citizens Territory.";
        }

        if (LoggingSystem.Instance.attackResult == 0)
        {
            ArmyValues.text += "You did not attack this turn.";
        }
        if (LoggingSystem.Instance.attackResult == 1)
        {
            ArmyValues.text += "Your army attacked the enemy and won the battle. While you lost " + LoggingSystem.Instance.troopsLostAttack + " troops in the attack, ";
            ArmyValues.text += "your enemy also lost " + LoggingSystem.Instance.enemyTroopsLostAttack + " troops." + "\n";
            ArmyValues.text += "You take " + LoggingSystem.Instance.resourcesModAttack + " resources from your enemy, and you gain " + LoggingSystem.Instance.approvalModAttack + " approval as well." + '\n';

        }
        if (LoggingSystem.Instance.attackResult == -1)
        {
            ArmyValues.text += "Unfortunately, the army you sent into battle was defeated, losing " + LoggingSystem.Instance.troopsLostAttack + " troops in the process.";
            ArmyValues.text += "Your enemy also lost " + LoggingSystem.Instance.enemyTroopsLostAttack + " troops during your attack.";
            ArmyValues.text += "Your approval decreases by " + LoggingSystem.Instance.approvalModAttack + " while your enemy's increases by the same amount." + '\n';
        }

        ArmyValues.text += "\n";

        if (LoggingSystem.Instance.defenseResult == 0)
        {
            ArmyValues.text += "You were not attacked this turn.";
        }
        if (LoggingSystem.Instance.defenseResult == 1)
        {
            ArmyValues.text += "You managed to defend your territory!";
        }
        if (LoggingSystem.Instance.defenseResult == -1)
        {
            ArmyValues.text += "You did not manage to defend your territory!";
        }
    }
}
