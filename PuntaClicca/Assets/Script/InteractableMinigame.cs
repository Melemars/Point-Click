using UnityEngine;

public class InteractableMinigame : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject MinigameCanvas;
    [SerializeField] private ItemScriptableObject itemEvent;
    private bool AddItem = false;
    private int numInteractionPhrase = 0;
    
    public void OnClickAction()
    {
        if(Inventory.Instance.CheckInventory(itemEvent, AddItem))
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
