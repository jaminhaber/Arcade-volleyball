using System;
using System.Collections;
using UnityEngine;

namespace Ball
{
    public class BallLogic : MonoBehaviour, IReset
    {
        private BallPhysics _ball;
        private readonly float _waitAfterScore = Loader.i.settings.WaitAfterScore;

        private Func<State, State, bool> _serveFunc;
        private int _winScore;

        private void Start()
        {
            _winScore = Loader.i.mode.winScore;
            _ball = GetComponent<BallPhysics>();
            _ball.Serve(GameCalculator.ServePosition(true));
            _serveFunc = GameCalculator.ServeFunction(Loader.i.mode.serveMode);
            
            GameManager.i.GameState.OnStateChange.AddListener(OnStateChange);
        }

        private void OnStateChange(State n, State o)
        {
            if (n.p1score >= _winScore || n.p2score >= _winScore) return;

            if (n.p1score != o.p1score || n.p2score != o.p2score)
                StartCoroutine(
                    Serve(GameCalculator.ServePosition(
                        _serveFunc(n,o))));
        }
        
        private IEnumerator Serve(Vector2 location)
        {
            yield return new WaitForSecondsRealtime(_waitAfterScore);
            _ball.Serve(location);
        }

        public void ResetForNewRound()
        {
            StopAllCoroutines();
            Start();
        }

        public void ResetForNewGame()
        {
            ResetForNewRound();
        }
    }
}
