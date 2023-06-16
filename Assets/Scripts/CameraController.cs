using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    static public CameraController Instance;

    public Camera cam;

    void Awake()
    {
        Instance = this;
    }

    public void Shake(float duration, float strength = 3)
    {
        cam.DOShakePosition(duration, strength);
    }
}
