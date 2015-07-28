using UnityEngine;
using System.Collections;

public class LoggingSystem : MonoBehaviour
{

    private static LoggingSystem instance;
    public float foodGained, materialsGained, moneyGained, citizensGained, baseApprovalLost, approvalGained;
    public int territoryRecieved, approvalModAttack, approvalModDefense;
    public int attackResult, defenseResult, troopsLostAttack, troopsLostDefense, enemyTroopsLostAttack, enemyTroopsLostDefense, resourcesModAttack, resourcesModDefense;

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
        approvalModAttack = 0;
        approvalModDefense = 0;
        troopsLostAttack = 0;
        troopsLostDefense = 0;
        enemyTroopsLostAttack = 0;
        enemyTroopsLostDefense = 0;
        resourcesModAttack = 0;
        resourcesModDefense = 0;
    }
}
