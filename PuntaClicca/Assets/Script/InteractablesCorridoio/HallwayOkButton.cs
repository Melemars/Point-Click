using UnityEngine;
using UnityEngine.Playables;

public class HallwayOkButton : MonoBehaviour
{
    [SerializeField] private GameObject MinigameCanvas;
    [SerializeField] private ItemScriptableObject doorEvent;
    [SerializeField] private PlayableDirector director;
    private bool orderMatters = false;
    public void OkButton()
    {
        if (Minigame.Instance.CheckMinigamePuzzle(orderMatters))
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
