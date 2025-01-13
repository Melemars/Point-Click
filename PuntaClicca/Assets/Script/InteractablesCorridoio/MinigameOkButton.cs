using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MinigameOkButton : MonoBehaviour
{
    [SerializeField] private GameObject MinigameCanvas;
    [SerializeField] private ItemScriptableObject Event;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private List<int> ObjectToRemove;
    
    [SerializeField] private bool orderMatters;
    [SerializeField] private bool phraseObjectsMatters;
    
    
    public void OkButton()
    {
        if (Minigame.Instance.CheckMinigamePuzzle(orderMatters, phraseObjectsMatters))
        {
            GameHandler.OnCanvasDisappear?.Invoke();
            //do things and remember to setActive(false) using timeline on Interactable which active Minigame
            TextCanvas.OnShowYesText(Event);
            StoryManager.Instance.StartStory(director);
            Inventory.Instance.RemoveItemInInventoryById(ObjectToRemove);
            MinigameCanvas.SetActive(false);
        }
        else
        {
            if (!phraseObjectsMatters){    
                TextCanvas.OnShowErrorMinigameText(Event);
            }
            GameHandler.OnCanvasDisappear?.Invoke();
            MinigameCanvas.SetActive(false);
        }
    }
}
