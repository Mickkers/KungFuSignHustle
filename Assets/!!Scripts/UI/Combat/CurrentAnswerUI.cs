using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrentAnswerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _answerText;
    [SerializeField] Image _lockIcon;

    private void Update()
    {
        if (CombatInputManager.Instance.enabled == false)
        {
            _answerText.text = string.Empty;
            _lockIcon.enabled = true;
        }
        else
        {
            _lockIcon.enabled = false;
            _answerText.text = PlayerManager.Instance.PAttack.CurrentAnswerKey;
        }
    }
}
