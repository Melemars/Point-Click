using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ResolutionSettings : MonoBehaviour
{
    public Toggle FullscreenTog;
    public TMP_Dropdown ResDropDown;

    Resolution[] AllResolutions;
    bool _isFullscreen;
    int SelectedResolution;
    List<Resolution> SelectedResolutionList = new List<Resolution>();

    bool _resolutionFound; 

    private void Start()
    {
        _resolutionFound = false;
        _isFullscreen = true;
        AllResolutions = Screen.resolutions;

        List <string> resolutionStringList = new List <string>();
        string newRes;
        foreach (Resolution res in AllResolutions)
        {
            newRes = res.width.ToString() + " x " + res.height.ToString();
            if (!resolutionStringList.Contains(newRes))
            {
                resolutionStringList.Add(newRes);
                SelectedResolutionList.Add(res);
                if (!_resolutionFound)
                {
                    if (res.width == Screen.width && res.height == Screen.height)
                        _resolutionFound = true;
                    else
                        SelectedResolution++;
                }   
            }
           
        }
        ResDropDown.AddOptions(resolutionStringList);
        ResDropDown.value = SelectedResolution;
        ChangeToggleFullscreen();
    }

    public void ChangeResolution()
    {
        SelectedResolution = ResDropDown.value;
        Screen.SetResolution(SelectedResolutionList[SelectedResolution].width, SelectedResolutionList[SelectedResolution].height, _isFullscreen);
    }

    public void ChangeFullscreen()
    {
        _isFullscreen = FullscreenTog.isOn;
        Screen.SetResolution(SelectedResolutionList[SelectedResolution].width, SelectedResolutionList[SelectedResolution].height, _isFullscreen);
    }

    public void ChangeToggleFullscreen()
    {
        if (Screen.fullScreen)
        {
            FullscreenTog.isOn = true;
        }
        else
        {
            FullscreenTog.isOn = false;
        }
    }

}
