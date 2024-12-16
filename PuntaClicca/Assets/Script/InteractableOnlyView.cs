using UnityEngine;

public class InteractableOnlyView : MonoBehaviour, IInteractable
{
    [SerializeField]
    private ItemScriptableObject item;
    private int numInteractionPhrase = 0;

    public void OnClickAction()
    {
        TextCanvas.OnShowInteractionText(item, numInteractionPhrase);
        numInteractionPhrase++;
    }
}
