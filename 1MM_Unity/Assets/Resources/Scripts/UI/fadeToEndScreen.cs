using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fadeToEndScreen : MonoBehaviour {

    public float startTime, t, wantedTime;
    public bool fadeTo1;

    public CanvasGroup cg;

    public void startFadeTo1()
    {
        startTime = Time.time;
        fadeTo1 = true;
        cg.interactable = true;
        cg.blocksRaycasts = true;

    }
	
	void Update () {

        t = (Time.time - startTime) / wantedTime;

        if (fadeTo1)
        {
            cg.alpha = Mathf.Lerp(0, 1, t);
        }

	}
}
