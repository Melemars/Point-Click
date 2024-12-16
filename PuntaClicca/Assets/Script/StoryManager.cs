using UnityEngine;
using UnityEngine.Playables;
public class StoryManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    
    public static StoryManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void StartStory(PlayableDirector timeline)
    {
        this.director = timeline;
        this.director.Play();
    }
    
}
