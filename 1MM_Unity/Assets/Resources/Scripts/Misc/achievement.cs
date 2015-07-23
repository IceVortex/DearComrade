using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class achievement : MonoBehaviour {

    public Text achievementTitle, achievementDescription;
    public Image achievementIcon;
    public hide h;
    public CanvasGroup cg;

	void Start () {
        cg = GetComponent<CanvasGroup>();
        h = GetComponent<hide>();
        achievementGet("Started the game!", "Ye did it!");
	}

    public void achievementGet(string name, string desc)
    {
        Invoke("toggleHide", 0.1F);   
        achievementTitle.text = name;
        achievementDescription.text = desc;
        Invoke("toggleHide", 5F);   
    }

    public void toggleHide()
    {
        h.toggle();
    }
}
