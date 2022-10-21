using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public string firstLevel;
    public GameObject OptionsScreen;
    [SerializeField] private AudioClip SelectSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SoundManager.instance.PlaySound(SelectSound);
        SceneManager.LoadScene(firstLevel);
        Debug.Log("Starting Game...");
        
    }

    public void OpenOptions()
    {   
        SoundManager.instance.PlaySound(SelectSound);
        OptionsScreen.SetActive(true);
        
    }

    public void CloseOptions()
    {
        SoundManager.instance.PlaySound(SelectSound);
        OptionsScreen.SetActive(false);
        
    }

    public void QuitGame()
    {
        SoundManager.instance.PlaySound(SelectSound);
        Application.Quit();
        Debug.Log("Closing Game...");
    }
}
