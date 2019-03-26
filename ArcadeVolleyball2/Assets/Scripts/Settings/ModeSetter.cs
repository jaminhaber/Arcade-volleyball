using UnityEngine;

public class ModeSetter : MonoBehaviour
{
    
    private GameMode[] playlist;

    private void Awake()
    {
        playlist = Resources.LoadAll<GameMode>("GameModes");
        Debug.Log("Loaded "+playlist.Length+" game modes");
        LoadGameMode(playlist[0]);
    }

    public void LoadGameMode(GameMode mode)
    {
        
    }
}