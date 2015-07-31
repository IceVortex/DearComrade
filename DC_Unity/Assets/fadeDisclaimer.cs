using UnityEngine;
using System.Collections;

public class fadeDisclaimer : MonoBehaviour {

    public float t, wantedTime, startTime;
    public bool fadeTo1, fadeTo0, fadeDisclaimerTo1;
    public CanvasGroup cg, mm;

	void Start () {
        if (!PlayerPrefs.HasKey("disclaimer") || PlayerPrefs.GetInt("disclaimer")==0)
        {
            startFadeTo1();
            PlayerPrefs.SetInt("disclaimer", 1);
        }
        else
        {
            mm.alpha = 1;
            mm.interactable = true;
            mm.blocksRaycasts = true;
        }
	}

    public void startFadeTo1()
    {
        startTime = Time.time;
        fadeDisclaimerTo1 = true;
        cg.interactable = true;
        cg.blocksRaycasts = true;
        Invoke("startFadeTo0", wantedTime + 7.5F);

    }

    public void startFadeTo0()
    {  
        fadeDisclaimerTo1 = false;
        startTime = Time.time;
        fadeTo0 = true;
        Invoke("fadeMainMenuTo1", wantedTime);
    }

    public void fadeMainMenuTo1()
    {
        cg.interactable = false;
        cg.blocksRaycasts = false;
        fadeTo0 = false;
        startTime = Time.time;
        fadeTo1 = true;
        Invoke("toggleInteractable", wantedTime);

    }

    public void skip()
    {
        cg.interactable = false;
        cg.blocksRaycasts = false;
        fadeTo0 = false;
        fadeTo1 = false;
        cg.alpha = 0;
        mm.alpha = 1;
        toggleInteractable();
        this.enabled = false;
    }

    public void toggleInteractable()
    {
        mm.interactable = true;
        mm.blocksRaycasts = true;
    }

	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
            skip();

        t = (Time.time - startTime) / wantedTime;

        if (fadeTo0)
        {
            fadeTo1 = false;
            cg.alpha = Mathf.Lerp(1, 0, t);
        }

        if (fadeTo1)
        {
            fadeTo0 = false;
            mm.alpha = Mathf.Lerp(0, 1, t);
        }

        if (fadeDisclaimerTo1)
        {
            cg.alpha = Mathf.Lerp(0, 1, t);
            fadeTo0 = fadeTo1 = false;
        }

        if (mm.alpha == 1)
            this.enabled = false;
	}
}
