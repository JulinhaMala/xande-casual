using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float power;

    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    TrajectoriLiner tl;

    Camera cam;

    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    public AudioSource audioPull, audioShot;
    public AudioSource audioWallCollision; // Wall collision sound

    public Animator anim;

    public GameObject poeiraEffectPrefab; // Dust effect ("Poeira")
    private GameObject currentPoeiraEffect;

    private void Start()
    {
        cam = Camera.main;
        tl = GetComponent<TrajectoriLiner>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            audioPull.Play();
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            tl.RenderLine(startPoint, currentPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("WallFall", true);
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();
            audioShot.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            anim.SetBool("WallFall", true);
            rb.drag = 10f;

            // Play wall collision sound
            if (audioWallCollision != null)
            {
                audioWallCollision.Play();
            }

            // Show dust effect ("Poeira")
            ShowPoeiraEffect(collision.contacts[0].point); // Show at contact point
        }
        if (collision.collider.CompareTag("chao"))
        {
            anim.SetBool("WallFall", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            anim.SetBool("WallFall", false);
            rb.drag = 0f;
        }
        if (collision.collider.CompareTag("chao"))
        {
            anim.SetBool("WallFall", true);
        }
    }

    private void ShowPoeiraEffect(Vector2 position)
    {
        // Instantiate or enable the dust effect
        if (poeiraEffectPrefab != null)
        {
            if (currentPoeiraEffect == null)
            {
                // Create a new instance of the dust effect at the collision point
                currentPoeiraEffect = Instantiate(poeiraEffectPrefab, position, Quaternion.identity);
            }
            else
            {
                // Reuse the existing dust effect by repositioning it
                currentPoeiraEffect.transform.position = position;
                currentPoeiraEffect.SetActive(true);
            }

            // Start coroutine to deactivate the dust effect after a delay
            StartCoroutine(DeactivatePoeiraEffect());
        }
    }

    private IEnumerator DeactivatePoeiraEffect()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds

        if (currentPoeiraEffect != null)
        {
            // Fade out or deactivate the effect
            currentPoeiraEffect.SetActive(false);
        }
    }
}
