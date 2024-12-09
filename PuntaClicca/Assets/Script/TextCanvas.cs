using System;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextCanvas : MonoBehaviour
{
    public static Action <ItemScriptableObject, int> OnShowInteractionText;
    public static Action OnHideText;
    public static Action <ItemScriptableObject> OnShowYesText;

    [SerializeField]
    private GameObject Bg_text;

    [SerializeField]
    private GameObject characterPortrait;
   
    [SerializeField]
    private Sprite mainCharactePortrait;

    [SerializeField]
    private TextMeshProUGUI charText;

    private void Awake(){
        HideText();
        OnShowInteractionText += CheckNumInteractionPhrase;
        OnHideText += HideText;
        OnShowYesText += YesText;
    }

    private void CheckNumInteractionPhrase(ItemScriptableObject item, int numInteraction){
        if(numInteraction<item.InteractionPhrases.Count){
            ShowText(item.InteractionPhrases[numInteraction]);
            ChangeCharacterPortrait(item);
        }
        else{
            ShowText(item.InteractionPhrases[item.InteractionPhrases.Count-1]);
            ChangeCharacterPortrait(item);
        }           
    }

    private void YesText(ItemScriptableObject item){
        ShowText(item.yesInteractionPhrase);
        ChangeCharacterPortrait(item);
    }

    private void ShowText(string newText){
        Bg_text.SetActive(true);
        charText.text = newText;
    }

    private void HideText(){
        Bg_text.SetActive(false);
    }

    private void ChangeCharacterPortrait(ItemScriptableObject item) {
        //if item characterSprite is not null, change sprite with new one
        if(item.characterSprite != null)
            characterPortrait.GetComponent<UnityEngine.UI.Image>().sprite = item.characterSprite;
        else 
        //if item characterSprite is null, change sprite with main character Sprite
            characterPortrait.GetComponent<UnityEngine.UI.Image>().sprite = mainCharactePortrait;
            
    }   

}