using UnityEngine;

public class InteractableItemsActivation : MonoBehaviour
{
    void OnEnable(){
		InteractablesManager.AddToInteractablesEvent.Invoke(transform);
	}

	void OnDisable(){
		InteractablesManager.RemoveFromInteractablesEvent.Invoke(transform);
	}

}
