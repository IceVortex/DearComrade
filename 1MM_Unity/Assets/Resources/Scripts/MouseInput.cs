using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {

    public Vector2 inputWorldPosition;
    public GameObject window;
    private Ray2D ray;
    public Collider2D clickedOn;
    public Camera cam;

	void Start () {
        cam = GetComponent<Camera>();	
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics2D.OverlapPoint(cam.ScreenToWorldPoint(Input.mousePosition)))
            {
                clickedOn = Physics2D.OverlapPoint(cam.ScreenToWorldPoint(Input.mousePosition));
                if (window.GetComponent<hide>().hideTab == true)
                    window.GetComponent<hide>().toggle();
            }
            else
            {
                clickedOn = null;
                if (window.GetComponent<hide>().hideTab == false)
                    window.GetComponent<hide>().toggle();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (window.GetComponent<hide>().hideTab == false)
                window.GetComponent<hide>().toggle();
        }

	}
}
