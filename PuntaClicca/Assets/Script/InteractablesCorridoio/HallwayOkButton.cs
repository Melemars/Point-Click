using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HallwayOkButton : MonoBehaviour
{
    [SerializeField] private GameObject MinigameCanvas;
    [SerializeField] private ItemScriptableObject doorEvent;
    [SerializeField] private GameObject interactableManager;
    
    public void OkButton()
    {
        if (Minigame.Instance.CheckMinigamePuzzle())
        {
            //fai roba
            interactableManager.SetActive(true);
            MinigameCanvas.SetActive(false);
            //TextCanvas.OnShowYesText(doorEvent); //decommenta se vuoi una frase di yes quando finisce minigame
        }
        else
        {
            interactableManager.SetActive(true);
            MinigameCanvas.SetActive(false);
            TextCanvas.OnShowInteractionText(doorEvent, 0);
        }
    }
}
