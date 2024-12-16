using UnityEngine;
using UnityEngine.Playables;

public class HallwayOkButton : MonoBehaviour
{
    [SerializeField] private GameObject MinigameCanvas;
    [SerializeField] private ItemScriptableObject doorEvent;
    [SerializeField] private PlayableDirector director;
    
    public void OkButton()
    {
        if (Minigame.Instance.CheckMinigamePuzzle())
        {
            //do things and remember to setActive(false) using timeline on Interactable which active Minigame
            //StoryManager.Instance.StartStory(director);
            GameHandler.OnCanvasDisappear?.Invoke();
            MinigameCanvas.SetActive(false);
            TextCanvas.OnShowYesText(doorEvent);
        }
        else
        {
            GameHandler.OnCanvasDisappear?.Invoke();
            MinigameCanvas.SetActive(false);
            TextCanvas.OnShowInteractionText(doorEvent, 0);
        }
    }
}
