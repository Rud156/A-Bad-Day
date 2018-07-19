using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{

    public GameObject pauseMenu;

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 0;
    }

}
