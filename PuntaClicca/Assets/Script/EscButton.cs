using UnityEngine;

public class EscButton : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;
    
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
}
