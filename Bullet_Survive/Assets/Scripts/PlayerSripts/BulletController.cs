using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class BulletController : MonoBehaviour
{
    public float spead;
    public float damage;

    private void Start()
    {
        StartCoroutine(DestroyAfter());
    }

    private void Update()
    {
        transform.Translate(Vector2.left * spead * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("before");
        if (!collision.gameObject.CompareTag("Enemy")) return;
        Debug.Log("after");

        var enemy = collision.gameObject.GetComponent<EnemyController>();
        enemy.health -= damage;
        Destroy(gameObject);
    }

    private IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
