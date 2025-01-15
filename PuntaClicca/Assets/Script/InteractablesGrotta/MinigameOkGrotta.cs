using UnityEngine;
using UnityEngine.Playables;

public class MinigameOkGrotta : MonoBehaviour
{
    [SerializeField] private GameObject MinigameCanvas;
    [SerializeField] private ItemScriptableObject Event;
    [SerializeField] private PlayableDirector director;

    [SerializeField] private ItemScriptableObject objectToAdd;
    
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
            Inventory.Instance.CheckInventory(objectToAdd,true);
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