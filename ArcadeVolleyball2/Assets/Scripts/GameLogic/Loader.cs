using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public static Loader i;

    public GameMode mode;
    public GameSettings settings;
    
    [HideInInspector] public int background;
    [SerializeField] private CanvasGroup loadingScreen;
    [SerializeField] private float loadTime = 3f;
    
    private void Awake()
    {
        if (i == null) i = this;
        else Destroy(gameObject);
        loadingScreen.alpha = 0;

        if (SceneManager.sceneCount == 1) SceneManager.LoadScene("Menu",LoadSceneMode.Additive);
    }

    public void LoadGame()
    {
        StartCoroutine(Loading("VolleyBall","Menu"));
    }
    
    public void LoadMenu()
    {
        StartCoroutine(Loading("Menu","VolleyBall"));
    }

    private IEnumerator Loading(string to,string from)
    {
        loadingScreen.alpha = 1;
        AsyncOperation op = SceneManager.UnloadSceneAsync(from);
        yield return new WaitUntil(() => op.isDone);
        yield return new WaitForSeconds(loadTime);
        op = SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
        yield return new WaitUntil(() => op.isDone);
        loadingScreen.alpha = 0;
    }
}