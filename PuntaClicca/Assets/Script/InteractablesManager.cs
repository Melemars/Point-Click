using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesManager : MonoBehaviour
{
    //list of all interactables positions
    [SerializeField]
    private List<Transform> interactables;
    public List<Transform> Interactables {get => interactables;}

    private Camera mainCamera;

    public static Action<Transform> AddToInteractablesEvent;
    public static Action<Transform> RemoveFromInteractablesEvent;

    private void Awake() {
        AddToInteractablesEvent += AddToListOfInteractables;
        RemoveFromInteractablesEvent += RemoveFromListOfInteractables;
    }

    private void AddToListOfInteractables(Transform transformToAddToList){
        interactables.Add(transformToAddToList);
    }

    private void RemoveFromListOfInteractables(Transform transformToRemoveToList){
        interactables.Remove(transformToRemoveToList);
    }

    void Start()
    {
        mainCamera = Camera.main;
        AllChildrenWorldToScreenPoint();
    }

    // find and transform all interactable points into world positions
    private void AllChildrenWorldToScreenPoint() {
        for (int i=0; i<this.transform.childCount; i++) {
            transform.GetChild(i).position = mainCamera.WorldToScreenPoint(transform.GetChild(i).position);

            transform.GetChild(i).localScale = Vector3.one * 100;
        }
    }

}
