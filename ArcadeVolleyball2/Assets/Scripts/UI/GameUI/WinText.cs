﻿using TMPro;
using UnityEngine;

public class WinText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private readonly int _winScore = Loader.i.mode.winScore;
    private void Start()
    {
        GameManager.i.GameState.OnStateChange.AddListener(OnStateChange);
        GameManager.i.OnNewGame.AddListener(NewGame);
    }

    private void OnStateChange(State n, State o)
    {
        if (n.p1score >= _winScore) _text.text = "Player 1 Wins";
        else if (n.p2score >= _winScore) _text.text = "Player 2 Wins";
    }

    private void NewGame()
    {
        _text.text = "";
    }

}
