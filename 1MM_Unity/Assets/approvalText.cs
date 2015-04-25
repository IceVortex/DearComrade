using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class approvalText : MonoBehaviour {

    public Color negativeApprovalColor, positiveApprovalColor;
    public Text text;

	void Start () {
        text = GetComponent<Text>();
	}
	
	void Update () 
    {
        if (GameResources.instance.approval >= 0)
        {
            text.text = ((int)GameResources.instance.approval).ToString();
            text.color = positiveApprovalColor;
        }
        else
        {
            text.text = ((int)GameResources.instance.approval).ToString();
            text.color = negativeApprovalColor;
        }
	}
}
