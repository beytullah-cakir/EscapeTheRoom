using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int nextLevel;


    public static LevelManager Instance;
    
    void Awake()
    {
        Instance = this;
    }



    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
