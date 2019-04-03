using UnityEngine;

public class ModeMenu : MonoBehaviour
{
    [SerializeField] private ModeMenuItem prefab;

    private void Start()
    {
        GameMode[] modes = Resources.LoadAll<GameMode>("GameModes");

        foreach (GameMode t in modes)
            Instantiate(prefab, transform).Init(t);
    }

}