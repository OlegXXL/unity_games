using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 100;
    public float health = 100;
    [SerializeField] private float damage = 10;
    private Transform target;
    private PlayerController player = null;
    
    private void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        InvokeRepeating("GiveDamage", 0, 1);
    }
    
    void Update()
    {
        if (!target) return;
        
        if (health > 0) return;
        PlayerPrefs.SetInt("LevelDeathCount", PlayerPrefs.GetInt("LevelDeathCount") + 1);
        gameObject.SetActive(false);
        //Destroy(gameObject);
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
