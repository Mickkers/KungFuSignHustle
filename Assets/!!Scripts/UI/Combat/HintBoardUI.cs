using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class HintBoardUI : MonoBehaviour
{
    public static HintBoardUI Instance { get; private set; }

    [SerializeField] float _yMovement = 275;

    private float _startYPos;
    private RectTransform _rectTransform;

    [SerializeField] TextMeshProUGUI _hintText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();

        _startYPos = _rectTransform.localPosition.y;

        LeanTween.moveLocalY(gameObject, _startYPos + _yMovement, 0f);
    }

    private float _moveTime = 0.1f;

    public void ShowHint()
    {
        _hintText.text = SignGenerator.Instance.CurrentSign.SignHintText;

        LeanTween.moveLocalY(gameObject, _startYPos, _moveTime)
        .setEase(LeanTweenType.easeInOutQuad);
    }

    public void HideHint()
    {
        LeanTween.moveLocalY(gameObject, _startYPos + _yMovement, _moveTime)
        .setEase(LeanTweenType.easeInOutQuad);
    }
}
