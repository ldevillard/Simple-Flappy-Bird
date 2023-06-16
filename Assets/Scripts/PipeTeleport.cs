using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTeleport : MonoBehaviour
{
    public Pipe pipe;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PipeTeleport"))
        {
            pipe.UpdatePosition();
        }
    }
}
