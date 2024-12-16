using UnityEngine;
using UnityEngine.Playables;

public class InteractablePickUse : MonoBehaviour, IInteractable
{
    [SerializeField]
    private ItemScriptableObject item;
    private int numInteractionPhrase = 0;
    
    [SerializeField]
    private PlayableDirector director;
    
    public void OnClickAction()
    {
        if (Inventory.Instance.CheckInventory(item))
        {
            TextCanvas.OnShowYesText(item);
            StoryManager.Instance.StartStory(director);
        }
        else{
            TextCanvas.OnShowInteractionText(item, numInteractionPhrase);
            numInteractionPhrase++;
        } 
    }
}
