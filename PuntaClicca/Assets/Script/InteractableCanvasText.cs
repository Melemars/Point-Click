using UnityEngine;

public class InteractableCanvasText : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject CanvasText;
    [SerializeField] private ItemScriptableObject item;
    private int numInteractionPhrase = 0;
    public void OnClickAction()
    {
        CanvasText.SetActive(true);
        TextCanvas.OnShowInteractionText(item, numInteractionPhrase);
        numInteractionPhrase++;
        GameHandler.OnCanvasAppear?.Invoke();
    }
}
