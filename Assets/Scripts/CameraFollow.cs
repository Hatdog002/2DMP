using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player's transform to follow
    public Vector3 offset; // Offset of the camera from the target
    public float smoothSpeed = 0.125f; // Smoothness of camera movement
    public float minY; // Minimum Y position for the camera
    public float minX; // Minimum X position for the camera
    public float maxX; // Maximum X position for the camera

    void LateUpdate()
    {
        if (target != null)
        {
            float targetX = Mathf.Clamp(target.position.x + offset.x, minX, maxX);
            float targetY = Mathf.Max(target.position.y + offset.y, minY);
            Vector3 desiredPosition = new Vector3(targetX, targetY, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
