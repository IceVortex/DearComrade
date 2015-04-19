using UnityEngine;
using System.Collections;

public class GameResources : MonoBehaviour 
{
    //Here is a private reference only this class can access
    private static GameResources _instance;
    public float food, money, buildingMaterials, approval;
 
    //This is the public reference that other classes will use
    public static GameResources instance
    {
        get
        {
            //If _instance hasn't been set yet, we grab it from the scene!
            //This will only happen the first time this reference is used.
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<GameResources>();
            return _instance;
        }
    }
 
    public void Play()
    {
        //Play some audio!
    }

}
