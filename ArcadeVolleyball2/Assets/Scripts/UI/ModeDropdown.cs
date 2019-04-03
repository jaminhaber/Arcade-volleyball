using System.Collections.Generic;
using System.Linq;
using Skins;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModeDropdown : MonoBehaviour, ISkin
{

    [SerializeField] private TMP_Dropdown _dropdown;

    private GameMode[] modes;
    private void Start()
    {
        _dropdown.ClearOptions();
        _dropdown.AddOptions(GetOptions());
        _dropdown.onValueChanged.AddListener(onChoiceMade);

        _dropdown.value = PlayerPrefs.GetInt("mode", 0);
        Loader.i.mode = modes[_dropdown.value];
        _dropdown.RefreshShownValue();
    }

    private void onChoiceMade(int v)
    {
        Loader.i.mode = modes[v];
        PlayerPrefs.SetInt("mode",v);
        Debug.Log(v);
    }
    

    private List<TMP_Dropdown.OptionData> GetOptions()
    {
        modes = Resources.LoadAll<GameMode>("GameModes");
        return modes.Select(mode => new TMP_Dropdown.OptionData(mode.modeName)).ToList();
    }


    public void Paint(BackgroundSet s)
    {
        _dropdown.GetComponent<Image>().color = s.UiColor;

        foreach (TextMeshProUGUI t in  _dropdown.GetComponentsInChildren<TextMeshProUGUI>())
            t.color =  s.ScoreColor;

    }
}
