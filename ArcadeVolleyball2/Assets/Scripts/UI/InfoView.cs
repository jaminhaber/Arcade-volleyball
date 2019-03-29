using TMPro;
using UnityEngine;

public class InfoView : MonoBehaviour
{
 
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        GameManager.i.GameState.OnStateChange.AddListener(DisplayUpdate);

    }

    private void DisplayUpdate(State state)
    {
        text.text = $"Touches: {state.p1touch} - {state.p2touch}";
    }
}

