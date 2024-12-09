using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HallwayOkButton : MonoBehaviour
{
    [SerializeField] private GameObject MinigameCanvas;
    [SerializeField] private ItemScriptableObject doorEvent;
    [SerializeField] private GameObject interactableManager;
    
    public void OkButton()
    {
        if (Minigame.Instance.CheckMinigamePuzzle())
        {
            //do things and remember to setActive(false) using timeline on Interactable which active Minigame
            interactableManager.SetActive(true);
            MinigameCanvas.SetActive(false);
            //TextCanvas.OnShowYesText(doorEvent);
        }
        else
        {
            interactableManager.SetActive(true);
            MinigameCanvas.SetActive(false);
            TextCanvas.OnShowInteractionText(doorEvent, 0);
        }
    }
}
