using UnityEngine;

public class InteractableAtticDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject interactableManager;
    [SerializeField] private GameObject MinigameCanvas;


    public void OnClickAction()
    {
        MinigameCanvas.SetActive(true);
        interactableManager.SetActive(false);
    }
}
