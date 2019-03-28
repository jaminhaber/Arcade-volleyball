﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
// ReSharper disable Unity.PerformanceCriticalCodeInvocation

public class BackgroundLoader : MonoBehaviour
{
    private BackgroundSet[] backgrounds;
    private int current;

    private void Awake()
    {
        backgrounds = Resources.LoadAll<BackgroundSet>("Skin");
        Debug.Log("Loaded " + backgrounds.Length + " backgrounds");
    }

    private void Update()
    {
        if (!Input.GetButtonDown("Submit")) return;
        current = ++current % backgrounds.Length;
        LoadBackground(backgrounds[current]);
    }


    private static void LoadBackground(BackgroundSet bg)
    {
        if (Camera.main != null)
            Camera.main.backgroundColor = bg.BackgroundColor;

        TryUpdate<TextMeshProUGUI>("Title", t => { t.color = bg.TitleColor; });
        TryUpdate<TextMeshProUGUI>("P1Score", t => { t.color = bg.ScoreColor; });
        TryUpdate<TextMeshProUGUI>("P2Score", t => { t.color = bg.ScoreColor; });
        TryUpdate<SpriteRenderer>("Background", s => { s.sprite = bg.BackgroundSprite; });
        TryUpdate<SpriteRenderer>("Ball", s =>
        {
            s.sprite = bg.BallSprite;
            s.color = bg.BallColor;
        });
        TryUpdate<Button>(null, t =>
        {
            t.GetComponent<Image>().color = bg.UiColor;
            t.GetComponentInChildren<Text>().color = bg.ScoreColor;
        });
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