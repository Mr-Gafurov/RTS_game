using UnityEngine;
using System.Collections.Generic;
using System;

namespace Generals.Core
{
    [Serializable]
    public class FriendData
    {
        public string id;
        public string username;
        public bool isOnline;
        public bool isInMatch;
    }

    /// <summary>
    /// Менеджер списка друзей.
    /// </summary>
    public class FriendManager : MonoBehaviour
    {
        public static FriendManager Instance { get; private set; }

        public List<FriendData> friends = new List<FriendData>();

        private void Awake()
        {
            Instance = this;
        }

        public void AddFriend(string friendId)
        {
            Debug.Log($"[Social] Запрос в друзья отправлен пользователю {friendId}");
            // API call
        }

        public void InviteToGame(string friendId)
        {
            Debug.Log($"[Social] Приглашение в игру отправлено другу {friendId}");
            // API call
        }

        public void UpdateFriendStatus(string friendId, bool online, bool match)
        {
            var friend = friends.Find(f => f.id == friendId);
            if (friend != null)
            {
                friend.isOnline = online;
                friend.isInMatch = match;
            }
        }
    }
}
