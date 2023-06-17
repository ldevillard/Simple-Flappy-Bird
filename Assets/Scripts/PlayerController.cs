using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 200;
    public float rotationSpeed = 3.0f;

    public Animator anim;
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

        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, jumpForce));

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

            if (transform.position.y > 7)
                Die();
        }
    }

    void Die()
    {
        if (isDead)
            return;
        isDead = true;
        anim.speed = 0;
        transform.DORotate(new Vector3(0, 0, -90), 0.5f);
        GameManager.Instance.GameOver();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pipe"))
        {
            ScoreManager.Instance.AddScore();
        }
    }
}
