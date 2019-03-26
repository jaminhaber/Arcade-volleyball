using UnityEngine;

public class BallCounter : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.x != 0) return;
        Debug.Log("cross");
        State s = GameManager.i.GameState.CurrentState;
        s.p1touch = s.p2touch = 0;
        GameManager.i.GameState.UpdateState(s);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) Score();
        else if (other.gameObject.CompareTag("Player")) Touch();
    }
    
    private void Score()
    {
        State s = GameManager.i.GameState.CurrentState;
        if (transform.position.x > 0) s.p1score++;
        else s.p2score++;
        GameManager.i.GameState.UpdateState(s);
    }

    private void Touch()
    {
        State s = GameManager.i.GameState.CurrentState;
        if (transform.position.x < 0) s.p1touch++;
        else s.p2touch++;
        GameManager.i.GameState.UpdateState(s); 
    }
}
