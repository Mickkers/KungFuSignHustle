using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image _mainMenuImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        LeanTween.moveLocalY(_mainMenuImage.gameObject, _mainMenuImage.transform.localPosition.y - 800f, 2f)
        .setOnComplete(() =>
        {
            SceneManager.LoadScene("ChooseLevel");
        })
        .setEase(LeanTweenType.easeInOutCubic);
    }
}
