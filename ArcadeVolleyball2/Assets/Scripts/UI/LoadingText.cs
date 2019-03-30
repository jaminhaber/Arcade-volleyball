using System.Collections;
using TMPro;
using UnityEngine;

public class LoadingText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private string st;

    [SerializeField] private float waitBetweenDots = .4f;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        st = text.text;
        StartCoroutine(Dot());
    }

    private IEnumerator Dot()
    {
        int numDots = 0;

        while (true)
        {
            yield return new WaitForSeconds(waitBetweenDots);
            numDots++;
            numDots %= 4;
            text.text = st + repeat(numDots, '.');
        }
    }

    private static string repeat(int num, char c)
    {
        string output = "";
        for (uint i = 0; i < num; i++)
            output += c;
        return output;
    }
}