using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 200;
    public float rotationSpeed = 3.0f;

    public Rigidbody2D rb;

    bool isReady;
    bool isDead;

    void Start()
    {
        GameManager.OnGameStarted += OnGameStarted;

        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnDestroy()
    {
        GameManager.OnGameStarted -= OnGameStarted;
    }

    void OnGameStarted()
    {
        isReady = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void Update()
    {
        if (isReady && !isDead)
        {
            float angle;
            float rotSpeed = rotationSpeed;

            if (rb.velocity.y < -2)
            {
                angle = Mathf.Lerp(-90, 90, rb.velocity.y);
            }
            else
            {
                angle = 20;
                rotSpeed *= 3;
            }

            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);


            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, jumpForce));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (isDead)
            return;
        isDead = true;
        rb.bodyType = RigidbodyType2D.Static;

        GameManager.Instance.GameOver();
    }
}
