using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Game : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private StartGameScreen _startGameScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    private void OnEnable()
    {
        _startGameScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _ship.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startGameScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _ship.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startGameScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }
    private void OnPlayButtonClick()
    {
        _startGameScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _ship.Reset();
        EnemiesReset();
        BulletsReset();
    }
    
    private void EnemiesReset()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
            Destroy(enemy.gameObject);
    }

    private void BulletsReset()
    {
        Bullet[] bullets = FindObjectsOfType<Bullet>();

        foreach (Bullet bullet in bullets)
            Destroy(bullet.gameObject);
    }
}
