using UnityEngine;

public class PlayerController : MonoBehaviour
{
	
	private PlayerMotor _motor;
	private string _moveAxis = "Horizontal";
	private string _jumpAxis = "Vertical";
	private Vector3 _defaultPosition;
	
	private void Start ()
	{
		_motor = GetComponent<PlayerMotor>();
		_moveAxis = transform.position.x < 0 ? "P1Move" : "P2Move";
		_jumpAxis = transform.position.x < 0 ? "P1Jump" : "P2Jump";
		_defaultPosition = transform.position;
	}

	private void Update()
	{
		_motor.Move(Input.GetAxis(_moveAxis));
		if (Input.GetButtonDown(_jumpAxis)) _motor.Jump();
	}
	
	public void Reset()
	{
		transform.position = _defaultPosition;
	}
	
}



