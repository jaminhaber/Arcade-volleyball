using System.Collections;
using Ball;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i;

    public GameState GameState;
    public BallLogic ball;
    
    private void Awake()
    {
        if (i == null) i = this;
        else Destroy(gameObject);
        GameState = new GameState();
    }

    private void Start()
    {
        GameState.OnStateChange.AddListener(OnStateUpdate);
    }

    private void OnStateUpdate(State n,State o)
    {
        if (n.p1score > o.p1score)
            StartCoroutine(n.p1score >= Loader.i.mode.winScore ? WinRoutine() : ScoreRoutine());
        else if (n.p2score > o.p2score)
            StartCoroutine(n.p2score >= Loader.i.mode.winScore ? WinRoutine() : ScoreRoutine());
    }

    private IEnumerator WinRoutine()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(Loader.i.settings.WaitAfterWin);
        GameState.UpdateState(s =>
        {
            if (s.p1score > s.p2score) s.p1wins++;
            else s.p2wins++;
            s.p1score = s.p2score = 0;
        });
        Time.timeScale = 1;
//        Loader.i.LoadMenu();
    }

    private IEnumerator ScoreRoutine()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(Loader.i.settings.WaitAfterScore);
        Time.timeScale = 1;
    }


    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            Loader.i.LoadMenu();
    }
}