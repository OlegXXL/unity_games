using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.WSA;

public class GunController : MonoBehaviour
{
    [SerializeField] private float overchargeTime = 1;
    [SerializeField] private float damage = 10;
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] private GameObject bullet;
    private GameObject[] enemies;

    private void Start()
    {
        InvokeRepeating("Shoot", overchargeTime, overchargeTime);
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
    }
}
