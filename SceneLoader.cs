using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        sceneIndex = (sceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        SceneManager.LoadScene(sceneIndex);

    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void Quit()
    {
        Application.Quit();
    }


}
