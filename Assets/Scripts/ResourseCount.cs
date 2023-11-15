using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]

public class ResourseCount : MonoBehaviour
{
    [SerializeField] private Station _station;

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        ShowCristalCount();
    }

    public void ShowCristalCount() =>
        _text.text = "Кристалы: " + _station.ResourseCount;
}