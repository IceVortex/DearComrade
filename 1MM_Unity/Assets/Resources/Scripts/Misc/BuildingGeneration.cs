using UnityEngine;
using System.Collections;

public class BuildingGeneration : MonoBehaviour {


    public GameObject hub, source;
    public float radius;
    public int steps, modifier;

    /*void OnGUI()
    {
        if (GUILayout.Button("Generate Random Building"))
        {
            generate();
        }
    }*/

    public Vector3 generate() 
    {
        steps++;
        float xPos, yPos;
        xPos = Random.Range(-radius, radius);
        yPos = Random.Range(-radius, radius);

        if (Physics2D.OverlapArea(new Vector2(xPos - 1F, yPos - 1F),
            new Vector2(xPos + 1F, yPos + 1F)))
        {
            if (steps >= 20)
            {
                steps = 0;
                radius += 5;
            }
            return generate();
        }
        else
        {
            steps = 0;
            return new Vector3(xPos + hub.transform.position.x, yPos + hub.transform.position.x, 0);
        }

    }

}
