using UnityEngine;

[CreateAssetMenu(menuName = "Game Mode")]
public class GameMode : ScriptableObject
{
	[Header("Info")] 
	public string Name;
	
    [Header("Score Settings")]
    [Range(1, 7)] public int WinScore = 5;
    [Range(1, 5)] public int BestOf = 3;
    [Range(1, 3)] public int MaxTouches = 3;

    [Header("Game Settings")]
    [Range(1, 3)] public int PlayersPerSide = 2;
	
}
