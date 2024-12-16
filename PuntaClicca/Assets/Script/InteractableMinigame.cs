using UnityEngine;

public class InteractableMinigame : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject MinigameCanvas;
    [SerializeField] private ItemScriptableObject itemEvent;
    private int numInteractionPhrase = 1;
    
    public void OnClickAction()
    {
        if(Inventory.Instance.CheckInventory(itemEvent))
        {
            MinigameCanvas.SetActive(true);
            GameHandler.OnCanvasAppear?.Invoke();
        } 
        else
        { 
            TextCanvas.OnShowInteractionText(itemEvent, numInteractionPhrase); 
            numInteractionPhrase++;
        }
    }
}
