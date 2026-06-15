using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Generals.Core
{
    /// <summary>
    /// Сетевой менеджер для синхронизации с Colyseus.
    /// </summary>
    public class NetworkManager : MonoBehaviour
    {
        public static NetworkManager Instance { get; private set; }

        public string serverUrl = "ws://localhost:4000";
        public bool isConnected = false;

        private void Awake()
        {
            Instance = this;
        }

        public void Connect()
        {
            Debug.Log($"[Network] Подключение к {serverUrl}...");
            // В реальном проекте здесь будет инициализация Colyseus Client
            StartCoroutine(SimulateConnection());
        }

        private IEnumerator SimulateConnection()
        {
            yield return new WaitForSeconds(1f);
            isConnected = true;
            Debug.Log("[Network] Соединение установлено.");
        }

        public void SendCommand(string command, object data)
        {
            if (!isConnected) return;
            // Отправка сообщения в комнату
            Debug.Log($"[Network] Отправлена команда: {command}");
        }

        public void SyncUnitPosition(string id, Vector3 position)
        {
            // Синхронизация координат юнита
        }
    }
}
