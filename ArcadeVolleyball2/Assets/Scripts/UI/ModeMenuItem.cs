using Skins;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModeMenuItem : MonoBehaviour, ISkin
{

    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;

    private GameMode _mode;

    public void Init(GameMode mode)
    {
        _mode = mode;
        title.text = mode.modeName;
        description.text = mode.description;
        _button.onClick.AddListener(() =>
        {
            Loader.i.mode = _mode;
            Loader.i.LoadGame();
        });
        Paint(BackgroundLoader.CurrentBackground);
    }

    public void Paint(BackgroundSet s)
    {
        _button.GetComponent<Image>().color = s.UiColor;
        title.color = s.ScoreColor;
        description.color = s.ScoreColor;
    }
}