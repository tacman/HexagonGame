using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 600f;

    private float _movement = 0f;

    public Text scoreText;

    void Update()
    {
        // no dampening with raw.
        _movement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        scoreText.text = _movement.ToString("0");
        // since 0 is the center of the screen, we can rotate the player around the center.  .forward is the z axis.
        transform.RotateAround(Vector3.zero, Vector3.forward, _movement * Time.fixedDeltaTime * -moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
