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

    public Collider2D[] colliders;

    void Awake()
    {
        GameManager.OnGameEnded += HandleGameEnded;
    }

    void Start()
    {
        speed = GameManager.Instance.speedPipe;
        distanceBetweenPipes = GameManager.Instance.distanceBetweenPipes;
        numberPipes = GameManager.Instance.numberPipes;

        StartPositionY = transform.position.y;
        transform.position = new Vector3(transform.position.x, StartPositionY + Random.Range(-2, 2), transform.position.z);
    }

    void OnDestroy()
    {
        GameManager.OnGameEnded -= HandleGameEnded;
    }

    void HandleGameEnded()
    {
        foreach (Collider2D collider in colliders)
            collider.enabled = false;
    }

    void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.Playing)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void UpdatePosition()
    {
        transform.position = new Vector3(transform.position.x + (numberPipes * distanceBetweenPipes), transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, StartPositionY + Random.Range(-2, 2), transform.position.z);
    }
}
