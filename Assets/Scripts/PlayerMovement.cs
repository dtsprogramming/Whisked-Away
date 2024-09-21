using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private float flipDir = 1.2f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0)) 
        {
            flipDir *= -1;
            FlipPlayer(flipDir);
        }
    }

    private void FlipPlayer(float direction)
    {
        transform.localScale = new Vector3(direction, 1.2f, 1.2f);

        moveSpeed *= -1;
    }
}
