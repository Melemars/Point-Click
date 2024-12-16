using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMan : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        if (PlayerPrefs.HasKey("Scene") && SceneManager.GetActiveScene().buildIndex != 0)
        {
            PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.Save();
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Scene"));
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Scene", 1);
        PlayerPrefs.Save();
        ChangeScene();
    }

    public void ContinueGame()
    {
        if (PlayerPrefs.HasKey("Scene"))
        {
            ChangeScene();        
        }
    }
    
}
