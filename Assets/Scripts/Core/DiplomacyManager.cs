using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    public enum DiplomacyStatus
    {
        Ally,
        Enemy,
        Neutral
    }

    /// <summary>
    /// Менеджер дипломатических отношений.
    /// </summary>
    public class DiplomacyManager : MonoBehaviour
    {
        public static DiplomacyManager Instance { get; private set; }

        private Dictionary<int, DiplomacyStatus> _playerRelations = new Dictionary<int, DiplomacyStatus>();

        private void Awake()
        {
            Instance = this;
        }

        public void SetRelation(int playerIndex, DiplomacyStatus status)
        {
            _playerRelations[playerIndex] = status;
            Debug.Log($"[Diplomacy] Отношения с игроком {playerIndex} изменены на {status}");
        }

        public DiplomacyStatus GetRelation(int playerIndex)
        {
            if (_playerRelations.TryGetValue(playerIndex, out DiplomacyStatus status))
                return status;
            return DiplomacyStatus.Enemy; // По умолчанию все враги
        }

        public bool IsAlly(int playerIndex)
        {
            return GetRelation(playerIndex) == DiplomacyStatus.Ally;
        }
    }
}
