using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMainMenu : MonoBehaviour
{

    public GameObject PauseUI;

    public bool paused = false;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


// Use this for initialization
void Start()
    {
        PauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("A"))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Reasumen()

    {
        paused = !paused;
        Debug.Log("Resume");
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
        Debug.Log("Restart");
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);

        Debug.Log("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
