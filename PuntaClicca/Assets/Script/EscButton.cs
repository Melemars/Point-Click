using UnityEngine;

public class EscButton : MonoBehaviour
{
    [SerializeField] private GameObject MinigameCanvas;
    
    public void EscMinigame()
    {
        Minigame.OnMinigameEnd.Invoke();
        Minigame.Instance.ClearTryList();
        MinigameCanvas.SetActive(false);
        GameHandler.OnCanvasDisappear?.Invoke();
    }
}
