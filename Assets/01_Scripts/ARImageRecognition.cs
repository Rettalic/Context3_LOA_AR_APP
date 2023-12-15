using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARImageRecognition : MonoBehaviour
{
    public GameObject objectToInstantiate;
    private ARTrackedImageManager trackedImageManager;

    private void Start()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        // Subscribe to image tracking events
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            // Image detected, instantiate the object
            InstantiateObject(trackedImage);
        }
    }

    private void InstantiateObject(ARTrackedImage trackedImage)
    {
        // Instantiate your 3D object at the image's position and rotation
        GameObject instantiatedObject = Instantiate(objectToInstantiate, trackedImage.transform.position, trackedImage.transform.rotation);

        // Create an anchor for the instantiated object
        ARAnchor arAnchor = trackedImage.gameObject.AddComponent<ARAnchor>();

        // Attach the object to the anchor
        instantiatedObject.transform.parent = arAnchor.transform;
    }
}
