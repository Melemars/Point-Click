using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Toggle = UnityEngine.UIElements.Toggle;

public class OptionCanvas : MonoBehaviour
{
    
    [SerializeField] Toggle fullscreenToggle;
    private bool isFullScreen;
    private void Start()
    {

    }

    public void SetFullScreen()
    {
        isFullScreen = fullscreenToggle.value;
        
    }
}
