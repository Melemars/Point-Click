using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance {get; private set;}

    [SerializeField]
    private List<ItemScriptableObject> inventoryItems;

    private void Awake(){
        Instance = this;
    }

    public bool CheckInventory(ItemScriptableObject item, bool AddItemToInventory){
        if(item.RequiredItemsId.Contains(-1) && AddItemToInventory){
            Debug.Log("Oggetto pick up");
            AddItemInInventory(item);
            return true; // simple pick up object
        }
        else {
            int numFoundObjects = 0;
            Debug.Log(inventoryItems);
            if(inventoryItems != null){        
                foreach(ItemScriptableObject it in inventoryItems){
                    if(item.RequiredItemsId.Contains(it.Id)){
                        numFoundObjects++;
                    }
                }
                if(numFoundObjects == item.RequiredItemsId.Count && AddItemToInventory){ //if all inventory items are found
                    AddItemInInventory(item);
                    RemoveItemInInventoryById(item.RequiredItemsId);
                    return true;
                }
                else if (numFoundObjects == item.RequiredItemsId.Count && !AddItemToInventory)
                {
                    return true;
                }
                else {
                    return false;
                } 
                    
            }
            else {
                return false; //inventory empty
            }
        }
    }

    public void AddItemInInventory(ItemScriptableObject item){
        Debug.Log("Oggetto Add");
        inventoryItems.Add(item);
        if(item.InventoryImgTag != null)
            CanvasInventory.OnAddInventoryObject.Invoke(item.InventoryImgTag);
        else
            Debug.Log($"{item} string is null");
    }

    public void RemoveItemInInventoryById(List<int> Ids){
        for (int i=0; i<Ids.Count; i++){
            foreach(ItemScriptableObject item in inventoryItems){
                if (Ids[i] == item.Id){
                    inventoryItems.Remove(item);
                    CanvasInventory.OnRemoveInventoryObject.Invoke(item.InventoryImgTag);
                    break;
                }
            }
        }
    }
}
