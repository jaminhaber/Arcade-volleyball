using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private RectTransform title;
    [SerializeField] private RectTransform buttons;
    [SerializeField] private RectTransform modes;

    private const float transitionTime = 1.6f; 
    
    private void Start()
    {
        startButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        title.DOMoveY(7, transitionTime);
        buttons.DOMoveY(-7, transitionTime);
        modes.DOMoveY(0, transitionTime); 
    }

}

//Loader.i.LoadGame
