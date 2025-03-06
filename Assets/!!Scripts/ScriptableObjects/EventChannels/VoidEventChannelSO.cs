using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/EventChannels/VoidEventChannel", fileName = "VoidEventChannel")]
public class VoidEventChannelSO : DescriptionSO
{
    [Tooltip("The action to perform")]
        public UnityAction OnEventRaised;

        public void RaiseEvent()
        {
            if (OnEventRaised != null)
            {
                OnEventRaised.Invoke();
            }
        }
}
