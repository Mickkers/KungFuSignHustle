using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelList", menuName = "ScriptableObjects/LevelList")]
public class LevelListSO : ScriptableObject
{
    public List<LevelSO> Levels;
}
