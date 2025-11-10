// using System;
// using System.Numerics;
// using UnityEditor.MPE;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public PlayerController playerController;
    public Transform target;
    private Camera cam;
    public Vector3 offset;
    public float zoom = 5f;
    public float zoomSpeed = 0.5f;
    public float smoothSpeed = 0.125f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
    {
        if (playerController != null && playerController.isGameStarted)
        {
            Vector3 desiredPos = target.position + offset;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
            transform.position = new Vector3(smoothedPos.x, smoothedPos.y, transform.position.z);

            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, Time.deltaTime * zoomSpeed);
        }
        
    }
}
