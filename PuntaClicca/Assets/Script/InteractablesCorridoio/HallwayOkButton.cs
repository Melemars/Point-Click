using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class HallwayOkButton : MonoBehaviour
{
    [SerializeField] private GameObject MinigameCanvas;
    [SerializeField] private ItemScriptableObject doorEvent;
    [SerializeField] private PlayableDirector director;
    [SerializeField]
    private List<int> ObjectToRemove;
    
    private bool orderMatters = false;
    private bool phraseObjectsMatters = false;
    
    
    public void OkButton()
    {
        if (Minigame.Instance.CheckMinigamePuzzle(orderMatters, phraseObjectsMatters))
        {
            GameHandler.OnCanvasDisappear?.Invoke();
            MinigameCanvas.SetActive(false);
            TextCanvas.OnShowYesText(doorEvent);
            Inventory.Instance.RemoveItemInInventoryById(ObjectToRemove);
            //do things and remember to setActive(false) using timeline on Interactable which active Minigame
            //StoryManager.Instance.StartStory(director);
        }
        else
        {
            if (!phraseObjectsMatters){
                GameHandler.OnCanvasDisappear?.Invoke();
                MinigameCanvas.SetActive(false);
                TextCanvas.OnShowInteractionText(doorEvent, 0);
            }
            
        }
    }
}
