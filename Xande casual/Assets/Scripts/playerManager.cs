using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerManager : MonoBehaviour
{
    public Transform cam;
    public Transform player;
    public GameObject Boss;
    public AudioSource musicAmb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dano"))
        {
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
