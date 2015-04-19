using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public Transform target;

    private Vector3 lastState, currentState, lastTrendSmoothing;
    private Vector3 camera_next_pos;
    private Vector3 temp;

    public float dist_x, dist_z;
    private float lerpTime = 1f, currentLerpTime, t;

    [Range(0.0f, 1.0f)]
    public float alpha, beta;

	void Start () 
    {
        temp.y = transform.position.y;

        lastState = target.position;
        currentState = target.position;
        lastTrendSmoothing = Vector3.zero;
	}

    void SmoothedPosition()
    {
        lastState = currentState;
        currentState = alpha * target.transform.position + (1.0f - alpha) * (lastState + lastTrendSmoothing);
        lastTrendSmoothing = beta * (currentState - lastState) + (1.0f - beta) * lastTrendSmoothing;
    }

    Vector3 NextCameraPosition()
    {

        SmoothedPosition();

        temp.x = currentState.x - dist_x;
        temp.z = currentState.z - dist_z;

        return temp;
    }

	void LateUpdate () 
    {
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime)
            currentLerpTime = lerpTime;

        t = currentLerpTime / lerpTime;
        t = t * t * t * (t * (6f * t - 15f) + 10f);

        transform.position = Vector3.Lerp(transform.position, NextCameraPosition(), t);

	}
}
