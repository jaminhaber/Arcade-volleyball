using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "GameMode")]
public class GameMode : ScriptableObject
{
	[Header("Info")] 
	public string modeName;
	public string description;
	
    [Header("Score Settings")]
    [Range(1, 7)] public int winScore = 5;
    [Range(1, 5)] public int bestOf = 3;
    [Range(1, 3)] public int maxTouches = 3;

    [Header("Ball Settings")] 
    public float BallSpeed = 6f;
    [Range(0, 10f)] public float ballGravity =  2f;
    [Range(0,10f)] public float ballAcceleration = 2f;
	
    [Header("Player Settings")]
    public float PlayerSpeed = 8f;
    public float PlayerJumpSpeed = 10f;
    public float CharacterSize = 1f;
    
    [Header("Game Settings")]
    [Range(1, 3)] public int playersPerSide = 2;
	public ServeMode serveMode;
}

public enum ServeMode
{
	WINNER,LOSER,ALTERNATING
}
