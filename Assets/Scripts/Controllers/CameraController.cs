using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public void GameClear()
    {
        GetComponent<Camera>().backgroundColor = Color.green;
    }

    public void GameOver()
    {
        GetComponent<Camera>().backgroundColor = Color.red;
    }
}
