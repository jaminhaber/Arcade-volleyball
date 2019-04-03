using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Ball
{
    public class BallPhysics : MonoBehaviour
    {
        private Rigidbody2D _rb2D;
        private float _ballSpeed;
        private bool _waiting;

        private readonly float _speed = Loader.i.mode.BallSpeed;
        private float _acceleration;
        private float _gravity;

        private void Start()
        {
            _rb2D = GetComponent<Rigidbody2D>();
            _acceleration = GameCalculator.BallAcceleration();
            _gravity = GameCalculator.BallGravity();
        }

        private void FixedUpdate()
        {
            if (_waiting) return;
            _ballSpeed += _acceleration;
            _rb2D.velocity = _rb2D.velocity.normalized * _ballSpeed;
            _rb2D.AddForce(new Vector2(0, _gravity));
        }

        public void Serve(Vector2 location)
        {
            transform.position = location;
            _rb2D.velocity = new Vector2(0, 0);
            _rb2D.angularVelocity = 0;
            _ballSpeed = _speed;
            _waiting = true;
        }

        private void OnCollisionEnter2D([NotNull] Collision2D other)
        {
            if (!_waiting) return;
            if (other == null) throw new ArgumentNullException(nameof(other));
            _waiting = false;
        }
    }
}