using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarSelectLevelNumUI : MonoBehaviour
{
    [SerializeField] LevelStarManager _levelStarManager;

    private void Start()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();

        text.text = "Level " + _levelStarManager.levelIndex.ToString("D2");
    }
}
