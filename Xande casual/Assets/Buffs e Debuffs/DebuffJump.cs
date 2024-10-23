using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffJump : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(PowerUpCollet(collision.gameObject));
        }
    }

    private IEnumerator PowerUpCollet(GameObject player)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // aplicar o debuff
            rb.gravityScale = 2.0f; // simular o debuff
        }

        yield return new WaitForSeconds(30.0f);

        // restaruar a força de pulo original depois de 30 segundos (modificavel)
        if (rb != null)
        {
            rb.gravityScale = 1.0f; // restaurar a força de pulo
        }

        Destroy(gameObject);
    }
}
