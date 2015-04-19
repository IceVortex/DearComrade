using UnityEngine;
using System.Collections;

public class keyboardInput : MonoBehaviour {

    public bool showInventory,toggled,toggled3;
    public UIControl ui;
    public string inv;
    public float rawFps,fps,maxFps,minFps,avgFps;
    public bool showFPS, toggled2, showMenu, inStory;
    public int qty;
	
	void Start () {
        minFps = 60;
        maxFps = 0;
        showInventory = false;
        InvokeRepeating("updateFps", 0.0F, 1.0F);
        
	}
	
	
	void Update () {

        toggled = false;
        toggled2 = false;
        toggled3 = false;
        

        if (showMenu == true && Input.GetKeyDown(KeyCode.Escape))
        {
            showMenu = false;
            toggled3 = true;
            
        }

        if (showMenu == false && Input.GetKeyDown(KeyCode.Escape) && !toggled3)
        {
            showMenu = true;


        }

        if (showFPS == true && Input.GetKeyDown(KeyCode.BackQuote))
        {
            showFPS = false;
            toggled2 = true;
        }
        if (showFPS == false && Input.GetKeyDown(KeyCode.BackQuote) && !toggled2)
        {
            showFPS = true;
        }

        if (showFPS == true)
        { 
            qty ++;
            rawFps = (1.0F/Time.deltaTime);
            if (rawFps < minFps)
                minFps = rawFps;
            if (rawFps > maxFps)
                maxFps = rawFps;

            avgFps += (rawFps - avgFps) / qty;
        }

        if (showMenu == true && !inStory)
        {
            ui.ShowMenu();
        }

        if (showMenu == false && !inStory)
        {
            ui.settings.GetComponent<SettingsUI>().resume();
            
        }

	}

    void updateFps()
    {
        fps = rawFps;
    }

    void OnGUI()
    {
        if (showFPS)
        {
            GUILayout.Label("FPS(updated every second): " + fps.ToString());
            GUILayout.Label("FPS(updated every frame): " + rawFps.ToString());
            GUILayout.Label("FPS(average): " + avgFps.ToString());

            GUILayout.Label("Min FPS: " + minFps.ToString());
            GUILayout.Label("Max FPS: " + maxFps.ToString());
        }
    }

}
