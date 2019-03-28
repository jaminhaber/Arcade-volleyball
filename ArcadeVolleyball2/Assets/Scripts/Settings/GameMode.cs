using UnityEngine;

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

    [Header("Game Settings")]
    [Range(1, 3)] public int playersPerSide = 2;
	
}
