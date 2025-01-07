using UnityEngine;
using UnityEngine.Playables;

public class InteractablePickUse : MonoBehaviour, IInteractable
{
    [SerializeField]
    private ItemScriptableObject item;
    private int numInteractionPhrase = 0;
    [SerializeField]
    private bool AddItem;
    [SerializeField]
    private bool isAMinigameObject; //true only if is a minigame object and phraseObjectsMatters == true in MinigameOkButton
    [SerializeField]
    private PlayableDirector director;
    
    private void Start() {
        if (isAMinigameObject){
            numInteractionPhrase = 1;
        }
    }

    public void OnClickAction()
    {
        if (Inventory.Instance.CheckInventory(item, AddItem))
        {
            //when you click the object, active a timeline or, if is not necessary, simply disable the object
            if(director != null)
                StoryManager.Instance.StartStory(director);
            else 
                this.gameObject.SetActive(false);
            TextCanvas.OnShowYesText(item);
        }
        else{
            TextCanvas.OnShowInteractionText(item, numInteractionPhrase);
            numInteractionPhrase++;
        } 
    }
}
