using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        print("morreu");
    }
    
}
