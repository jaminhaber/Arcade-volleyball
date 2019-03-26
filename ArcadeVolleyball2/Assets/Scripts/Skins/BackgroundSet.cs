using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Background")]
public class BackgroundSet : ScriptableObject
{
    [Header("General")]
    public string Name;
    public Boolean Locked;
    
    [Header("Background")]
    public Sprite BackgroundSprite;
    public Color BackgroundColor = Color.black;

    [Header("Ball")] 
    public Sprite BallSprite;
    public Color BallColor = Color.white;

    [Header("GUI")] 
    public Color TitleColor = Color.blue;
    public Color ScoreColor = Color.white;
    public Color UiColor = Color.red;
}
