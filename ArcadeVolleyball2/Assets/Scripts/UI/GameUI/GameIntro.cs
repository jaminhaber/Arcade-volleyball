using DG.Tweening;
using Skins;
using TMPro;
using UnityEngine;

public class GameIntro : MonoBehaviour, ISkin
{
    [SerializeField] private TextMeshProUGUI _gameMode;
    [SerializeField] private TextMeshProUGUI _info;

    [SerializeField] private RectTransform _rect;

    private const float EaseTime = 1.6f;

    private float _startPosition;
    private float _midPosition;
    private float _endPosition;

    private void Start()
    {
        _midPosition = _rect.transform.position.x;
        _startPosition = _midPosition + 25;
        _endPosition = _midPosition - 25;
        
        GameManager.i.OnNewGame.AddListener(DoIntro);
    }

    private void DoIntro()
    {
        InitCanvasMove();
        _gameMode.text = Loader.i.mode.modeName;
        _info.text = $"{GameManager.i.GameState.CurrentState.p1wins} - {GameManager.i.GameState.CurrentState.p2wins}";
    }

    private void InitCanvasMove()
    {
        _rect.transform.position = new Vector3(_startPosition, _rect.transform.position.y);
        _rect.DOMoveX(_midPosition, EaseTime).SetEase(Ease.OutQuart).OnComplete(() =>
            _rect.DOMoveX(_endPosition, EaseTime).SetEase(Ease.InQuart).OnComplete(()=>{})
        );
    }

    public void Paint(BackgroundSet s)
    {
        _gameMode.color = s.UiColor;
        _info.color = s.UiColor;
    }
}