using UnityEngine;
using System;

namespace Generals.Core
{
    /// <summary>
    /// Менеджер ежедневных наград.
    /// </summary>
    public class DailyRewardManager : MonoBehaviour
    {
        public static DailyRewardManager Instance { get; private set; }

        public int streakDays = 0;
        public DateTime lastClaimDate;

        private void Awake()
        {
            Instance = this;
            LoadProgress();
        }

        public bool CanClaim()
        {
            return (DateTime.Now.Date - lastClaimDate.Date).Days >= 1;
        }

        public void ClaimReward()
        {
            if (!CanClaim()) return;

            streakDays++;
            lastClaimDate = DateTime.Now;

            Debug.Log($"[Rewards] Награда за день {streakDays} получена!");
            SaveProgress();

            // Выдача награды через ResourceManager
            ResourceManager.Instance?.AddMoney(100 * streakDays);
        }

        private void SaveProgress()
        {
            PlayerPrefs.SetInt("RewardStreak", streakDays);
            PlayerPrefs.SetString("LastClaimDate", lastClaimDate.ToString());
        }

        private void LoadProgress()
        {
            streakDays = PlayerPrefs.GetInt("RewardStreak", 0);
            string dateStr = PlayerPrefs.GetString("LastClaimDate", DateTime.MinValue.ToString());
            DateTime.TryParse(dateStr, out lastClaimDate);
        }
    }
}
