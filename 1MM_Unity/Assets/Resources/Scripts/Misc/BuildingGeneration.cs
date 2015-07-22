using UnityEngine;
using System.Collections;

public class BuildingGeneration : MonoBehaviour {


    public GameObject hub, source;
    public float radius;
    public int steps, modifier;

    public Vector3 generate() 
    {
        steps++;
        float xPos, yPos;
        xPos = Random.Range(hub.transform.position.x - radius, hub.transform.position.x + radius);
        yPos = Random.Range(hub.transform.position.y - radius, hub.transform.position.y + radius);

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
            return new Vector3(xPos, yPos, 0);
        }

    }

}
