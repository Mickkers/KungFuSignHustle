using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStarManager : MonoBehaviour
{
    int currentStarNum = 0;
    public int levelIndex;

    public void BackButton()
    {
        SceneManager.LoadScene("ChooseLevel");
    }

    public void PressStars(int starNum)
    {
        LevelManager.Instance.LoadLevel(levelIndex, starNum);
        SceneManager.LoadScene("CombatRemakeScene");
    }
}
