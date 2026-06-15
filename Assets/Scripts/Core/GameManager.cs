using UnityEngine;
using System;

namespace Generals.Core
{
    /// <summary>
    /// Состояния игры
    /// </summary>
    public enum GameState
    {
        MainMenu,
        Loading,
        Battle,
        Paused,
        GameOver
    }

    /// <summary>
    /// Главный менеджер игры, управляющий состояниями и жизненным циклом матча.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private GameState _currentState = GameState.MainMenu;
        public GameState CurrentState => _currentState;

        public event Action<GameState> OnStateChanged;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void ChangeState(GameState newState)
        {
            if (_currentState == newState) return;

            _currentState = newState;
            OnStateChanged?.Invoke(_currentState);

            Debug.Log($"[GameManager] Состояние игры изменено на: {newState}");

            HandleStateChange(newState);
        }

        private void HandleStateChange(GameState newState)
        {
            switch (newState)
            {
                case GameState.Battle:
                    Time.timeScale = 1f;
                    break;
                case GameState.Paused:
                    Time.timeScale = 0f;
                    break;
                case GameState.GameOver:
                    // Логика завершения игры
                    break;
            }
        }

        public void StartMatch()
        {
            ChangeState(GameState.Battle);
        }

        public void PauseGame()
        {
            if (_currentState == GameState.Battle)
                ChangeState(GameState.Paused);
        }

        public void ResumeGame()
        {
            if (_currentState == GameState.Paused)
                ChangeState(GameState.Battle);
        }
    }
}
