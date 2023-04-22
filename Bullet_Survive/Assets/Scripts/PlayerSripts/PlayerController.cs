using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    public float health = 100;
    [SerializeField] private DynamicJoystick joystick;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private ResultGame _resultGame;
    private Rigidbody2D rigidbody;
    private GameObject progressBar;
    private bool checkk = true;
    private void FixedUpdate()
    {
        if (health < 0 && checkk)
        {
            checkk= false;
            health = 0;
            _resultGame.GameFinish("lose", "1:45", 5, 50);
        }

        progressBar.transform.localScale = new Vector3(health / 100, 1, 1);
        rigidbody.velocity = new Vector2(joystick.Horizontal * moveSpeed, joystick.Vertical * moveSpeed);
    }
    private void Start()
    {
        progressBar = GameObject.Find("ProgressBar");
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        rigidbody.freezeRotation = true;
    }
}