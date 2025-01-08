using UnityEngine;
using UnityEngine.Playables;

public class InteractableOnlyInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayableDirector director;

    public void OnClickAction()
    {
        CursorController.MakeCursorDefault();
        StoryManager.Instance.StartStory(director);
    }
}
