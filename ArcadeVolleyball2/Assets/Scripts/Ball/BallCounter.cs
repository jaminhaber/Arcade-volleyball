using System;
using UnityEngine;

public class BallCounter : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            LR(s => s.p2score++, s => s.p1score++);
        else if (other.gameObject.CompareTag("Player"))
            LR(s => s.p1touch++, s => s.p2touch++);
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