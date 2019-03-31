using System.Collections;
using UnityEngine;

namespace Ball
{
    public class BallLogic : MonoBehaviour, IReset
    {
        private BallPhysics _physics;
        private readonly float _waitAfterScore = Loader.i.settings.WaitAfterScore;
        private  Vector2 _p1Serve = new Vector2(-7, -2);
        private  Vector2 _p2Serve = new Vector2(7, -2);

        private int _winScore;

        private void Awake()
        {
            _p1Serve.y = Loader.i.mode.CharacterSize - 3;
            _p2Serve.y = Loader.i.mode.CharacterSize - 3;
            _winScore = Loader.i.mode.winScore;
        }

        private void Start()
        {
            _physics = GetComponent<BallPhysics>();
            GameManager.i.GameState.OnStateChange.AddListener(OnStateChange);
            _physics.Serve(_p1Serve);
        }

        private void OnStateChange(State n, State o)
        {
            if (n.p1score >= _winScore || n.p2score >= _winScore) return;
            
            if (n.p1score > o.p1score)
                StartCoroutine(Serve(_p1Serve));
            
            else if (n.p2score > o.p2score)
                StartCoroutine(Serve(_p2Serve));
        }
        
        private IEnumerator Serve(Vector2 location)
        {
            yield return new WaitForSecondsRealtime(_waitAfterScore);
            _physics.Serve(location);
        }

        public void ResetForNewRound()
        {
            Awake();
            Start();
        }

        public void ResetForNewGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
