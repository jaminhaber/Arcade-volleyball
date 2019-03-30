using System.Collections.Generic;
using System.Linq;
using Skins;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModeDropdown : MonoBehaviour, ISkin
{

    [SerializeField] private TMP_Dropdown _dropdown;

    private void Start()
    {
        _dropdown.options = GetOptions();
    }

    private List<TMP_Dropdown.OptionData> GetOptions()
    {
        GameMode[] modes = Resources.LoadAll<GameMode>("GameModes");
        
        return modes.Select(mode => new TMP_Dropdown.OptionData(mode.name)).ToList();
    }


    public void Paint(BackgroundSet s)
    {
        _dropdown.GetComponent<Image>().color = s.UiColor;

        foreach (TextMeshProUGUI t in  _dropdown.GetComponentsInChildren<TextMeshProUGUI>())
            t.color =  s.ScoreColor;

    }
}
