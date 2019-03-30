using System.Collections;
using UnityEngine;

namespace Ball
{
    public class BallLogic : MonoBehaviour
    {
        private BallPhysics _physics;
        private readonly float _waitAfterScore = Loader.i.settings.WaitAfterScore;
        private readonly Vector2 _p1Serve = new Vector2(-7, -2);
        private readonly Vector2 _p2Serve = new Vector2(7, -2);


        private void Start()
        {
            _physics = GetComponent<BallPhysics>();
            GameManager.i.GameState.OnStateChange.AddListener(OnStateChange);
            _physics.Serve(new Vector2(-7, -2));
        }

        private void OnStateChange(State n, State o)
        {
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

    }
}
