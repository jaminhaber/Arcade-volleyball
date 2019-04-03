using TMPro;
using UnityEngine;

public class InfoView : MonoBehaviour
{
 
    [SerializeField] private TextMeshProUGUI text;

    private string _stateInfo;
    
    private void Start()
    {
        GameManager.i.GameState.OnStateChange.AddListener(DisplayUpdate);
    }

    private void Update()
    {
        text.text = $"Mode: {Loader.i.mode.modeName}\n{_stateInfo}";
    }

    private void DisplayUpdate(State state, State o)
    {
        _stateInfo = $"Touches: {state.p1touch} - {state.p2touch}";
    }
}

