using System;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasInventory : MonoBehaviour
{
    public static Action <string> OnAddInventoryObject;
    public static Action <string> OnRemoveInventoryObject;
    private GameObject canvasObject;
    
    private void Awake() {
        OnAddInventoryObject += AddInventoryCanvas;
        OnRemoveInventoryObject += RemoveInventoryCanvas;
    }

    private void AddInventoryCanvas(string Inventorytag){
        //it.InventorySlot.SetActive(true);
        canvasObject = GameObject.FindGameObjectWithTag(Inventorytag);
        canvasObject?.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void RemoveInventoryCanvas(string Inventorytag){
        //it.InventorySlot.SetActive(false);
        canvasObject = GameObject.FindGameObjectWithTag(Inventorytag);
        canvasObject?.transform.GetChild(0).gameObject.SetActive(false);
    }
}
