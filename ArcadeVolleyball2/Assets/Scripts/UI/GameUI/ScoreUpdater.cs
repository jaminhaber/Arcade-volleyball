using TMPro;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI p1;
    [SerializeField] private TextMeshProUGUI p2;
    
    private void Start()
    {
        GameManager.i.GameState.OnStateChange.AddListener(ScoreUpdate);
    }

    private void ScoreUpdate(State state,State old)
    {
        p1.text = state.p1score.ToString("D2");
        p2.text = state.p2score.ToString("D2");
    }
}
