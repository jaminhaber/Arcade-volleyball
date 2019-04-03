using UnityEngine;

public class ModeMenu : MonoBehaviour
{
    [SerializeField] private ModeMenuItem prefab;

    private GameMode[] _modes;

    private void Start()
    {
        _modes = Resources.LoadAll<GameMode>("GameModes");

        foreach (GameMode t in _modes)
            Instantiate(prefab, transform).Init(t);
    }

}