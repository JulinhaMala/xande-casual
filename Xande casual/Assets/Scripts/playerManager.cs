using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerManager : MonoBehaviour
{
    [Header("Transforme da Camera")]
    public Transform cam;

    [Header("Transforme do Player")]
    public Transform player;

    [Header("Obj do Boss")]
    public GameObject Boss;

    [Header("Audio do Ambiente")]
    public AudioSource musicAmb;

    [Header("Audio de Morte")]
    public AudioSource soundDeath;
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dano"))
        {
            soundDeath.Play();
            SceneManager.LoadScene(1);
            Time.timeScale = 0f;
        }

        if (collision.CompareTag("Boss"))
        {
            Boss.SetActive(true);
            musicAmb.Stop();
        }

        if (collision.CompareTag("Inverter"))
        {
            player.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            cam.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }

        
    }
}
