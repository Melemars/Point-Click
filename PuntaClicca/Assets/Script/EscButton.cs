using UnityEngine;

public class EscButton : MonoBehaviour
{
    [SerializeField] private GameObject MinigameCanvas;
    [SerializeField] private GameObject interactableManager;
    
    public void EscMinigame()
    {
        Minigame.OnMinigameEnd.Invoke();
        Minigame.Instance.ClearTryList();
        MinigameCanvas.SetActive(false);
        interactableManager.SetActive(true);
    }
}
