using UnityEngine;
using System.Collections;

public class lineRendererFunctionality : MonoBehaviour {

    
    public LineRenderer lr;
    public GameObject Target;
    public Material mat;
    public AResources resources;
	
	void Start () {
        
        lr = GetComponent<LineRenderer>();

        resources = GetComponent<IdManager>().res;
        
        lr.SetPosition(1, transform.position + Vector3.forward);
	}

    public void updateTarget(GameObject target)
    {
        Target = target;
        lr = GetComponent<LineRenderer>();
        resources = GetComponent<IdManager>().res;

        if (resources.buildings[target.GetComponent<IdManager>().buildingIndex].comradeIndex != 0)
        {
            lr.SetPosition(1, target.transform.position + Vector3.forward);
        }
        if (resources.buildings[target.GetComponent<IdManager>().buildingIndex].comradeIndex ==
                 gameObject.GetComponent<IdManager>().buildingIndex)
        {
            target.GetComponent<LineRenderer>().materials[0] = mat;
            lr.materials[0] = mat;
            lr.material = mat;
            target.GetComponent<LineRenderer>().material = mat;
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
