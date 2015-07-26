using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class loggingFrontend : MonoBehaviour {

    public Color positiveColor, negativeColor;
    public Text values, approvalValue;
    public AResources resources;

    public void updateValues()
    {
        if (resources.approval >= 0)
            approvalValue.color = positiveColor;
        else
            approvalValue.color = negativeColor;
        approvalValue.text = System.Math.Round(resources.approval, 2).ToString();

        values.text = "Food: " + System.Math.Round(LoggingSystem.Instance.foodGained,2).ToString() + "\n"
            + "Materials: " + System.Math.Round(LoggingSystem.Instance.materialsGained,2).ToString() + "\n"
            + "Money: " + System.Math.Round(LoggingSystem.Instance.moneyGained,2).ToString() + "\n"
            + "Approval: " + System.Math.Round((-LoggingSystem.Instance.baseApprovalLost + LoggingSystem.Instance.approvalGained),2).ToString()+"\n";

        if (LoggingSystem.Instance.territoryRecieved == 1)
        {
            values.text += "Your army has conquered a Food Territory.";
        }
        if (LoggingSystem.Instance.territoryRecieved == 2)
        {
            values.text += "Your army has conquered a Materials Territory.";
        }
        if (LoggingSystem.Instance.territoryRecieved == 3)
        {
            values.text += "Your army has conquered a Citizens Territory.";
        }

        values.text += "\n";

        if (LoggingSystem.Instance.attackResult == 0)
        {
            values.text += "You did not attack this turn.";
        }
        if (LoggingSystem.Instance.attackResult == 1)
        {
            values.text += "Your army won the battle against the enemy!";
        }
        if (LoggingSystem.Instance.attackResult == -1)
        {
            values.text += "Your army lost the battle against the enemy!";
        }

        values.text += "\n";

        if (LoggingSystem.Instance.defenseResult == 0)
        {
            values.text += "You were not attacked this turn.";
        }
        if (LoggingSystem.Instance.defenseResult == 1)
        {
            values.text += "You managed to defend your territory!";
        }
        if (LoggingSystem.Instance.defenseResult == -1)
        {
            values.text += "You did not manage to defend your territory!";
        }
    }
}
