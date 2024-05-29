using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpCannonForce : MonoBehaviour
{

    private Vector2 playerPosition;
    private Vector2 mousePosition;
    private Vector2 direction;
    public float speedFire;
    public Transform pointFire;
    public GameObject point;
    public GameObject[] points;
    public int numberoPoints;
    public float spaceBetweenPoints;

    void Start()
    {
        points = new GameObject[numberoPoints];
        for (int i = 0; i < numberoPoints; i++)
        {
            points[i] = Instantiate(point, pointFire.position, Quaternion.identity);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            numberoPoints = 0;
            Time.timeScale = 1f;
        }
        PlayerRotation();

        Vector2 PointPosition(float p)
        {
            Vector2 position = ((Vector2)pointFire.position + direction.normalized * speedFire * p) + 0.5f * Physics2D.gravity * (p * p);
            return position;
        }

        for (int i = 0; i < numberoPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
    }

    public void PlayerRotation()
    {
        playerPosition = transform.position;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - playerPosition;
        transform.right = direction;
    }

    public void Fire()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speedFire;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Time.timeScale = 0f;
            numberoPoints = 8;
        }
    }

}
