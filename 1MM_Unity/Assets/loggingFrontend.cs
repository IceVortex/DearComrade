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
        approvalValue.text = GameResources.instance.approval.ToString();

        values.text = "Food: " + LoggingSystem.Instance.foodGained.ToString() + "\n"
            + "Materials: " + LoggingSystem.Instance.materialsGained.ToString() + "\n"
            + "Money: " + LoggingSystem.Instance.moneyGained.ToString() + "\n"
            + "Approval: " + (-LoggingSystem.Instance.baseApprovalLost + LoggingSystem.Instance.approvalGained).ToString();
    }
}
