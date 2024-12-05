using System;
using TMPro;
using UnityEngine;

public class TextCanvas : MonoBehaviour
{
    public static Action <ItemScriptableObject, int> OnShowInteractionText;
    public static Action OnHideText;
    public static Action <string> OnShowYesText;

    [SerializeField]
    private GameObject Bg_text;

    [SerializeField]
    private TextMeshProUGUI charText;

    private void Awake(){
        HideText();
        OnShowInteractionText += CheckNumInteractionPhrase;
        OnHideText += HideText;
        OnShowYesText += ShowText;
    }

    private void CheckNumInteractionPhrase(ItemScriptableObject item, int numInteraction){
        if(numInteraction<item.InteractionPhrases.Count)
            ShowText(item.InteractionPhrases[numInteraction]);
        else
            ShowText(item.InteractionPhrases[item.InteractionPhrases.Count-1]);
    }

    private void ShowText(string newText){
        Bg_text.SetActive(true);
        charText.text = newText;
    }

    private void HideText(){
        Bg_text.SetActive(false);
    }

}
