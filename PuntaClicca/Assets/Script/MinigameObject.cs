using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
            transform.GetChild(0).gameObject.SetActive(true);
            Minigame.Instance.tryItems.Add(item);
            isActive = true;
            Debug.Log(Minigame.Instance.tryItems.Count);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            Minigame.Instance.tryItems.Remove(item);
            isActive = false;
            Debug.Log(Minigame.Instance.tryItems.Count);
        }
    }

    public void IsActiveFalse()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        isActive = false;
    }
}
