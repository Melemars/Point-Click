using UnityEngine;

public class InteractableBroom : MonoBehaviour, IInteractable
{
    [SerializeField]
    private ItemScriptableObject broom;
    private int numInteractionPhrase = 0;

    public void OnClickAction()
    {
        if(Inventory.Instance.CheckInventory(broom))
            TextCanvas.OnShowYesText(broom);
        else{
            TextCanvas.OnShowInteractionText(broom, numInteractionPhrase);
            numInteractionPhrase++;
        } 
    }
}
