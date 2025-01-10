using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitVisual : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public void PlayAnimation(AnimationTrigger trigger)
    {
        _animator.SetTrigger(trigger.ToString());
    }

    public enum AnimationTrigger
    {
        Hit,
        AtkOne,
        AtkTwo,
        Dead
    }
}
