using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hide : MonoBehaviour {

    public float wantedTime, startTime, t;
    public RectTransform tr;
    public bool hideTab, useSprites, horizontal, vertical;
    public Image src;
    public Sprite sh, h;
    public float pos1, pos2;

    //-1690,-832

    void Start()
    {
        hideTab = true;
    }

    public void setFalse()
    {
        hideTab = false;
        startTime = Time.time;
    }

    public void setTrue()
    {
        hideTab = true;
        startTime = Time.time;
    }

    public void toggle()
    {
        if (hideTab == false)
            hideTab = true;
        else
            hideTab = false;

        startTime = Time.time;
    }

	void Update () {

        t = (Time.time - startTime)/wantedTime;

        if (vertical == true && hideTab)
        {
            tr.localPosition = new Vector3(tr.localPosition.x, Mathf.Lerp(tr.localPosition.y, pos1, t), tr.localPosition.z);
        }
        else if(vertical == true && !hideTab)
            tr.localPosition = new Vector3(tr.localPosition.x, Mathf.Lerp(tr.localPosition.y, pos2, t), tr.localPosition.z);

        if (hideTab && horizontal)
            tr.localPosition = new Vector3(Mathf.Lerp(tr.localPosition.x, pos1, t), tr.localPosition.y, tr.localPosition.z);
        else if(horizontal && !hideTab)
            tr.localPosition = new Vector3(Mathf.Lerp(tr.localPosition.x, pos2, t), tr.localPosition.y, tr.localPosition.z);

        if(useSprites)
        { 
            if (hideTab == true)
            {
                src.sprite = sh;
            }
            else
                src.sprite = h;
        }
	}
}
