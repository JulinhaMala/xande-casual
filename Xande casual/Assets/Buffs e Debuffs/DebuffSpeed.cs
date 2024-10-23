using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffSpeed : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SlowDownPlayer(collision.gameObject));
        }
    }

    private IEnumerator SlowDownPlayer(GameObject player)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.drag = 10f; // temporariamente dimunuir a for�a que o player � lan�ado
        }

        player.transform.localScale /= 1.5f; // Opcional: reduzir o tamnho do player pra ele saber que pegou o debuff

        yield return new WaitForSeconds(5.0f);

        // mesma coisa que falei ali em baixo
        if (rb != null)
        {
            rb.drag = 0f; // restaurar a for�a normal e puxar e lan�ar
        }

        player.transform.localScale *= 1.5f;

        Destroy(gameObject);
    }
}
