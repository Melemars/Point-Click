using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public static Action OnMinigameEnd;
    public static Minigame Instance {get; private set;} 
    
    [SerializeField] private List<ItemScriptableObject> correctItems;
    public List<ItemScriptableObject> tryItems;
    
    private void Awake(){
        Instance = this;
    }
    
    public bool CheckMinigamePuzzle(bool orderMatters, bool PhraseObjectsMatters)
    {
        if (tryItems.Count() == 0 || tryItems.Count() != correctItems.Count())
        {
            //Debug.Log("false");
            OnMinigameEnd.Invoke();
            if (tryItems.Count() != 0){
                CheckObjectPhrase(PhraseObjectsMatters, 0);
            }
            ClearTryList();
            return false;
        }

        if (!orderMatters)
        {
            for (int i = 0; i < this.tryItems.Count; i++)
            {
                //Debug.Log(this.tryItems[i].name);
                if (correctItems.Contains(this.tryItems[i]) == false)
                {
                    OnMinigameEnd.Invoke();
                    CheckObjectPhrase(PhraseObjectsMatters, i);
                    ClearTryList();
                    return false;
                }
            }
        }
        else if (orderMatters)
        {
            for (int i = 0; i < this.tryItems.Count; i++)
            {
                if (correctItems[i] != this.tryItems[i])
                {
                    OnMinigameEnd.Invoke();
                    CheckObjectPhrase(PhraseObjectsMatters, i);
                    ClearTryList();
                    return false; 
                }
            }
        }
        //Debug.Log(this.tryItems.Count);
        OnMinigameEnd.Invoke();
        ClearTryList();
        return true;
    }

    public void ClearTryList()
    {
        this.tryItems.Clear();
    }

    public void CheckObjectPhrase(bool PhraseObjectsMatters, int index){
        if (PhraseObjectsMatters)
            TextCanvas.OnShowErrorMinigameText(tryItems[index]);
    }
}
