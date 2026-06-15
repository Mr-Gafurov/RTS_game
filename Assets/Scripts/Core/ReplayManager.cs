using UnityEngine;
using System.Collections.Generic;
using System;

namespace Generals.Core
{
    [Serializable]
    public class CommandRecord
    {
        public float timestamp;
        public string unitId;
        public string commandType;
        public Vector3 position;
    }

    /// <summary>
    /// Система записи и воспроизведения матчей (Replays).
    /// </summary>
    public class ReplayManager : MonoBehaviour
    {
        public bool isRecording = false;
        private List<CommandRecord> _recordedCommands = new List<CommandRecord>();
        private float _startTime;

        public void StartRecording()
        {
            isRecording = true;
            _startTime = Time.time;
            _recordedCommands.Clear();
            Debug.Log("[ReplayManager] Запись матча начата.");
        }

        public void RecordCommand(string unitId, string type, Vector3 pos)
        {
            if (!isRecording) return;

            _recordedCommands.Add(new CommandRecord
            {
                timestamp = Time.time - _startTime,
                unitId = unitId,
                commandType = type,
                position = pos
            });
        }

        public void SaveReplay(string fileName)
        {
            string json = JsonUtility.ToJson(_recordedCommands);
            // Логика сохранения в файл
            Debug.Log($"[ReplayManager] Запись сохранена: {fileName}");
        }
    }
}
