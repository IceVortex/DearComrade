using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class researchFrontEnd : MonoBehaviour {

    public CanvasGroup alreadyResearched, researchButton;
    public Text researchName, description;
    public int researchNumber;
    public GameObject laboratoryGO;

    public Laboratory lab = new Laboratory();

    public void research()
    {

    }

    void Start()
    {

        researchName.text = lab.titles[researchNumber];
        description.text = lab.descriptions[researchNumber];
    }

}
