using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour, IReset
{
	
	public bool IsGrounded { get; private set; }
	
	private float _move;
	private float _jumpAxis;
	private bool _jump;
	private Rigidbody2D _rb2D;

	private readonly float _groundLevel = Loader.i.settings.GroundLevel;
	private readonly float _moveSpeed = Loader.i.mode.PlayerSpeed; 
	private readonly float _jumpSpeed = Loader.i.mode.PlayerJumpSpeed;

	private Vector2 _startPosition; 
	
	private void Start ()
	{
		_rb2D = GetComponent<Rigidbody2D>();
		IsGrounded = true;
		
		_startPosition = 
			new Vector2(transform.position.x,Loader.i.settings.GroundLevel + Loader.i.mode.CharacterSize/2);
		
		ResetForNewRound();
		
		transform.localScale = transform.localScale * Loader.i.mode.CharacterSize;

		if (transform.position.x > 0f)
			transform.rotation = Quaternion.Euler(new Vector3(0,180));
	}

	private void FixedUpdate () 
	{
		_jumpAxis = _rb2D.velocity.y;

		if (_jump)
		{
			_jumpAxis = _jumpSpeed;
			_jump = false;
		}
		
		_rb2D.velocity = new Vector2(_move * _moveSpeed, _jumpAxis);

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
		return transform.position.y <= _groundLevel;
	}
	
	public bool Walking()
	{
		return _move != 0f;
	}

	public void ResetForNewRound()
	{
		transform.position = _startPosition;
	}

	public void ResetForNewGame()
	{
		ResetForNewRound();
	}
}
