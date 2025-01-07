using UnityEngine;
using UnityEngine.Playables;

public class EscButton : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;
    [SerializeField] private PlayableDirector director;

    public void EscMinigame()
    {
        Minigame.OnMinigameEnd.Invoke();
        Minigame.Instance.ClearTryList();
        EscCanvas();
    }

    public void EscCanvas()
    {
        Canvas.SetActive(false);
        GameHandler.OnCanvasDisappear?.Invoke();
    }

    public void EscWithTimeline(){
        if (director != null){
            StoryManager.Instance.StartStory(director);
            director = null;
        }
        EscCanvas();
    }
}
