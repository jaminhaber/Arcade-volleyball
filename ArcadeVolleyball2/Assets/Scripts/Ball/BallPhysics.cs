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
        
            _acceleration = Loader.i.mode.ballAcceleration * Time.fixedDeltaTime * .1f;
            _gravity = -Loader.i.mode.ballGravity * Time.fixedDeltaTime * .01f;
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

        // ReSharper disable once UnusedParameter.Local
        private void OnCollisionEnter2D(Collision2D other)
        {
            _waiting = false;
        }

        public string DebugInfo()
        {
            return $"Speed: {_ballSpeed:F}";
        }
    }
}