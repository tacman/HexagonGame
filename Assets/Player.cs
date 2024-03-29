﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 600f;

    private float _movement = 0f;
    private Vector2 _movementVector;

    private int _score = 0;

    public Text scoreText;

    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();
        Debug.Log(inputVec.ToString());

        _movementVector = new Vector3(inputVec.x, 0, inputVec.y);
        _movement = _movementVector.x;
    }
    
    void Update()
    {
        
        // no dampening with raw.
        // _movement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        // since 0 is the center of the screen, we can rotate the player around the center.  .forward is the z axis.
        transform.RotateAround(Vector3.zero, Vector3.forward, _movement * Time.fixedDeltaTime * -moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Opening")
        {
            _score += 1;
            scoreText.text = _score.ToString("D");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
