using TMPro;
using UnityEngine;

public class BackgroundLoader : MonoBehaviour
{
    private BackgroundSet[] backgrounds;
    private int current;

    private void Awake()
    {
        backgrounds = Resources.LoadAll<BackgroundSet>("Skin");
        Debug.Log("Loaded "+backgrounds.Length+" backgrounds");
    }

    private void Update()
    {
        if (!Input.GetButtonDown("Submit")) return;
        current = ++current % backgrounds.Length;
        LoadBackground(backgrounds[current]);
    }

    private static void LoadBackground(BackgroundSet bg)
    {
        SpriteRenderer ballRenderer = GameObject.Find("Ball").GetComponent<SpriteRenderer>();
        SpriteRenderer bgRenderer = GameObject.Find("Background").GetComponent<SpriteRenderer>();
        TextMeshProUGUI title = GameObject.Find("Title").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI p1Score = GameObject.Find("P1Score").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI p2Score = GameObject.Find("P2Score").GetComponent<TextMeshProUGUI>();
        
        if (bgRenderer != null)
        {
            bgRenderer.sprite = bg.BackgroundSprite;
        }
        if (ballRenderer != null)
        {
            ballRenderer.sprite = bg.BallSprite;
            ballRenderer.color = bg.BallColor;  
        }
        if (Camera.main != null)
        {
            Camera.main.backgroundColor = bg.BackgroundColor;
        }
        if (title != null)
        {
            title.color = bg.TitleColor;
        }

        if (p1Score != null && p2Score!=null)
        {
            p1Score.color = p2Score.color = bg.ScoreColor;
        }
    }
}