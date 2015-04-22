using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class canBuild : MonoBehaviour {

    public CanvasGroup overlay;
    public bool requirementsMet;

	void Update () {

        if (requirementsMet)
        {
            overlay.alpha = 0;
            overlay.interactable = false;
            overlay.blocksRaycasts = false;
        }
        else
        {
            overlay.alpha = 1;
            overlay.interactable = true;
            overlay.blocksRaycasts = true;
        }

	}
}
