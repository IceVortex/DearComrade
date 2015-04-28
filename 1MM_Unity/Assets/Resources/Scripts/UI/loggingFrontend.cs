using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class loggingFrontend : MonoBehaviour {

    public Color positiveColor, negativeColor;
    public Text values, approvalValue;

    public void updateValues()
    {
        if (GameResources.instance.approval >= 0)
            approvalValue.color = positiveColor;
        else
            approvalValue.color = negativeColor;
        approvalValue.text = System.Math.Round(GameResources.instance.approval,2).ToString();

        values.text = "Food: " + System.Math.Round(LoggingSystem.Instance.foodGained,2).ToString() + "\n"
            + "Materials: " + System.Math.Round(LoggingSystem.Instance.materialsGained,2).ToString() + "\n"
            + "Money: " + System.Math.Round(LoggingSystem.Instance.moneyGained,2).ToString() + "\n"
            + "Approval: " + System.Math.Round((-LoggingSystem.Instance.baseApprovalLost + LoggingSystem.Instance.approvalGained),2).ToString();
    }
}
