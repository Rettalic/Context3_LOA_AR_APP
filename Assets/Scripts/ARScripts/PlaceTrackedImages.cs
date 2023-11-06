using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class PlaceTrackedImages : MonoBehaviour
{
    private ARTrackedImageManager ImgManager;
    public GameObject[] ARPrefabs;

    private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();


    private void Awake()
    {
        ImgManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        ImgManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        ImgManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            var imgName = trackedImage.referenceImage.name;
            foreach (var curPrefab in ARPrefabs)
            {
                if ((string.Compare(curPrefab.name, imgName, System.StringComparison.OrdinalIgnoreCase) == 0) && !_instantiatedPrefabs.ContainsKey(imgName))
                {
                    var newPrefab = Instantiate(curPrefab, trackedImage.transform);
                    _instantiatedPrefabs[imgName] = newPrefab;
                }
            }
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            _instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
        }

        foreach (var trackedImage in eventArgs.removed) { 
             Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
            _instantiatedPrefabs.Remove(trackedImage.referenceImage.name);
        }

    }
}

