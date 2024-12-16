using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Credits;
    [SerializeField] private GameObject Options;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
           StartMenu();
    }

    public void StartMenu()
    {
        MainMenu.SetActive(true);
        Credits.SetActive(false);
        Options.SetActive(false);
    }
    
    public void CreditsMenu()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
        Options.SetActive(false);
    }

    public void OptionsMenu()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(false);
        Options.SetActive(true);
    }
    
    public void Back()
    {
        StartMenu();
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
