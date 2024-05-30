using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public jumpCannonForce jump;
    public GameObject paneldied;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dano"))
        {
            paneldied.SetActive(true);
            jump.enabled=false;
            Time.timeScale = 0f;
        }
 
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
