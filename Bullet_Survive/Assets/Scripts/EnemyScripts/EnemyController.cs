using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class EnemyController : MonoBehaviour
{
    public float maxHealth = 100;
    public float health = 100;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float damage = 10;
    private Transform target;
    private Rigidbody2D rigidbody;
    private Vector2 moveDirection;
    private PlayerController player = null;
    
    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        rigidbody.freezeRotation = true;
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        InvokeRepeating("GiveDamage", 0, 1);
    }
    
    void Update()
    {
        if (!target) return;
        moveDirection = (target.position - transform.position).normalized;
        rigidbody.rotation = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        
        if (health > 0) return;
        PlayerPrefs.SetInt("LevelDeathCount", PlayerPrefs.GetInt("LevelDeathCount") + 1);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (!target) return;
        rigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void GiveDamage()
    {
        if (player == null) return;
        player.health -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            player = collision.gameObject.GetComponent<PlayerController>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            player = null;
    }
}
