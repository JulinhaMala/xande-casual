using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerManager : MonoBehaviour
{
    [Header("Transforme da Camera")]
    public Transform cam;

    [Header("Transforme do Player")]
    public Transform player;

    public Rigidbody2D rb;

    [Header("Obj do Boss")]
    public GameObject Boss;

    [Header("Audio do Ambiente")]
    public AudioSource musicAmb;

    [Header("Audio de Morte")]
    public AudioSource soundDeath;

    [Header("Tela de morte")]
    public GameObject UIPainel;



    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dano"))
        {
            Destroy(Boss);
            soundDeath.Play();
            UIPainel.SetActive(true);
            GetComponent<CircleCollider2D>().enabled = false;
            rb.simulated = false;
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(1);
            
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
