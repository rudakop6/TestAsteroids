using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public void OnNewGame()
    {
        MySceneManager.instance.StartNewGame();
    }

    public void OnScore()
    {

    }

    public void OnExit()
    {
        MySceneManager.instance.QuitGame();
    }
}
