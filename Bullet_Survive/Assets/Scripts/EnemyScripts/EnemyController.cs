using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float health = 100;
    [SerializeField] private float moveSpeed = 5;
    private Transform target;
    private Rigidbody2D rigidbody;
    private Vector2 moveDirection; 
    
    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }
    
    void Update()
    {
        if (!target) return;
        moveDirection = (target.position - transform.position).normalized;
        rigidbody.rotation = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        if (!target) return;
        rigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }
}
