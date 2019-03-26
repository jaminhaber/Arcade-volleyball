using UnityEngine;

public class BallScoreCounter : MonoBehaviour
{
    private void Score()
    {
        State s = GameManager.i.GameState.CurrentState;
        if (transform.position.x < 0) s.p1score++;
        else s.p2score++;
        GameManager.i.GameState.UpdateState(s);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) Score();
    }
}
