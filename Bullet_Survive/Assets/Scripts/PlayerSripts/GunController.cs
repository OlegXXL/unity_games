using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GunController : MonoBehaviour
{
    [SerializeField] private float overchargeTime = 0.6f;
    [SerializeField] private float damage = 10;
    [SerializeField] private float rotationSpeed = 0.6f;
    [SerializeField] private GameObject bullet;
    private List<GameObject> enemies;

    private void Start()
    {
        InvokeRepeating("Shoot", overchargeTime, overchargeTime);
    }

    void Update()
    {
        var enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
        var boss = GameObject.FindGameObjectWithTag("Boss");

        if (enemiesArray.Length == 0 && !boss) return;
        if (enemiesArray.Length == 0) enemies = new List<GameObject>();
        else enemies = new List<GameObject>(enemiesArray);
        Debug.Log(enemies.ToString());
        
        if (boss) enemies.Add(boss);

        var distance = Mathf.Infinity;
        var targetPosition = transform.position;
        foreach (var enemy in enemies)
        {
            var diff = enemy.transform.position - transform.position;
            var currentDistance = diff.sqrMagnitude;
            if (currentDistance >= distance) continue;
            distance = currentDistance;
            targetPosition = enemy.transform.position;
        }

        var vectorToTarget = transform.position - targetPosition;
        var angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        var q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }

    void Shoot()
    {   
        var bullet = Instantiate(this.bullet, transform.position, Quaternion.identity);
        bullet.transform.right = transform.right;
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayShootSound();
    }
}
