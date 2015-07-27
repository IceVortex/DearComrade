using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class approvalText : MonoBehaviour {

    public Color negativeApprovalColor, positiveApprovalColor;
    public Text text;
    public AResources resources;

	void Start () {
        text = GetComponent<Text>();
	}
	
	void Update () 
    {
        if (resources.approval >= 0)
        {
            text.text = ((int)resources.approval).ToString();
            text.color = positiveApprovalColor;
        }
        else
        {
            text.text = ((int)resources.approval).ToString();
            text.color = negativeApprovalColor;
        }
	}
}
