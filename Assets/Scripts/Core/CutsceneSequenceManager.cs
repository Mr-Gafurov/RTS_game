using UnityEngine;
using System.Collections.Generic;
using System;

namespace Generals.Core.Story
{
    [Serializable]
    public class CutsceneAction
    {
        public float time;
        public string actionType; // MoveCamera, AnimateUnit, ShowUI
        public Vector3 position;
        public string data;
    }

    /// <summary>
    /// Контроллер скриптовых кат-сцен на движке.
    /// </summary>
    public class CutsceneSequenceManager : MonoBehaviour
    {
        public List<CutsceneAction> actions = new List<CutsceneAction>();
        private bool _isPlaying = false;
        private float _timer = 0f;

        public void Play()
        {
            _isPlaying = true;
            _timer = 0f;
            Debug.Log("[Cutscene] Начало воспроизведения...");
            GameManager.Instance?.ChangeState(GameState.Paused); // Временная пауза геймплея
        }

        private void Update()
        {
            if (!_isPlaying) return;

            _timer += Time.deltaTime;
            // Проверка и выполнение экшенов по времени
        }

        public void Stop()
        {
            _isPlaying = false;
            Debug.Log("[Cutscene] Кат-сцена завершена.");
            GameManager.Instance?.ChangeState(GameState.Battle);
        }
    }
}
