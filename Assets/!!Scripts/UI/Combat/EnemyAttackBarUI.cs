using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttackBarUI : MonoBehaviour
{
    [SerializeField] EnemyAttack _eAttack;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        _slider.value = _eAttack.AttackChargeProgress;
    }
}
