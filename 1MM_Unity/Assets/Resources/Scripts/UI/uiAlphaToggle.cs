using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class uiAlphaToggle : MonoBehaviour {

    public CanvasGroup cg;

	void Start () 
    {
        cg = GetComponent<CanvasGroup>();
        cg.alpha = 0;
        Invoke("wait", 1);
    }

    void wait()
    {
        cg.alpha = 1;
    }

}
