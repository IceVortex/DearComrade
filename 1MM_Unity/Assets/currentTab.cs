using UnityEngine;
using System.Collections;

public class currentTab : MonoBehaviour {

    public CanvasGroup[] tab;
    public hide h;
    public int lastClicked;

    void Start()
    {
        h = GetComponent<hide>();
    }

    public void chooseTab(int i)
    {
        if (i == lastClicked)
            h.toggle();
        else
            h.setFalse();

        lastClicked = i;

        for (int x = 0; x < tab.Length; x++)
        {
            tab[x].alpha = 0;
            tab[x].interactable = false;
            tab[x].blocksRaycasts = false;
            
        }
        tab[i].alpha = 1;
        tab[i].interactable = true;
        tab[i].blocksRaycasts = true;
    }
	
}
