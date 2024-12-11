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
    
    public bool CheckMinigamePuzzle()
    {
        if (tryItems.Count() == 0 || tryItems.Count() != correctItems.Count())
        {
            //Debug.Log("false");
            OnMinigameEnd.Invoke();
            ClearTryList();
            return false;
        }
        
        for (int i = 0; i < this.tryItems.Count; i++)
        {
            //Debug.Log(this.tryItems[i].name);
            if (correctItems.Contains(this.tryItems[i]) == false)
            {
                OnMinigameEnd.Invoke();
                ClearTryList();
                return false;
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
}
