using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sign", menuName = "ScriptableObjects/Sign")]
public class SignSO : ScriptableObject
{
    public Sprite SignSprite;
    public string SignKeyValue;
    [TextArea(3, 10)]
    public string SignHintText;
}
