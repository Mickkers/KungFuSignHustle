using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHealthBarUI : MonoBehaviour
{
    [SerializeField] UnitHealth _unit;

    private Slider _healthSlider;

    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        _healthSlider.value = _unit.GetHealthNormalized();
    }
}
