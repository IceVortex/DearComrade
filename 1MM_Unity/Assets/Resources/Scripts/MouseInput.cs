using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {

    public Vector2 inputWorldPosition;
    private Ray2D ray;
    public Collider2D clickedOn;
    public Camera cam;

	void Start () {
        cam = GetComponent<Camera>();	


	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics2D.OverlapPoint(cam.ScreenToWorldPoint(Input.mousePosition)))
            {
                clickedOn = Physics2D.OverlapPoint(cam.ScreenToWorldPoint(Input.mousePosition));
            }
            else
                clickedOn = null;
        }
	}
}
