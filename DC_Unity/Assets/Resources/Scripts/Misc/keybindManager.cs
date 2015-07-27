using UnityEngine;
using System.Collections;

public class keybindManager : MonoBehaviour {

    private static keybindManager _instance;

    public static keybindManager instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<keybindManager>();
            return _instance;
        }
    }

    public KeyCode returnToEB, goToEnemyEB ,startComradery, startMove;

    void Awake()
    {
        reset();
    }

    public void reset()
    {
        returnToEB = KeyCode.Q;
        goToEnemyEB = KeyCode.W;
        startComradery = KeyCode.E;
        startMove = KeyCode.R;
    }

   

}
