using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCameraController : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField] private float maxDistance;

    private Vector3 basePosition;

    private void Awake()
    {
        if (!Loader.i.settings.Effects) enabled = false;
        basePosition = transform.position;
    }

    private void Update()
    {
        transform.position =
            basePosition + new Vector3(
                Mathf.Clamp(ball.position.x, -maxDistance, maxDistance), transform.position.y);
    }
}