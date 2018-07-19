using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{

    public void LoadMainGame()
    {
        SceneManager.LoadScene(1);
    }
}
