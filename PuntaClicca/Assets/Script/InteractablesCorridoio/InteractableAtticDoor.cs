using UnityEngine;

public class InteractableAtticDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject MinigameCanvas;
    
    public void OnClickAction()
    {
        MinigameCanvas.SetActive(true);
        GameHandler.OnCanvasAppear?.Invoke();
    }
}
