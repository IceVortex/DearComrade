using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hide : MonoBehaviour {

    public float wantedTime, startTime, t;
    public RectTransform tr;
    public bool hideTab;
    public Image src;
    public Sprite sh, h;

    void Awake()
    {
        hideTab = true;
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
        if (hideTab)
            tr.localPosition = new Vector3(Mathf.Lerp(tr.localPosition.x, -1690, t), tr.localPosition.y, tr.localPosition.z);
        else
            tr.localPosition = new Vector3(Mathf.Lerp(tr.localPosition.x, -832, t), tr.localPosition.y, tr.localPosition.z);
        if (hideTab == true)
        {
            src.sprite = sh;
        }
        else
            src.sprite = h;

	}
}
