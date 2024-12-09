using System;
using Unity.VisualScripting;
using UnityEngine;

public class MinigameObject : MonoBehaviour
{
    [SerializeField] private ItemScriptableObject item;
    private bool isActive = false;

    private void OnEnable()
    {
        Minigame.OnMinigameEnd += IsActiveFalse;
    }

    private void OnDisable()
    {
        Minigame.OnMinigameEnd -= IsActiveFalse;
    }
    
    public void CheckObjectInTryItems()
    {
        if (!isActive)
        {
            Minigame.Instance.tryItems.Add(item);
            isActive = true;
            Debug.Log(Minigame.Instance.tryItems.Count);
        }
        else
        {
            Minigame.Instance.tryItems.Remove(item);
            isActive = false;
            Debug.Log(Minigame.Instance.tryItems.Count);
        }
    }

    public void IsActiveFalse()
    {
        isActive = false;
    }
}
