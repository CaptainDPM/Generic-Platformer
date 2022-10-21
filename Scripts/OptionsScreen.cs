using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class OptionsScreen : MonoBehaviour
{
    
    public Toggle fullscreenTog, vsyncTog;
    public List <ResItem> resolution = new List<ResItem>();
    private int selectedResolution;
    public TMP_Text resolutionLabel;
    public AudioMixer GameAudio;
    public Slider masterSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        } else
        {
            vsyncTog.isOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ResLeft()
    {
        selectedResolution--;
        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedResolution++;
        if(selectedResolution > resolution.Count -1)
        {
            selectedResolution = resolution.Count -1;
        }
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolution[selectedResolution].horizontal.ToString() + " x " + resolution[selectedResolution].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        //Screen.fullScreen = fullscreenTog.isOn;

        if(vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        } else
        {
            QualitySettings.vSyncCount = 0;
        }

        Screen.SetResolution(resolution[selectedResolution].horizontal, resolution[selectedResolution].vertical, fullscreenTog.isOn);
    }

    public void SetMasterVol()
    {
        GameAudio.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}