using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance {get; private set;}

    [SerializeField]
    private List<ItemScriptableObject> InventoryItems;

    private void Awake(){
        Instance = this;
    }

    public bool CheckInventory(ItemScriptableObject item){
        if(item.RequiredItemsId.Contains(-1)){
            Debug.Log("Oggetto pick up");
            AddItemInInventory(item);
            return true; // simple pick up object
        }
        else {
            int numFoundObjects = 0;
            Debug.Log(InventoryItems);
            if(InventoryItems != null){        
                foreach(ItemScriptableObject it in InventoryItems){
                    if(item.RequiredItemsId.Contains(it.Id)){
                        numFoundObjects++;
                    }
                }
                if(numFoundObjects == item.RequiredItemsId.Count){ //if all inventory items are found
                    AddItemInInventory(item);
                    RemoveItemInInventoryById(item.RequiredItemsId);
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
        InventoryItems.Add(item);
        if(item.InventoryImgTag != null)
            CanvasInventory.OnAddInventoryObject.Invoke(item.InventoryImgTag);
        else
            Debug.Log($"{item} string is null");
    }

    public void RemoveItemInInventoryById(List<int> Ids){
        for (int i=0; i<Ids.Count; i++){
            foreach(ItemScriptableObject item in InventoryItems){
                if (Ids[i] == item.Id){
                    InventoryItems.Remove(item);
                    CanvasInventory.OnRemoveInventoryObject.Invoke(item.InventoryImgTag);
                    break;
                }
            }
        }
    }
}
