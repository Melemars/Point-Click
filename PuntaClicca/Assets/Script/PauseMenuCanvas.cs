using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuCanvas : MonoBehaviour
{

    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Options;

    private bool _isPause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _isPause = false;
        MainMenu.SetActive(false);
        Options.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isPause)
        {
            _isPause=true;
            MainMenu.SetActive(true);
            GameHandler.OnCanvasAppear?.Invoke(); 
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        _isPause = false;
        MainMenu.SetActive(false);
        GameHandler.OnCanvasDisappear?.Invoke();
        Time.timeScale = 1f;
        
    }

    public void ReturnStartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OptionsMenu()
    {
        MainMenu.SetActive(false);
        Options.SetActive(true);
    }

    public void Back()
    {
        MainMenu.SetActive(true);
        Options.SetActive(false);
    }


}
