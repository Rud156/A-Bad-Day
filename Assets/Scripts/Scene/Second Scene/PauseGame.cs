using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public GameObject pauseMenu;

    private bool gameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                gameIsPaused = false;
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                gameIsPaused = true;
            }
        }
    }
}
