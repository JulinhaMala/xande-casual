using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioSource moeda;

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;

            moeda.Play();
            
            BestPoint.Pontuacao++;

            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}
