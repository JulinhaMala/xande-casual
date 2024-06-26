using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioSource moeda;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moeda.Play();
            BestPoint.Pontuacao++;
            Destroy(gameObject);
        }
    }
}
