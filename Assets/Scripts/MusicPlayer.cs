using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    bool musicOn = true;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (PlayerPrefs.HasKey("MusicEnabled"))
        {
            if (PlayerPrefs.GetString("MusicEnabled") == "True") //if the setting says enabled 
            {
                musicOn = true;
            }
            else if (PlayerPrefs.GetString("MusicEnabled") == "False") //if the setting says disabled 
            {
                musicOn = false;
            }
        }
        SceneManager.activeSceneChanged += changedActiveScene;
        TryPlayMusic();
    }
    void TryPlayMusic()
    {
        if (musicOn)
        {//if we have enabled music then play the music 
            GetComponent<AudioSource>().Play();
        }
        else
        {//if not dont play it 
            GetComponent<AudioSource>().Stop();
        }
    }
    public void ToggleMusic() // call by Music ON/OFF button 
    {
        if (musicOn)
        {
            musicOn = false;
            PlayerPrefs.SetString("MusicEnabled", "False");
        }
        else
        {
            musicOn = true;
            PlayerPrefs.SetString("MusicEnabled", "True");
        }
        TryPlayMusic();
    }
    // Runs everytime we change the levels 
    void changedActiveScene(Scene curent, Scene sceneGoingTo)
    {
        if (sceneGoingTo.name == "Main Menu")
        {
            // if we goto the main menu to avoid duplicated we destroy this game object 
            Destroy(this.gameObject); // if we goto the main menu to avoid duplicated we destroy this game object 
        }
    }
}
