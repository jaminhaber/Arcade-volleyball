using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour
{
	
	public bool IsGrounded { get; private set; }
	
	private float _move;
	private float _jumpAxis;
	private bool _jump;
	private Rigidbody2D _rb2D;

	private readonly float groundLevel = -6;
	
	private void Start ()
	{
		_rb2D = GetComponent<Rigidbody2D>();
		IsGrounded = true;
	}
	
	private void FixedUpdate () 
	{
		_jumpAxis = _rb2D.velocity.y;

		if (_jump)
		{
//			_jumpAxis = Settings.s.PlayerJumpSpeed;
			_jumpAxis = 8;
			_jump = false;
		}
		
//		_rb2D.velocity = new Vector2(_move * Settings.s.PlayerSpeed, _jumpAxis);
		_rb2D.velocity = new Vector2(_move * 8, _jumpAxis);

	}

	public void Move(float input)
	{
		_move = Mathf.Clamp(input,-1,1);
	}
	
	public void Jump()
	{
		if (!Grounded()) return;
		_jump = true;
		StartCoroutine(JumpRoutine());
	}

	private IEnumerator JumpRoutine()
	{
		IsGrounded = false;
		
		yield return new WaitUntil(() => _jumpAxis < 0);
		yield return new WaitUntil(Grounded);

		IsGrounded = true;

	}
	
	private bool Grounded()
	{
		return transform.position.y < groundLevel;
	}
	
	public bool Walking()
	{
		return _move != 0f;
	}
}
