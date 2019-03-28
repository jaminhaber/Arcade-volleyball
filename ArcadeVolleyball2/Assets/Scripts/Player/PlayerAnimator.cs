using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerAnimator : MonoBehaviour
{

	public SpriteSet Sprites;
	
	private SpriteRenderer _renderer;
	private PlayerMotor _motor;
	
	private int _nextFrame;
	private int _walkFrame;

	private void Start ()
	{
		_motor = GetComponentInParent<PlayerMotor>();
		_renderer = GetComponent<SpriteRenderer>();
	}

	public void SetColor(Color color)
	{
		_renderer.color = color;
	}
	
	private void Update()
	{
		if (_motor.Walking() && Time.frameCount > _nextFrame)
		{
			_nextFrame = Time.frameCount + Sprites.FramesPerSprite;
			_walkFrame = ++_walkFrame%Sprites.Walking.Length;
		}

		_renderer.sprite = _motor.IsGrounded ? Sprites.Walking[_walkFrame] : Sprites.Jump;
		
	}
}
