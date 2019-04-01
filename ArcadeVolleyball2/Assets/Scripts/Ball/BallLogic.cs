using System.Collections;
using UnityEngine;

namespace Ball
{
    public class BallLogic : MonoBehaviour, IReset
    {
        private BallPhysics _ball;
        private readonly float _waitAfterScore = Loader.i.settings.WaitAfterScore;

        private int _winScore;

        private void Start()
        {
            _winScore = Loader.i.mode.winScore;
            _ball = GetComponent<BallPhysics>();
            _ball.Serve(GameCalculator.ServePosition(true));
            
            GameManager.i.GameState.OnStateChange.AddListener(OnStateChange);
        }

        private void OnStateChange(State n, State o)
        {
            if (n.p1score >= _winScore || n.p2score >= _winScore) return;
            
            if (n.p1score > o.p1score)
                StartCoroutine(Serve(GameCalculator.ServePosition(true)));
            
            else if (n.p2score > o.p2score)
                StartCoroutine(Serve(GameCalculator.ServePosition(false)));
        }
        
        private IEnumerator Serve(Vector2 location)
        {
            yield return new WaitForSecondsRealtime(_waitAfterScore);
            _ball.Serve(location);
        }

        public void ResetForNewRound()
        {
            Start();
        }

        public void ResetForNewGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
