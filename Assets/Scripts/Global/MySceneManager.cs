using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoaderScene(1, 0);
        }
        else 
        {
            Destroy(gameObject);
        }  
    }

    public IEnumerator InitializeAfterTime(int load, int unload)
    {
        SceneManager.LoadScene(load, LoadSceneMode.Additive);
        yield return new WaitForEndOfFrame();
        SceneManager.UnloadSceneAsync(unload);
    }
    public void LoaderScene(int load, int unload)
    {
        StartCoroutine(InitializeAfterTime(load, unload));
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
