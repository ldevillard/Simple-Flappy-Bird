using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    float speed;
    float distanceBetweenPipes;
    float numberPipes;

    float StartPositionY;

    bool isReady;

    void Start()
    {
        speed = GameManager.Instance.speedPipe;
        distanceBetweenPipes = GameManager.Instance.distanceBetweenPipes;
        numberPipes = GameManager.Instance.numberPipes;

        StartPositionY = transform.position.y;
        UpdatePosition();
    }

    void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.Playing)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PipeTeleport"))
        {
            transform.position = new Vector3(transform.position.x + (numberPipes * distanceBetweenPipes), transform.position.y, transform.position.z);
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        transform.position = new Vector3(transform.position.x, StartPositionY + Random.Range(-2, 2), transform.position.z);
    }
}
