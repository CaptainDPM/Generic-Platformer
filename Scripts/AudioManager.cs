using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer GameAudio;

    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            GameAudio.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
