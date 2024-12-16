using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMan : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    

}
