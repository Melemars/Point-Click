using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    [SerializeField] private GameObject ContinueButton;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.HasKey("Scene"))
            ContinueButton.SetActive(true);
        else
            ContinueButton.SetActive(false);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
}
