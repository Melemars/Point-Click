using UnityEngine;
using UnityEngine.Playables;

public class InteractableOnlyInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayableDirector director;

    public void OnClickAction()
    {
        StoryManager.Instance.StartStory(director);
    }
}
