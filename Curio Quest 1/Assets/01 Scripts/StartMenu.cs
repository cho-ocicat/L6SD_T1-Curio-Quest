using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(2);
    }
}
