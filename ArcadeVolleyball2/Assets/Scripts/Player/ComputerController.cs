using System.Collections;
using UnityEngine;

public enum STATE
{
	RESET = 0,
	PLAY = 2,
	SERVE = 3,
	OFF = 5
}

public class ComputerController : MonoBehaviour
{

	[SerializeField] private Rigidbody2D _ball;
	
	private PlayerMotor _motor;
	private Vector3 _defaultPosition;
	private STATE _state;

	//variables for AI
	//TODO: make these respond to ball movement
	private const float _yThresh = 1;
	private const float _xMidPoint = 4;
	private const float _hitStrength = 1;
	private float _hitHeight = -1f;
	private float _xLead;
	

	public void activate()
	{
		changeState(STATE.OFF);
	}
	
	private void Start () {
		_motor = GetComponent<PlayerMotor>();
		_defaultPosition = transform.position;
		activate();
	}

	private void changeState(STATE newState)
	{
		if (_state == newState) return;
		
		StopAllCoroutines();
		_state = newState;

		switch (newState)
		{
				case STATE.RESET:
					StartCoroutine(goHome());
					return;
				case STATE.PLAY:
					StartCoroutine(Play());
					return;
				case STATE.SERVE:
					StartCoroutine(serve());
					return;
				case STATE.OFF:
					return;
				default:
					return;
		}
	}
	
	private void Update ()
	{
		if (_ball.position.x <= 0f)
			changeState(STATE.RESET);
		else if (_ball.velocity.magnitude == 0f)
			changeState(STATE.SERVE);
		else if (_ball.position.x > 0f) 
			changeState(STATE.PLAY);
	}

	private IEnumerator Play()
	{
		yield return new WaitForSeconds(.2f);
		while (_state == STATE.PLAY)
		{
			//ball is going up
			if (_ball.velocity.y > 0)
			{
				_motor.Move(_defaultPosition.x - transform.position.x);
				yield return null;
			}
			
			//ball is in top half of screen
			else if (_ball.position.y > _yThresh)
			{
				_motor.Move(ballX());
			}
			
			//ball is going down and on bottom half
			else
			{
				//assign hit strength inverse to ball speed
				_xLead = _ball.velocity.x/2;
				_hitHeight = -1.5f;
				
				//ball is going right
				if (_ball.velocity.x > 0)
				{
					//ball is on right side
					if (_ball.position.x > _xMidPoint)
					{
						_motor.Move(ballX());
						
						//ball is in hitting range
						if (_ball.position.y <= _hitHeight)
						{
							_motor.Move(-_hitStrength);
							_motor.Jump();
							_motor.Move(-_hitStrength);
						}
					}
					//ball is on left side
					else
					{
						_motor.Move(ballX()+_xLead);
						
						//ball is in hitting range
						if (_ball.position.y <= _hitHeight)
						{
							_motor.Move(_hitStrength);
							_motor.Jump();
							_motor.Move(_hitStrength);
						}
					}
				}
				//ball is going left
				else
				{
					//ball is on right side
					if (_ball.position.x > _xMidPoint)
					{
						_motor.Move(ballX()+_xLead);
						
						//ball is in hitting range
						if (_ball.position.y <= _hitHeight)
						{
							_motor.Move(-_hitStrength);
							_motor.Jump();
							_motor.Move(-_hitStrength);
						}
					}
					//ball is on left side
					else
					{
						_motor.Move(ballX());
						
						//ball is in hitting range
						if (_ball.position.y <= _hitHeight)
						{
							//ball is in hitting range
							if (_ball.position.y <= _hitHeight)
							{
								_motor.Move(_hitStrength);
								_motor.Jump();
								_motor.Move(_hitStrength);
							}
						}
					}
					
					//ball is in hitting range
					if (_ball.position.y <= _hitHeight)
					{
						_motor.Jump();
					}
				}
			}
			yield return null;
		}
	}
	
	private IEnumerator serve()
	{
		yield return new WaitForSeconds(2);
		_motor.Move(-1f);
		yield return new WaitForSeconds(.1f);
		_motor.Move(-1f);
		_motor.Jump();
	}

	private IEnumerator goHome()
	{
		while (_state == STATE.RESET)
		{
			_motor.Move(distanceHome());
			if (distanceHome() <= .2f)
				_motor.Move(0f);
			yield return null;
		}
	}

	private float ballX()
	{
		return _ball.position.x - transform.position.x;
	}

	private float distanceHome()
	{
		return _defaultPosition.x - transform.position.x;
	}
}
