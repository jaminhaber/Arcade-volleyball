using Skins;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpdater : MonoBehaviour, ISkin
{
    public void Paint(BackgroundSet s)
    {
        GetComponent<Image>().color = s.UiColor;
        GetComponentInChildren<TextMeshProUGUI>().color = s.ScoreColor;
    }
}