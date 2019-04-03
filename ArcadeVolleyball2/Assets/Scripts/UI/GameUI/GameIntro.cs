using DG.Tweening;
using Skins;
using TMPro;
using UnityEngine;

public class GameIntro : MonoBehaviour, IReset, ISkin
{
    [SerializeField] private TextMeshProUGUI _gameMode;
    [SerializeField] private RectTransform _rect;

    private const float EaseTime = 1.6f;

    private float _startPosition;
    private float _midPosition;
    private float _endPosition;


    private void Start()
    {
        _midPosition = _rect.transform.position.x;
        _startPosition = _midPosition + 20;
        _endPosition = _midPosition - 20;
        ResetForNewRound();
    }

    public void ResetForNewRound()
    {
        _gameMode.text = Loader.i.mode.modeName;
        
        _gameMode.transform.localPosition = _gameMode.transform.localPosition + new Vector3(100, 0);

        _rect.transform.position = new Vector3(_startPosition, _rect.transform.position.y);
        _rect.DOMoveX(_midPosition, EaseTime).SetEase(Ease.OutQuart).OnComplete(() =>
            _rect.DOMoveX(_endPosition, EaseTime).SetEase(Ease.InQuart)
        );
    }

    public void ResetForNewGame()
    {
        ResetForNewRound();
    }

    public void Paint(BackgroundSet s)
    {
        _gameMode.color = s.TitleColor;
    }
}