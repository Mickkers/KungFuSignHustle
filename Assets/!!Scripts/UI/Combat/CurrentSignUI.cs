using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSignUI : MonoBehaviour
{

    [SerializeField] Image _signImage;
    [SerializeField] TextMeshProUGUI _countdownText;

    public void StartCountdown(int count)
    {
        if (count <= 0)
        {
            GameManager.Instance.BattleStartSequence();
            return;
        }

        _countdownText.text = count.ToString();
        LeanTween.value(0, 1, 0.5f)
        .setEase(LeanTweenType.easeInOutQuad)
        .setOnUpdate((float value) =>
        {
            _countdownText.gameObject.transform.localScale = new Vector3(value, value, 1);
        })
        .setOnComplete(() =>
        {
            LeanTween.value(1, 0, 0.5f)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnUpdate((float value) =>
            {
                _countdownText.gameObject.transform.localScale = new Vector3(value, value, 1);
            })
            .setOnComplete(() =>
            {
                StartCountdown(count - 1);
            });
        });
    }

    public void SetSignImage(Sprite signSprite)
    {
        LeanTween.value(_signImage.color.a, 0, 0.1f)
        .setEase(LeanTweenType.easeInOutQuad)
        .setOnUpdate((float value) =>
        {
            _signImage.color = new Color(value, value, value, 1);
        })
        .setOnComplete(() =>
        {
            _signImage.sprite = signSprite;
            LeanTween.value(0, 1, 0.1f)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnUpdate((float value) =>
            {
                _signImage.color = new Color(value, value, value, 1);
            });
        });
    }

    public void InstantSetSignImage(Sprite signSprite)
    {
        _signImage.sprite = signSprite;
    }
}
