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

    void generate() 
    {
        float xPos, yPos;
        xPos = Random.Range(-radius, radius);
        yPos = Random.Range(-radius, radius);

        if (Physics2D.OverlapArea(new Vector2(xPos - 0.75F, yPos - 0.75F),
            new Vector2(xPos + 0.75F, yPos + 0.75F)))
        {
            generate();
        }
        else
        {
            GameObject.Instantiate(source, new Vector3(xPos + hub.transform.position.x, yPos + hub.transform.position.y, 0), Quaternion.identity);
        }

    }

}
