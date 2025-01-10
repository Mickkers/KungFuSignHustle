using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public LevelListSO LevelList;

    public LevelSO CurrentLevel;
    public LevelDifficulty CurrentDifficulty;

    public Dictionary<int, bool> LevelUnlocked = new Dictionary<int, bool>();
    public Dictionary<int, LevelDifficulty> HighestDifficulty = new Dictionary<int, LevelDifficulty>();
    public bool HasSeenTutorial = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        foreach (var level in LevelList.Levels)
        {
            LevelUnlocked.Add(LevelList.Levels.IndexOf(level), false);
            HighestDifficulty.Add(LevelList.Levels.IndexOf(level), LevelDifficulty.Easy);
        }
        LevelUnlocked[LevelList.Levels.IndexOf(LevelList.Levels[0])] = true;
    }

    public void LevelCompleted()
    {
        if ((int)CurrentDifficulty >= (int)HighestDifficulty[LevelList.Levels.IndexOf(CurrentLevel)])
        {
            HighestDifficulty[LevelList.Levels.IndexOf(CurrentLevel)] = CurrentDifficulty;
            if (LevelList.Levels.IndexOf(CurrentLevel)+1 < LevelUnlocked.Count) LevelUnlocked[LevelList.Levels.IndexOf(CurrentLevel)+1] = true;

        }
    }

    public void LoadLevel(int levelIndex, int difficultyIndex)
    {
        CurrentLevel = LevelList.Levels[levelIndex - 1];
        CurrentDifficulty = (LevelDifficulty)difficultyIndex;
    }
    
    public enum LevelDifficulty
    {
        Easy,           // No modifier
        Medium,         // Answer lockout
        Hard,           // No hints & Answer lockout
        Master         // Faster Attack & No hints & Answer lockout
    }
}
