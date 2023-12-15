using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ObjectInstantiation : MonoBehaviour
{
    public GameObject objectToInstantiate;
    private ARRaycastManager arRaycastManager;
    private ARPlaneManager arPlaneManager;
    public bool startBut;

    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        arPlaneManager = FindObjectOfType<ARPlaneManager>();
    }

    public void PressButton()
    {
        startBut = true;
    }
    void Update()
    {
        // Check for button press
        if (startBut)// You can customize this based on your input settings
        {
            // Raycast from the center of the screen to find a plane
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRaycastManager.Raycast(ray, hits, TrackableType.PlaneWithinPolygon))
            {
                // Instantiate the object at the hit point
                GameObject spawnedObject = Instantiate(objectToInstantiate, hits[0].pose.position, hits[0].pose.rotation);

                // Attach the object to the detected plane
                AttachObjectToPlane(spawnedObject, hits[0].trackableId);
            }
        }
    }

    void AttachObjectToPlane(GameObject obj, TrackableId planeId)
    {
        // Find the plane in the ARPlaneManager
        ARPlane arPlane = null;

        foreach (var plane in arPlaneManager.trackables)
        {
            if (plane.trackableId == planeId)
            {
                arPlane = plane;
                break;
            }
        }

        if (arPlane != null)
        {
            // Attach the object to the plane
            obj.transform.SetParent(arPlane.transform);
        }
    }
}
