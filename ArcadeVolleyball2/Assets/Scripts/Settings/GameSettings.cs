using UnityEngine;

[CreateAssetMenu(menuName = "GameSettings")]

public class GameSettings : ScriptableObject
{
    [Header("Physics Settings")]
    public bool Effects = true;
    public float GroundLevel = -6f;

    [Header("Time Settings")] 
    public float WaitAfterScore = 1f;
    public float WaitAfterWin = 5f;

}
