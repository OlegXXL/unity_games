using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
   public float health = 100;
   [SerializeField] private FixedJoystick joystick;
   [SerializeField] private float moveSpeed = 5;
   private Rigidbody2D rigidbody;
   private GameObject progressBar;

   private void Start()
   {
      progressBar = GameObject.Find("ProgressBar");
      rigidbody = gameObject.GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
      if (health > 0) return;
      Destroy(gameObject);
   }

   private void FixedUpdate()
   {
      if (health < 0) health = 0;
      progressBar.transform.localScale = new Vector3(health / 100, 1, 1);
      rigidbody.velocity = new Vector2(joystick.Horizontal * moveSpeed, joystick.Vertical * moveSpeed);
   }
}
