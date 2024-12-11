using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HallwayOkButton : MonoBehaviour
{
    [SerializeField] private GameObject MinigameCanvas;
    [SerializeField] private ItemScriptableObject doorEvent;
    
    
    public void OkButton()
    {
        if (Minigame.Instance.CheckMinigamePuzzle())
        {
            //do things and remember to setActive(false) using timeline on Interactable which active Minigame
            GameHandler.OnCanvasDisappear?.Invoke();
            MinigameCanvas.SetActive(false);
            //TextCanvas.OnShowYesText(doorEvent);
        }
        else
        {
            GameHandler.OnCanvasDisappear?.Invoke();
            MinigameCanvas.SetActive(false);
            TextCanvas.OnShowInteractionText(doorEvent, 0);
        }
    }
}
