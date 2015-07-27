using UnityEngine;
using System.Collections;

public class LoggingSystem : MonoBehaviour
{

    private static LoggingSystem instance;
    public float foodGained, materialsGained, moneyGained, citizensGained, baseApprovalLost, approvalGained;
    public int territoryRecieved;
    public int attackResult, defenseResult;

    public static LoggingSystem Instance
    {
        get { return instance ?? (instance = new GameObject("LoggingSystem").AddComponent<LoggingSystem>()); }
    }

    public void reset()
    {
        foodGained = 0;
        materialsGained = 0;
        moneyGained = 0;
        citizensGained = 0;
        baseApprovalLost = 0;
        approvalGained = 0;
        territoryRecieved = 0;
        attackResult = 0;
        defenseResult = 0;
    }
}
