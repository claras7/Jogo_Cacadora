using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    public static GameController instance;

    void Start()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject); 
        }
    }

    void StartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName); 
    }
    
}

