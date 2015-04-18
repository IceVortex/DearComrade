using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class gameManager : MonoBehaviour {

    public Dictionary<int,string> enemies = new Dictionary<int,string>();
    private static gameManager instance;
    public static gameManager Instance {

        get { return instance ?? (instance = new GameObject("Game Manager").AddComponent<gameManager>()); }
    
    }
    
    void Awake()
    {
        instance = this;
    }

    public bool checkID(int id)
    {
        string temp;

        if (enemies.TryGetValue(id, out temp))
            return false;
        else
            return true;
    }

    public void assignEnemyID(int id, string name)
    {
        enemies.Add(id, name);

    }
    
}
