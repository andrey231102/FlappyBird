using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClicked;
        _gameOverScreen.RestartButtonClicked += OnRestartButtonClicked;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _gameOverScreen.RestartButtonClicked -= OnRestartButtonClicked;
        _bird.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnPlayButtonClicked()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClicked()
    {
        _gameOverScreen.Close();
        _pipeGenerator.ResetPool();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.ResetPlayer();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
}
