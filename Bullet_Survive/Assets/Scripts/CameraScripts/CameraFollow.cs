using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector2 offset;
    [SerializeField] private float topBorder;
    [SerializeField] private float bottomBorder;
    [SerializeField] private float rightBorder;
    [SerializeField] private float leftBorder;

    private void FixedUpdate()
    {
        var desiredPosition = target.position + new Vector3(offset.x, offset.y, -10);
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        if (transform.position.x > rightBorder) 
            transform.position = new Vector3(rightBorder, transform.position.y, transform.position.z);

        if (transform.position.x < leftBorder) 
            transform.position = new Vector3(leftBorder, transform.position.y, transform.position.z);

        if (transform.position.y > topBorder) 
            transform.position = new Vector3(transform.position.x, topBorder, transform.position.z);

        if (transform.position.y < bottomBorder) 
            transform.position = new Vector3(transform.position.x, bottomBorder, transform.position.z);
    }
}
