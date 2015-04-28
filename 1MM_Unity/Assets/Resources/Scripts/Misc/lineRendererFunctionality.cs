using UnityEngine;
using System.Collections;

public class lineRendererFunctionality : MonoBehaviour {

    
    public LineRenderer lr;
    public GameObject Target;

	
	void Start () {
        lr = GetComponent<LineRenderer>();

        
        lr.SetPosition(1, transform.position + Vector3.forward);
	}

    public void updateTarget(GameObject target)
    {
        Target = target;
        lr.SetPosition(1, target.transform.position + Vector3.forward);
    }

    void Update()
    {
        
        lr.SetPosition(0, transform.position + Vector3.forward);


        if (Target)
            lr.SetPosition(1, Target.transform.position + Vector3.forward);
        else
            lr.SetPosition(1, transform.position + Vector3.forward);
    }

}
