using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButtonUI : MonoBehaviour
{
    [SerializeField] GameObject _settingsPanel;
    
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Clicked);
    }

    private void Clicked()
    {
        _settingsPanel.SetActive(!_settingsPanel.activeSelf);
    }
}
