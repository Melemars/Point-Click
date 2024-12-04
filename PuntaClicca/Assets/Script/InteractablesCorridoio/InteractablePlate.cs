using UnityEngine;

public class InteractablePlate : MonoBehaviour, IInteractable
{
    [SerializeField]
    private ItemScriptableObject plate;
    private int numInteractionPhrase = 0;

    public void OnClickAction()
    {
        TextCanvas.OnShowInteractionText(plate, numInteractionPhrase);
        numInteractionPhrase++;
    }
}
