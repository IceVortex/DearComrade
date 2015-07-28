using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagement : MonoBehaviour {
    
    public GameObject prefab, foodTerritoryPrefab, materialsTerritoryPrefab, citizensTerritoryPrefab;
    public AIManagement ai;
    public BuildingGeneration gen;
    public loggingFrontend loggingFrontEnd;
    public date d;
    public AResources res;
    public armyFrontEnd afe;
    public statistics stats;
    eventsRead playerEvents;
    public fadeToEndScreen lose, win;
    private int randNr;
    private int playerTroopsLost, enemyTroopsLost;
    private int resourcesAftermath, approvalAftermath;

    void Awake()
    {
        res.createBuilding<ExecutiveBuilding>((GameObject)Resources.Load("Prefabs/Buildings/Executive Building"), new Vector3(0, 0, 0));
        gen.hub = GameObject.FindGameObjectWithTag("Executive");
        playerEvents = GetComponent<eventsRead>();
    }

    void Update()
    {
        if (res.approval >= 100f && res.troops >= 3000 && !win.fadeTo1)
        {
            win.startFadeTo1();

        }
        if (res.approval <= -100 && !lose.fadeTo1)
        {
            lose.startFadeTo1();
        }
    }

    public void nextTurn()
    {
        // Reseting the logging screen
        LoggingSystem.Instance.reset();

        // Getting a random event and using it
        playerEvents.getRandomEvent();
        playerEvents.eventEffect();

        // Starting the AI's turn
        ai.nextTurn();

        // Attacking the enemy
        attack();

        // Picking up the resources from the buildings and links
        foreach (ABuilding building in res.buildings)
        {
            building.Effect();
        }

        foreach(var entry in res.links)
        {
            res.linkEffectTurn(entry.Key, entry.Value);
        }

        // Conquering territories
        conquerTerritories();

        // Fixing resources if any discrepancy is detected
        refreshResources();

        // Displaying the log
        loggingFrontEnd.updateValues();

        //Updating the statistics
        stats.updateStatistics();

        //Update Front End for the army
        afe.reset();
        afe.refreshDefensive();

    }

    public void attack()
    {
        // I am attacking
        if(res.attackingTroops > 0)
        {
            randNr = Random.Range(1, 101);

            // I haz more troops
            if(res.attackingTroops >= ai.res.troops)
            {
                // Troops lost for both players
                playerTroopsLost = (int)((res.attackingTroops / 4) * Random.Range(50, 151) / 100);
                enemyTroopsLost = (int)((ai.res.troops / 4) * Random.Range(100, 151) / 100);

                if(randNr <= 80 || ai.res.troops == 0) // I win
                {
                    // Approval gained or lost for both players
                    approvalAftermath = (int)((res.attackingTroops - ai.res.troops) / 50);

                    // Resources gained or lost for both players
                    resourcesAftermath = (int)(res.attackingTroops - ai.res.troops) / 5;

                    // Updating the resources
                    #region ...
                    if (ai.res.food >= resourcesAftermath)
                    {
                        ai.res.food -= resourcesAftermath;
                        res.food += resourcesAftermath;
                    }
                    else
                    {
                        res.food += ai.res.food;
                        ai.res.food = 0;
                    }

                    if (ai.res.buildingMaterials >= resourcesAftermath)
                    {
                        ai.res.buildingMaterials -= resourcesAftermath;
                        res.buildingMaterials += resourcesAftermath;
                    }
                    else
                    {
                        res.buildingMaterials += ai.res.buildingMaterials;
                        ai.res.buildingMaterials = 0;
                    }

                    if (ai.res.money >= resourcesAftermath)
                    {
                        ai.res.money -= resourcesAftermath;
                        res.money += resourcesAftermath;
                    }
                    else
                    {
                        res.food += ai.res.food;
                        ai.res.food = 0;
                    }
                    #endregion

                    //Adding result to logging system
                    LoggingSystem.Instance.attackResult = 1;
                    LoggingSystem.Instance.foodGained += resourcesAftermath;
                    LoggingSystem.Instance.materialsGained += resourcesAftermath;
                    LoggingSystem.Instance.moneyGained += resourcesAftermath;
                    LoggingSystem.Instance.resourcesModAttack = resourcesAftermath;
                }

                else // If I lose
                {
                    // Approval gained or lost for both players
                    approvalAftermath = -1 * (int)((res.attackingTroops - ai.res.troops) / 100);

                    // No resources lost / gained :(

                    //Adding result to logging system
                    LoggingSystem.Instance.attackResult = -1;
                }

                // Updating the approval
                res.approval = res.approval + approvalAftermath;
                ai.res.approval = ai.res.approval - approvalAftermath;
                LoggingSystem.Instance.approvalGained += approvalAftermath;
                LoggingSystem.Instance.approvalModAttack = approvalAftermath;

                // Updating the troops
                res.troops = res.troops + res.attackingTroops - playerTroopsLost;
                ai.res.troops = ai.res.troops - enemyTroopsLost;
                res.attackingTroops = 0;
                LoggingSystem.Instance.troopsLostAttack = playerTroopsLost;
                LoggingSystem.Instance.enemyTroopsLostAttack = enemyTroopsLost;
            }
            else // He haz moar troops
            {

                randNr = Random.Range(1, 101);
                // Troops lost for both players
                playerTroopsLost = (int)((res.attackingTroops / 4) * Random.Range(100, 151) / 100);
                enemyTroopsLost = (int)((ai.res.troops / 4) * Random.Range(50, 151) / 100);

                // Approval gained or lost for both players
                approvalAftermath = (int)((res.attackingTroops - ai.res.troops) / 100);

                if (randNr <= 20) // I win
                {
                

                    // Resources gained or lost for both players
                    resourcesAftermath = (int)(res.attackingTroops - ai.res.troops) / 10;

                    // Updating the resources
                    #region ...
                    if (ai.res.food >= resourcesAftermath)
                    {
                        ai.res.food -= resourcesAftermath;
                        res.food += resourcesAftermath;
                    }
                    else
                    {
                        res.food += ai.res.food;
                        ai.res.food = 0;
                    }

                    if (ai.res.buildingMaterials >= resourcesAftermath)
                    {
                        ai.res.buildingMaterials -= resourcesAftermath;
                        res.buildingMaterials += resourcesAftermath;
                    }
                    else
                    {
                        res.buildingMaterials += ai.res.buildingMaterials;
                        ai.res.buildingMaterials = 0;
                    }

                    if (ai.res.money >= resourcesAftermath)
                    {
                        ai.res.money -= resourcesAftermath;
                        res.money += resourcesAftermath;
                    }
                    else
                    {
                        res.food += ai.res.food;
                        ai.res.food = 0;
                    }
                    #endregion

                    //Adding result to logging system
                    LoggingSystem.Instance.attackResult = 1;
                    LoggingSystem.Instance.foodGained += resourcesAftermath;
                    LoggingSystem.Instance.materialsGained += resourcesAftermath;
                    LoggingSystem.Instance.moneyGained += resourcesAftermath;
                    LoggingSystem.Instance.resourcesModAttack = resourcesAftermath;
                }

                else // If I lose
                {
                    // Approval gained or lost for both players
                    approvalAftermath = -1 * approvalAftermath;

                    // No resources lost / gained :(

                    //Adding result to logging system
                    LoggingSystem.Instance.attackResult = -1;
                }

                // Updating the approval
                res.approval = res.approval + approvalAftermath;
                ai.res.approval = ai.res.approval - approvalAftermath;
                LoggingSystem.Instance.approvalGained += approvalAftermath;
                LoggingSystem.Instance.approvalModAttack = approvalAftermath;

                // Updating the troops
                res.troops = res.troops + res.attackingTroops - playerTroopsLost;
                ai.res.troops = ai.res.troops - enemyTroopsLost;
                res.attackingTroops = 0;
                LoggingSystem.Instance.troopsLostAttack = playerTroopsLost;
                LoggingSystem.Instance.enemyTroopsLostAttack = enemyTroopsLost;
            }
        }
    }

    public void conquerTerritories()
    {
        if ((int)Random.Range(0f, 101f) < res.territoryConquerRate)
        {
            randNr = (int)Random.Range(0, 101);
            if (randNr <= 33)
            {
                res.createBuilding<FoodTerritory>(foodTerritoryPrefab, gen.generate());
                if (res is GameResources)
                    LoggingSystem.Instance.territoryRecieved = 1;
            }
            else if (randNr <= 66)
            {
                res.createBuilding<MaterialsTerritory>(materialsTerritoryPrefab, gen.generate());
                if (res is GameResources)
                    LoggingSystem.Instance.territoryRecieved = 2;
            }
            else if (randNr <= 100)
            {
                res.createBuilding<CitizensTerritory>(citizensTerritoryPrefab, gen.generate());
                if (res is GameResources)
                    LoggingSystem.Instance.territoryRecieved = 3;
            }
        }
    }

    public void refreshResources()
    {
        if (res.food < 0)
            res.food = 0;

        if (res.money < 0)
            res.money = 0;

        if (res.buildingMaterials < 0)
            res.buildingMaterials = 0;

        if (res.citizens < 0)
            res.citizens = 0;
    }

}
