using Skins;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUpdater : MonoBehaviour, ISkin
{
    public void Paint(BackgroundSet s)
    {
        GetComponent<Image>().color = s.UiColor;
        GetComponentInChildren<Text>().color = s.ScoreColor;
    }
}