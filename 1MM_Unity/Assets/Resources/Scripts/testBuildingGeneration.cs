using UnityEngine;
using System.Collections;

public class testBuildingGeneration : MonoBehaviour {


    public GameObject hub, source;
    public float radius;

	
	void Update () {
	
	}

    /*void OnGUI()
    {
        if (GUILayout.Button("Generate Random Building"))
        {
            generate();
        }
    }*/

    public Vector3 generate() 
    {
        float xPos, yPos;
        xPos = Random.Range(-radius, radius);
        yPos = Random.Range(-radius, radius);

        if (Physics2D.OverlapArea(new Vector2(xPos - 0.75F, yPos - 0.75F),
            new Vector2(xPos + 0.75F, yPos + 0.75F)))
        {
            return generate();
        }
        else
        {
            return new Vector3(xPos, yPos, 0);
        }

    }

}
