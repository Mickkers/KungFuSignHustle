using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked;
    public Image unlockImage;
    public Sprite starSprite;
    public GameObject[] stars;

    private void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();
    }

    void UpdateLevelStatus()
    {
        int levelIndex = int.Parse(gameObject.name)-1;
        if(LevelManager.Instance.LevelUnlocked[levelIndex])
        {
            unlocked = true;
        }
        else
        {
            unlocked = false;
        }
    }

    private void UpdateLevelImage()
    {
        int levelIndex = int.Parse(gameObject.name)-1;
        if(!unlocked)
        {
            unlockImage.gameObject.SetActive(true);
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }
        }
        else
        {
            unlockImage.gameObject.SetActive(false);
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);
            }

            for(int i = 0; i < (int)LevelManager.Instance.HighestDifficulty[levelIndex]; i++)
            {
                stars[i].gameObject.GetComponent<Image>().sprite = starSprite;
            }
        }
    }

    public void PressSelection(int level)
    {
        if (unlocked)
        {
            SceneManager.LoadScene(((Levels)level-1).ToString());
        }
    }

    public enum Levels
    {
        Level1,
        Level2,
        Level3,
        Level4,
        Level5,
        Level6,
        Level7,
        Level8,
        Level9,
        Level10,
        Level11,
        Level12,
        Level13,
    }
}
