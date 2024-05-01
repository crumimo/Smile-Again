using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Reference to the player's transform
    public float smoothSpeed = 0.125f;   // Smoothing factor for camera movement

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position for the camera
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Smoothly interpolate between the current camera position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position to the smoothed position
            transform.position = smoothedPosition;
        }
    }
}
