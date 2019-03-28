using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startGame;

    private void Start()
    {
        startGame.onClick.AddListener(Loader.i.LoadGame);
    }

}
