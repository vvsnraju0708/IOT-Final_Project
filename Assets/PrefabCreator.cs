using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject Dragonprefab;
    [SerializeField] private Vector3 prefabOffset;

    private GameObject dragon;
    private ARTrackedImageManager aRTrackedImageManager;

    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;

    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            dragon = Instantiate(Dragonprefab, image.transform);
            dragon.transform.position += prefabOffset;
        }
    }
}

