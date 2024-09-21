using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private int flipDir = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0)) {
            flipDir *= -1;
            FlipPlayer(flipDir);
    }
}

    private void FlipPlayer(int direction)
    {
        transform.localScale = new Vector3(direction, 1, 1);

        moveSpeed *= -1;
    }
}
