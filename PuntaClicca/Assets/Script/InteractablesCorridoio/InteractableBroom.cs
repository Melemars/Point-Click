using UnityEngine;

public class InteractableBroom : MonoBehaviour, IInteractable
{
    [SerializeField]
    private ItemScriptableObject broom;

    public void OnClickAction()
    {
        Debug.Log("Cliccato" + broom);
        if(Inventory.Instance == null){
            Debug.Log("Inventory.instance è null");
        }
        else 
            if(Inventory.Instance.CheckInventory(broom))
                Debug.Log("Oggetto raccolto");
            else 
                Debug.Log("Oggetto non raccolto");
    }
}
