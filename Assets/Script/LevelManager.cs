using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float autoLoadLevelTimer;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Invoke("LoadNextLevel", autoLoadLevelTimer);
        }

    }


  
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   

}
