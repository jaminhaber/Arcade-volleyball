using System;
using UnityEngine;

namespace Ball
{
    public class BallCounter : MonoBehaviour
    {
        private GameObject lastCollision;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject == lastCollision) return;

            if (other.gameObject.CompareTag("Ground"))
                LR(s => s.p2score++, s => s.p1score++);

            if (other.gameObject.CompareTag("Player"))
                LR(s => { s.p1touch++; }, s => { s.p2touch++; });

            LR(s => s.p2touch = 0, s => s.p1touch = 0);

            lastCollision = other.gameObject;
        }

        private void LR(Action<State> left, Action<State> right)
        {
            GameManager.i.GameState.UpdateState(s =>
            {
                if (transform.position.x < 0) left(s);
                else right(s);
            });
        }
    }
}