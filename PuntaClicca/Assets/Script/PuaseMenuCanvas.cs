using UnityEngine;
using UnityEngine.SceneManagement;
public class PuaseMenuCanvas : MonoBehaviour
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
        }
    }

    public void Resume()
    {
        _isPause = false;
        MainMenu.SetActive(false);
        GameHandler.OnCanvasDisappear?.Invoke();
    }

    public void ReturnStartScene()
    {
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
