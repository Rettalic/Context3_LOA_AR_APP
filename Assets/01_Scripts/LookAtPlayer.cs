using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    // Find the main camera

    // Update is called once per frame
    void Update()
    {
        Camera mainCamera = Camera.main;
        // Calculate the direction to the camera without changing the object's up vector
        Vector3 directionToCamera = mainCamera.transform.position - transform.position;
        directionToCamera.y = 0f; // Optional: Set the y component to zero to restrict rotation to the horizontal plane

        // Make the object look at the camera
        transform.rotation = Quaternion.LookRotation(directionToCamera.normalized, Vector3.up);
    }
}
