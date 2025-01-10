using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance { get; private set; }

    [SerializeField] GameObject _gameLosePanel;
    [SerializeField] GameObject _gameWinPanel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        _gameLosePanel.SetActive(false);
        _gameWinPanel.SetActive(false);
    }

    public void ShowLose()
    {
        _gameLosePanel.SetActive(true);
        _gameWinPanel.SetActive(false);
    }

    public void ShowWin()
    {
        _gameLosePanel.SetActive(false);
        _gameWinPanel.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("ChooseLevel");
    }
}
