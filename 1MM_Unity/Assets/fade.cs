using UnityEngine;
using System.Collections;

public class fade : MonoBehaviour {

    public float t, wantedTime, startTime, endWantedTime;
    public bool fadeTo1, fadeTo0, fadeAllTo0;
    public CanvasGroup cg, textZone, loggingScreen;


    public void end()
    {
        startTime = Time.time;
        fadeTo0 = false;
        fadeTo1 = false;
        fadeAllTo0 = true;
        textZone.interactable = false;
        textZone.blocksRaycasts = false;
        Invoke("hideEverything", endWantedTime + 0.25F);
    }

    void hideEverything()
    {
        textZone.alpha = 1;
        cg.interactable = false;
        cg.blocksRaycasts = false;
        fadeAllTo0 = false;
        loggingScreen.alpha = 0;
        loggingScreen.interactable = false;
        loggingScreen.blocksRaycasts = false;
    }

    public void setToAlpha0()
    {
        if(cg.alpha != 0)
        { 
            textZone.alpha = 0;
            fadeTo0 = false;
            textZone.interactable = false;
            textZone.blocksRaycasts = false;
            interactable();
        }
    }

    public void setToAlhpa1()
    {
        if (cg.alpha != 0)
        { 
            Invoke("StartFadeTo0", 1.25F);
            cg.alpha = 1;
            fadeTo1 = false;
            textZone.interactable = true;
            textZone.blocksRaycasts = true;
        }
    }

    public void startFadeTo1()
    {
        startTime = Time.time;
        fadeTo1 = true;
        cg.interactable = true;
        cg.blocksRaycasts = true;
        if(textZone.alpha!=0 && !fadeAllTo0)
            Invoke("startFadeTo0", wantedTime + 1.25F);
        
    }

    public void startFadeTo0()
    {
        if(textZone.alpha!=0 && cg.alpha == 1 && !fadeTo1 == false)
        { 
            textZone.interactable = true;
            textZone.blocksRaycasts = true;
            fadeTo1 = false;
            startTime = Time.time;
            fadeTo0 = true;
            Invoke("interactable", wantedTime);
        }
    }

    void interactable()
    {
        
        textZone.interactable = false;
        textZone.blocksRaycasts = false;
        if (cg.alpha != 0)
        { 
            loggingScreen.alpha = 1;
            loggingScreen.interactable = true;
            loggingScreen.blocksRaycasts = true;
        }
    }

	void Update () {
        t = (Time.time - startTime) / wantedTime;

        if (fadeTo0)
        {
            
            textZone.alpha = Mathf.Lerp(1, 0, t);
        }

        if (fadeTo1)
        {
            cg.alpha = Mathf.Lerp(0, 1, t);
        }

        if (fadeAllTo0)
        {
            cg.alpha = Mathf.Lerp(1, 0, (Time.time - startTime) / endWantedTime);
        }
	}
}
