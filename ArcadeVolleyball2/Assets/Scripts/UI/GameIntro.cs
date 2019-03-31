using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameIntro : MonoBehaviour, IReset
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private TextMeshProUGUI _volley;
    [SerializeField] private TextMeshProUGUI _gameMode;

    private const float EaseTime = 2;

    private float _startPosition;
    private float _midPosition;
    private float _endPosition;


    private void Start()
    {
        _midPosition = _canvas.transform.position.x;
        _startPosition = _midPosition + Screen.width;
        _endPosition = _midPosition - Screen.width;
        ResetForNewRound();
    }
 
    public void ResetForNewRound()
    {
        _gameMode.text = Loader.i.mode.name;
        _volley.transform.localPosition = _volley.transform.localPosition - new Vector3(100,0);
        _gameMode.transform.localPosition = _gameMode.transform.localPosition + new Vector3(100,0);

        _canvas.transform.position = new Vector3(_startPosition,_canvas.transform.position.y );
        _canvas.transform.DOMoveX(_midPosition, EaseTime).SetEase(Ease.OutQuart).OnComplete(() =>
            _canvas.transform.DOMoveX(_endPosition, EaseTime).SetEase(Ease.InQuart));

        _volley.transform.DOLocalMoveX(100, EaseTime * 2);
        _gameMode.transform.DOLocalMoveX(-100, EaseTime * 2);

    }

    public void ResetForNewGame()
    {
        ResetForNewRound();
    }
}