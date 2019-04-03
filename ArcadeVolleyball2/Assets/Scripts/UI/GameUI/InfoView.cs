using Ball;
using TMPro;
using UnityEngine;

public class InfoView : MonoBehaviour
{
 
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private BallPhysics ball;

    private string _stateInfo;
    private string _ballInfo;
    
    private void Start()
    {
        GameManager.i.GameState.OnStateChange.AddListener(DisplayUpdate);
    }

    private void Update()
    {
        _ballInfo = ball.DebugInfo();
        text.text = $"Mode: {Loader.i.mode.modeName}\n{_stateInfo}\n{_ballInfo}";
    }

    private void DisplayUpdate(State state, State o)
    {
        _stateInfo = $"Touches: {state.p1touch} - {state.p2touch}";
    }
}

