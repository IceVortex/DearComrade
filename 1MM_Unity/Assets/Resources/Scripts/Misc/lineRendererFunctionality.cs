using UnityEngine;
using System.Collections;

public class lineRendererFunctionality : MonoBehaviour {

    
    public LineRenderer lr;
    public GameObject Target;
    public Material mat;

	
	void Start () {
        lr = GetComponent<LineRenderer>();

        
        lr.SetPosition(1, transform.position + Vector3.forward);
	}

    public void updateTarget(GameObject target)
    {
        if (GameResources.instance.buildings[target.GetComponent<IdManager>().buildingIndex].comradeIndex != 0)
        {
            Target = target;
            lr.SetPosition(1, target.transform.position + Vector3.forward);
        }
        else if (GameResources.instance.buildings[target.GetComponent<IdManager>().buildingIndex].comradeIndex ==
                 gameObject.GetComponent<IdManager>().buildingIndex)
        {
            target.GetComponent<LineRenderer>().materials[0] = mat;
        }
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
