using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject interactableManager;
    [SerializeField] private Button bookButton;
    [SerializeField] private GameObject cursorManager;

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
        cursorManager.GetComponent<CursorController>().DefaultCursorTexture();
        if(bookButton != null)
        {
            bookButton.enabled = false;
        }
    }

    private void RestartInteractableManager()
    {
        interactableManager.SetActive(true);
        if (bookButton != null)
        {
            bookButton.enabled = true;
        }
    }

}
