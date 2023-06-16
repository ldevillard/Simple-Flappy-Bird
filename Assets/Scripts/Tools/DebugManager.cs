using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugManager : MonoBehaviour
{
    public KeyCode StartGameInput;
    public KeyCode ResetInput;

#if UNITY_EDITOR
    void Update()
    {
        if (Input.GetKeyDown(StartGameInput))
        {
            GameManager.Instance.StartGame();
        }

        if (Input.GetKeyDown(ResetInput))
        {
            GameManager.Instance.RestartGame();
        }
    }
#endif
}
