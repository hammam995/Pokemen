using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUi;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))        //pulsar escape para activar
        {
            if(GameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();

            }
        }

    }
    public void Resume()
    {
        pauseMenuUi.SetActive(false);           
        Time.timeScale = 1f;                    //pulsar "Resume" para volver a jugar
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;                //al pausar detiene el juego
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");         //carga menu principal
    }

    public void QuitGame()
    {
        Debug.Log("SALIENDO");          //sale del juego
        Application.Quit();
    }
}
