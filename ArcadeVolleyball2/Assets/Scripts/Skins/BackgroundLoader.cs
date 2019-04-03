using System;
using System.Linq;
using Skins;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

// ReSharper disable Unity.PerformanceCriticalCodeInvocation

public class BackgroundLoader : MonoBehaviour
{
    private static BackgroundSet[] backgrounds;
    private static int current;

    public static BackgroundSet CurrentBackground => backgrounds[current];

    private static BackgroundLoader i;
    private void Start()
    {
        if (i == null) i = this;
        else
        {
            LoadBackground(CurrentBackground);
            enabled = false;
        }
        backgrounds = Resources.LoadAll<BackgroundSet>("Skin");
        current = PlayerPrefs.GetInt("background");
        if (current > backgrounds.Length) current = 0;
        LoadBackground(backgrounds[current]);
    }

    private void Update()
    {
        if (!Input.GetButtonDown("Submit")) return;
        current = ++current % backgrounds.Length;
        LoadBackground(CurrentBackground);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("background",current);
    }

    private static void LoadBackground(BackgroundSet bg)
    {
        if (Camera.main != null)
            Camera.main.backgroundColor = bg.BackgroundColor;

        TryUpdate<TextMeshProUGUI>("Title", t => t.color = bg.TitleColor);
        TryUpdate<TextMeshProUGUI>("P1Score", t => t.color = bg.ScoreColor);
        TryUpdate<TextMeshProUGUI>("P2Score", t => t.color = bg.ScoreColor);
        TryUpdate<SpriteRenderer>("Background", s => s.sprite = bg.BackgroundSprite);
        TryUpdate<SpriteRenderer>("Ball", s =>
        {
            s.sprite = bg.BallSprite;
            s.color = bg.BallColor;
        });
        
        TryUpdate<Image>("UI", i => i.color = bg.UiColor);
        TryUpdate<TextMeshProUGUI>("Loading", t => t.color = bg.TitleColor);

        
        foreach (ISkin s in FindObjectsOfType<MonoBehaviour>().OfType<ISkin>()) 
            s.Paint(bg);
    }

    private static void TryUpdate<T>(string name, Action<T> func) where T : Object
    {
        if (string.IsNullOrEmpty(name))
        {
            T[] all = FindObjectsOfType<T>();
            foreach (T t in all)
                func(t);
        }
        else
        {
            GameObject obj;
            T type;

            if ((obj = GameObject.Find(name)) != null
                && (type = obj.GetComponent<T>()) != null)
                func(type);
        }
    }
}