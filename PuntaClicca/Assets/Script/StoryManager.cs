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

    void Start() {
        Debug.Log("Ciao");
        this.director.Play();  
    }

    public void StartStory(PlayableDirector timeline)
    {
        this.director = timeline;
        this.director.Play();
    }
    
}
