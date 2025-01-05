using System;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private InteractiveCursorControls controls;

    [SerializeField]
    private InteractablesManager interactablesManager;

    [SerializeField]
    private Texture2D interactiveCursorTexture;
    
    private CursorController interactiveCursor;

    [SerializeField]
    private Transform newSelectionTransform;
    private Transform currentSelectionTransform;

    public static Action MakeCursorDefault;
    public static Action MakeCursorInteractive;
    private bool cursorIsInteractive = false;
    public float DistanceThreshold;

    void Awake() {
        controls = new InteractiveCursorControls();
        controls.Mouse.Click.performed += _ => EndedClick();
        MakeCursorDefault += DefaultCursorTexture;
        MakeCursorInteractive += InteractiveCursorTexture;
    }

    private void OnEnable(){
        controls.Enable();
    }

    private void OnDisable(){
        controls.Disable();
    }

    private void Update(){
        FindInteractablesWithinDistanceThreshold();
    }

    private void FindInteractablesWithinDistanceThreshold(){
        newSelectionTransform = null;

        // for every interactable point 
        for (int itemIndex = 0; itemIndex < interactablesManager.Interactables.Count; itemIndex++){
            Vector3 fromMouseToInteractableOffset = interactablesManager.Interactables[itemIndex].position - new Vector3(controls.Mouse.Position.ReadValue<Vector2>().x, controls.Mouse.Position.ReadValue<Vector2>().y, 0f);
            float sqrMag = fromMouseToInteractableOffset.sqrMagnitude;
            
            //search if mouse is near an interactable point
            if (sqrMag < DistanceThreshold * DistanceThreshold){
                newSelectionTransform = interactablesManager.Interactables[itemIndex].transform;
                
                //if cursor is near an interactable point change cursorTexture
                if (!cursorIsInteractive){
                    InteractiveCursorTexture();
                }
                break;
            }
        }

        if (currentSelectionTransform != newSelectionTransform){
            currentSelectionTransform = newSelectionTransform;
            DefaultCursorTexture();
        }
    }

    //change cursor texture when interactive
    private void InteractiveCursorTexture(){
        cursorIsInteractive = true;
        Vector2 hotspot = new Vector2 (interactiveCursorTexture.width/2, 0);
        Cursor.SetCursor(interactiveCursorTexture, hotspot, CursorMode.Auto);
    }

    //change cursor texture when not interactive
    public void DefaultCursorTexture(){
        cursorIsInteractive = false;
        Cursor.SetCursor(default, default, default);
    }

    private void EndedClick(){
        TextCanvas.OnHideText?.Invoke();
        OnClickInteractable();
    }
    
    private void OnClickInteractable(){
        if(newSelectionTransform != null){
            IInteractable interactable = newSelectionTransform.gameObject.GetComponent<IInteractable>();
            if (interactable != null) {interactable.OnClickAction();}
            newSelectionTransform = null;
        }
    }

}
