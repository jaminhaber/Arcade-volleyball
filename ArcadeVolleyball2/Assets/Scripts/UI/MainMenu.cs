using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startGame;

    private void Start()
    {
        startGame.onClick.AddListener(() => { SceneManager.LoadScene("VolleyBall"); });
    }

}
