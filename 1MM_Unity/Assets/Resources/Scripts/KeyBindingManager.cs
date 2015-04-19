using UnityEngine;
using System.Collections;

public class KeyBindingManager : MonoBehaviour {

    private static KeyBindingManager _instance;

    public static KeyBindingManager instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<KeyBindingManager>();
            return _instance;
        }
    }

    public KeyCode HolyGrenade, BlindingFlashLight, Frenzy, HolySmite, Inventory, ManaPotion, HealthPotion;



	void Awake () {
        reset();
	}

    public void reset()
    {
        HolyGrenade = KeyCode.A;
        BlindingFlashLight = KeyCode.S;
        Frenzy = KeyCode.D;
        HolySmite = KeyCode.F;
        ManaPotion = KeyCode.Alpha2;
        HealthPotion = KeyCode.Alpha1;
        Inventory = KeyCode.I;
    }

    public bool check(KeyCode lastPressedKey)
    {
        if (lastPressedKey != KeyBindingManager.instance.BlindingFlashLight &&
                lastPressedKey != Frenzy &&
                lastPressedKey != HolySmite &&
                lastPressedKey != Inventory &&
                lastPressedKey != HealthPotion &&
                lastPressedKey != ManaPotion && lastPressedKey!=KeyCode.Escape)
            return true;
        else
            return false;
    }

}
