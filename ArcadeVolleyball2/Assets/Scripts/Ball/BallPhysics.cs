using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    private Rigidbody2D _rb2D;
    public float _speed = 6;
    public float _acceleration = 0.002f;
    public float _gravity = -0.0003f;
    
    private float _ballSpeed;
    private bool _waiting;
    
    private void Start ()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        Serve(new Vector2(-6,-2));
    }
    
    private void FixedUpdate()
    {
        if (_waiting) return;
        _ballSpeed += _acceleration;
        _rb2D.velocity = _rb2D.velocity.normalized *  _ballSpeed;
        _rb2D.AddForce(new Vector2(0,_gravity));
    }

    public void Serve(Vector2 location)
    {
        transform.position = location;
        _rb2D.velocity = new Vector2(0,0);
        _rb2D.angularVelocity = 0;
        _ballSpeed = _speed;
        _waiting = true;
    }

    // ReSharper disable once UnusedParameter.Local
    private void OnCollisionEnter2D(Collision2D other)
    {
        _waiting = false;
    }
}
