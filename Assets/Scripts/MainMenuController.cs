using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject buttonPlay, buttonExit;

    public void PlayButton()
    {
        StartCoroutine(CargarSceneSAsync());
        buttonPlay.SetActive(false);
        buttonExit.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    IEnumerator CargarSceneSAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LevelPistol");
        //asyncLoad.allowSceneActivation = false;
        while (asyncLoad.isDone == false)
        {
            //asyncLoad.progress   Para ver el progreso y poder hacer una barra de carga
            yield return null;
        } 
        //asyncLoad.allowSceneActivation = true;
    }
}
