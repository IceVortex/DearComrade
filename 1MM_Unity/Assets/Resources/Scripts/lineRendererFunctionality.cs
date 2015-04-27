using UnityEngine;
using System.Collections;

public class lineRendererFunctionality : MonoBehaviour {

    
    public LineRenderer lr;

	
	void Start () {
        lr = GetComponent<LineRenderer>();

        lr.SetPosition(0, transform.position + Vector3.forward);
        lr.SetPosition(1, transform.position + Vector3.forward);
	}

    public void updateTarget(GameObject target)
    {
        lr.SetPosition(1, target.transform.position + Vector3.forward);
    }

}
