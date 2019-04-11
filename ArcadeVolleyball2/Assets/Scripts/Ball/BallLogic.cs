using System;
using System.Collections;
using UnityEngine;

namespace Ball
{
    public class BallLogic : MonoBehaviour
    {
        private BallPhysics _ball;
        private Func<State, State, bool> _serveFunc;
        private bool _nextServe;

        private int _winScore;


        private void Awake()
        {
            _winScore = Loader.i.mode.winScore;
            _ball = GetComponent<BallPhysics>();
            _serveFunc = GameCalculator.ServeFunction(Loader.i.mode.serveMode);
            _nextServe = _serveFunc(new State(),GameManager.i.GameState.CurrentState );
        }

        private void Start()
        {
            GameManager.i.GameState.OnStateChange.AddListener(OnStateChange);
            GameManager.i.OnNewRound.AddListener(Init);
        }

        private void OnStateChange(State n, State o)
        {
            if (n.p1score >= _winScore || n.p2score >= _winScore) return;

            if (n.p1score != o.p1score || n.p2score != o.p2score)
                _nextServe = _serveFunc(n, o);
        }
        
        private void Init()
        {
            _ball.Serve(GameCalculator.ServePosition(_nextServe));
        }

    }
}
