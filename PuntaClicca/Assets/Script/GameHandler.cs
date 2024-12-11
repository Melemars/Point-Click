using System;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject interactableManager;

    public static Action OnCanvasAppear;
    public static Action OnCanvasDisappear;

    private void OnEnable()
    {
        OnCanvasAppear += StopInteractableManager;
        OnCanvasDisappear += RestartInteractableManager;
    }

    private void OnDisable()
    {
        OnCanvasAppear -= StopInteractableManager;
        OnCanvasDisappear -= RestartInteractableManager;
    }

    private void StopInteractableManager()
    {
        interactableManager.SetActive(false);
    }

    private void RestartInteractableManager()
    {
        interactableManager.SetActive(true);
    }
}
