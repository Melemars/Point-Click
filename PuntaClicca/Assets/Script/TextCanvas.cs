using System;
using TMPro;
using UnityEngine;

public class TextCanvas : MonoBehaviour
{
    public static Action <ItemScriptableObject, int> OnShowInteractionText;
    public static Action OnHideText;
    public static Action <ItemScriptableObject> OnShowYesText;
    public static Action <ItemScriptableObject> OnShowErrorMinigameText;

    [SerializeField]
    private GameObject Bg_text;

    [SerializeField]
    private GameObject characterPortrait;
   
    [SerializeField]
    private Sprite mainCharactePortrait;

    [SerializeField]
    private TextMeshProUGUI charText;

    private void OnEnable(){
        HideText();
        OnShowInteractionText += CheckNumInteractionPhrase;
        OnHideText += HideText;
        OnShowYesText += YesText;
        OnShowErrorMinigameText += ErrorMinigameText;
    }

    private void OnDisable() {
        OnShowInteractionText -= CheckNumInteractionPhrase;
        OnHideText -= HideText;
        OnShowYesText -= YesText;
        OnShowErrorMinigameText -= ErrorMinigameText;
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
        Debug.Log(Bg_text);
        if(Bg_text != null){
            Bg_text.SetActive(true);
            charText.text = newText; 
        }
    }

    private void HideText(){
        Debug.Log(Bg_text);
        if(Bg_text != null)
            Bg_text.SetActive(false);
    }

    private void ErrorMinigameText(ItemScriptableObject item){
        ShowText(item.errorMinigamePhrase);
        ChangeCharacterPortrait(item);
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
