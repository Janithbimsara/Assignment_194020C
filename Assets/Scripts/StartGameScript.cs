using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public string nextLevelSceneName = "Level 02";
    public void StartGame()
    {
        SceneManager.LoadScene(nextLevelSceneName);
    }
}
