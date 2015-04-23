using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    private Vector3 lastState, currentState, lastTrendSmoothing;
    public Vector2 camera_next_pos;
    public Vector3 temp, input, x;

    public bool isMoving;

    public float zoom, t, zoomSmoothingTime, lastChange;
    public int correction, mouseSpeed, scrollSpeed, zoomSpeed;

    [Range(0.0f, 1.0f)]
    public float alpha, beta;

    public Camera cam;

	void Start () 
    {

        cam = GetComponent<Camera>();

        temp.y = transform.position.y;

        lastState = transform.position;
        currentState = transform.position;
        lastTrendSmoothing = Vector3.zero;

        KeyBindingManager.Instance.scrollEnabled = false;

	}

    void SmoothedPosition()
    {
        x.x = transform.position.x + input.x;
        x.y = transform.position.y + input.y;
        x.z = cam.orthographicSize + zoom;

        lastState = currentState;
        currentState = alpha * (x) + (1.0f - alpha) * (lastState + lastTrendSmoothing);
        lastTrendSmoothing = beta * (currentState - lastState) + (1.0f - beta) * lastTrendSmoothing;
    }

    Vector3 NextCameraPosition()
    {

        SmoothedPosition();

        temp.x = currentState.x;
        temp.y = currentState.y;

        return temp;
    }

    bool recievedInput()
    {
        bool ok = new bool();

        if (KeyBindingManager.Instance.scrollEnabled)
        {
            if (Input.mousePosition.x >= Screen.width - correction)
            {
                input.x = 1 * Time.deltaTime * scrollSpeed;
                ok = true;
            }
            if(Input.mousePosition.x <= correction)
            {
                input.x = -1 * Time.deltaTime * scrollSpeed;
                ok = true;
            }
            if(Input.mousePosition.y >= Screen.height - correction)
            {
                input.y = 1 * Time.deltaTime * scrollSpeed;
                ok = true;
            }
            if (Input.mousePosition.y <= correction)
            {
                input.y = -1 * Time.deltaTime * scrollSpeed;
                ok = true;
            }
        }
        if (Input.GetMouseButton(1))
        {
            input.x = -Input.GetAxis("Mouse X") / 4 * Time.deltaTime * mouseSpeed;
            input.y = -Input.GetAxis("Mouse Y") / 4 * Time.deltaTime * mouseSpeed;
            ok = true;
        }

        if (ok != true)
        {
            input.x = 0;
            input.y = 0;
            return false;
        
        }
        else
            return true;
    }

    void Update()
    {
        isMoving = false;
        if (recievedInput())
        {
            isMoving = true;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0 && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            zoom = -Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
            lastChange = Time.time;
        }
        else
        {
           zoom = Mathf.Lerp(zoom, 0, (Time.time - lastChange)/zoomSmoothingTime);
        }

        transform.position = NextCameraPosition();
        if (x.z > 3.5F)
            cam.orthographicSize = x.z;
        else
            cam.orthographicSize = 3.5F;
    }

    void LateUpdate()
    {
        
    }
}
