using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float spead;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * spead * Time.deltaTime);
    }
}
