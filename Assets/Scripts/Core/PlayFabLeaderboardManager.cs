using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core.Cloud
{
    /// <summary>
    /// Синхронизация таблиц лидеров с PlayFab.
    /// </summary>
    public class PlayFabLeaderboardManager : MonoBehaviour
    {
        public void UpdateEloRating(int newElo)
        {
            Debug.Log($"[PlayFab] Обновление рейтинга в таблице лидеров: {newElo}");
            // Вызов PlayFabClientAPI.UpdatePlayerStatistics
        }

        public void GetGlobalLeaderboard(string statisticName)
        {
            Debug.Log($"[PlayFab] Запрос ТОП-10 для {statisticName}");
            // Вызов PlayFabClientAPI.GetLeaderboard
        }
    }
}
