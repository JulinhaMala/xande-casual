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
    public AudioSource audioWallCollision; // New variable for wall collision sound

    public Animator anim;

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
}
