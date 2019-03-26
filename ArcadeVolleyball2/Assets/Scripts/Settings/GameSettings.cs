using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings")]

public class GameSettings : ScriptableObject
{
    [Header("Ball Settings")] 
    public float BallSpeed = 6f;
    [Range(0,.01f)] public float BallGravity = -.0001f;
    [Range(0,.1f)] public float BallAcceleration = .001f;
	
    [Header("Player Settings")]
    public float PlayerSpeed = 8f;
    public float PlayerJumpSpeed = 8f;
    public float GroundLevel = -6f;

    [Header("Physics Settings")]
    public float CharacterSize = 1f;
    public bool Effects = true;
	
    [Header("Time Settings")] 
    public float WaitAfterScore = 1f;
    public float WaitAfterWin = 5f;

}
