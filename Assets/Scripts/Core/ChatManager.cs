using UnityEngine;
using System.Collections.Generic;
using System;

namespace Generals.Core
{
    [Serializable]
    public class ChatMessage
    {
        public string senderId;
        public string text;
        public string channel;
        public long timestamp;
    }

    /// <summary>
    /// Менеджер чата. Взаимодействует с бэкендом через WebSocket.
    /// </summary>
    public class ChatManager : MonoBehaviour
    {
        public static ChatManager Instance { get; private set; }

        public List<ChatMessage> globalMessages = new List<ChatMessage>();
        public event Action<ChatMessage> OnMessageReceived;

        private void Awake()
        {
            Instance = this;
        }

        public void SendMessage(string text, string channel = "global")
        {
            // Логика отправки сообщения на сервер
            Debug.Log($"[ChatManager] Отправка в {channel}: {text}");
        }

        public void HandleIncomingMessage(ChatMessage message)
        {
            globalMessages.Add(message);
            if (globalMessages.Count > 100) globalMessages.RemoveAt(0);

            OnMessageReceived?.Invoke(message);
        }
    }
}
