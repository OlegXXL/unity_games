using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    public float health = 100;
    [SerializeField] private DynamicJoystick joystick;
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private ResultGame _resultGame;
    private Rigidbody2D rigidbody;
    private GameObject progressBar;
    private bool checkk = true;
    private Vector3 defaultScale;
    private void FixedUpdate()
    {
        if (health < 0 && checkk)
        {
            checkk = false;
            health = 0;
            _resultGame.GameFinish("lose", "1:45", 5, 50);
        }

        progressBar.transform.localScale = new Vector3(health / 100, 1, 1);
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;
        rigidbody.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(-defaultScale.x, defaultScale.y, defaultScale.z); // face left
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = defaultScale; // face right
        }
    }
    private void Start()
    {
        defaultScale = transform.localScale;
        progressBar = GameObject.Find("ProgressBar");
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        rigidbody.freezeRotation = true;
    }
}