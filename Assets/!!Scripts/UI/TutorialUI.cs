using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] Button _openTutorialButton;

    [SerializeField] TextMeshProUGUI _pageText;

    [SerializeField] Button _nextTutorialButton;
    [SerializeField] Button _previousTutorialButton;

    [SerializeField] List<Sprite> _tutorialSprites;
    [SerializeField] Image _tutorialImage;
    [SerializeField] GameObject _tutorialPanel;

    private int _currentTutorialIndex = 0;

    private void Start()
    {
        _openTutorialButton.onClick.AddListener(OpenTutorial);

        _nextTutorialButton.onClick.AddListener(NextTutorial);
        _previousTutorialButton.onClick.AddListener(PreviousTutorial);

        if (!LevelManager.Instance.HasSeenTutorial)
        {
            OpenTutorial();
            LevelManager.Instance.HasSeenTutorial = true;
        }
        else
        {
            CloseTutorial();
        }

    }

    private void CloseTutorial()
    {
        _tutorialPanel.SetActive(false);
    }

    private void OpenTutorial()
    {
        SetTutorialPage(0);
        _tutorialPanel.SetActive(true);
    }

    private void NextTutorial()
    {
        if (_currentTutorialIndex+1 < _tutorialSprites.Count)
        {
            SetTutorialPage(_currentTutorialIndex+1);
        }
        else
        {
            CloseTutorial();
        }
    }

    private void PreviousTutorial()
    {
        if (_currentTutorialIndex-1 >= 0)
        {
            SetTutorialPage(_currentTutorialIndex-1);
        }
    }

    private void SetTutorialPage(int page)
    {
        _currentTutorialIndex = Mathf.Clamp(page, 0, _tutorialSprites.Count - 1);
        _tutorialImage.sprite = _tutorialSprites[_currentTutorialIndex];
        _pageText.text = _currentTutorialIndex+1+"/"+_tutorialSprites.Count;

        if (_currentTutorialIndex == 0)
        {
            _previousTutorialButton.interactable = false;
        }
        else
        {
            _previousTutorialButton.interactable = true;
        }
    }
}
