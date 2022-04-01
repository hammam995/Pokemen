using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private static int score;
    AsyncOperation loadAsync;
    public Slider slide;
    public GameObject entmsg;
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
        //Record.InitializeStatic();
    }
    void Start()
    {
        StartCoroutine(nextsc());
    }
    void Update()
    {
        
    }

    public void ChangeScene(string scene)               //cambio de escenas
    {
        SceneManager.LoadScene(scene);
    }
    IEnumerator nextsc() //method for doing the load scene it depends on the object and for every stage it have it owens object by name , so if it was the name of the GameManager object GM it will load the scene for the firist stage , if it is name GM2 we are in loading scene for stage2 and it will load stage 2
    {
        //to go to loading scene 1 for stage 1
        if (gameObject.name == "GM") // in loading you must press space so you can go to the scene
        {
            loadAsync = SceneManager.LoadSceneAsync("Level 1");
            loadAsync.allowSceneActivation = false;
            while (loadAsync.progress < 0.9f)
            {
                slide.value = loadAsync.progress;
                yield return null;
            }
            yield return new WaitForSeconds(3);
            entmsg.gameObject.SetActive(true);
            //  slide.value = 1;
            slide.value = loadAsync.progress;
            slide.value = 1;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space)); // when the loading  finish you must press space button to go to the next scene or the stage everything
            loadAsync.allowSceneActivation = true;
        }
    }
    public void ChangeRes(Dropdown drop)
    {
        switch (drop.value)                                 //cambia resolucion
        {
            case 0:
                Screen.SetResolution(1024,768, true);
                break;
            case 1:
                Screen.SetResolution(1280, 720, true);
                break;

            case 2:
                Screen.SetResolution(1366, 768, true);
                break;
            case 3:
                Screen.SetResolution(1920, 1080, true);
                break;
        }
    }
    public void changeVolume (Slider slider)                //cambia volumen
    {
        AudioListener.volume = slider.value;
    }
    public void CloseApp()              //cierra el juego
    {
        Application.Quit();
    }
}