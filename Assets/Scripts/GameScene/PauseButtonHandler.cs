using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pauseHud;

    public void GamePauseOn()
    {
        Time.timeScale = 0;
        _pauseHud.SetActive(true);
    }
    public void GamePauseOff()
    {
        Time.timeScale = 1;
        _pauseHud.SetActive(false);
    }

    public void QuitInMainClick()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void QuitInWindowsClick()
    {
        Application.Quit();
    }
}
