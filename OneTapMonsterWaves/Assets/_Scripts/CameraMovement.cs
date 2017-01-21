using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Camera _camera;

    public Vector3 movementVelocity = Vector3.zero;
    public float movementSmoothTime = 0.3F;

    private Vector3 targetPosition;
    private Vector3 originalPosition;

    // Use this for initialization
    void Start()
    {
        _camera = gameObject.GetComponent<Camera>();
        targetPosition = transform.position;
        originalPosition = transform.position;

        Grid.EventHub.PlayerReachedTopEvent += MoveCamera;
    }

    void Destroy()
    {
        Grid.EventHub.PlayerReachedTopEvent -= MoveCamera;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref movementVelocity, movementSmoothTime);
    }

    void MoveCamera(int screenNumber)
    {
        Vector3 position = new Vector3(originalPosition.x, originalPosition.y + _camera.orthographicSize * 2 * screenNumber, originalPosition.z);
        targetPosition = position;
    }
}
