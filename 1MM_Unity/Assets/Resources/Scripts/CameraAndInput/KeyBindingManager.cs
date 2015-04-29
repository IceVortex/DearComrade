using UnityEngine;
using System.Collections;

public class KeyBindingManager : MonoBehaviour {

    private static KeyBindingManager instance;

    public static KeyBindingManager Instance
    {
        get { return instance ?? (instance = new GameObject("KeyBindingManager").AddComponent<KeyBindingManager>()); }
    }

    public KeyCode endTurn;
    public bool scrollEnabled;


	void Awake () {

        scrollEnabled = false;
	}


    public bool check(KeyCode lastPressedKey)
    {
        if (lastPressedKey != endTurn)
            return true;
        else
            return false;
    }


}
