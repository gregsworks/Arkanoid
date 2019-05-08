using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    void Update()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width *16f;

        Debug.Log(mousePosInUnits);

        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y);
        transform.position = paddlePos;
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
    }
}

