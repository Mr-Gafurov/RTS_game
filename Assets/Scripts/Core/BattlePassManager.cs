using UnityEngine;
using System.Collections.Generic;
using System;

namespace Generals.Core
{
    [Serializable]
    public class BattlePassTier
    {
        public int level;
        public string freeReward;
        public string premiumReward;
        public bool isPremium = false;
    }

    /// <summary>
    /// Менеджер Боевого Пропуска.
    /// </summary>
    public class BattlePassManager : MonoBehaviour
    {
        public static BattlePassManager Instance { get; private set; }

        public int currentLevel = 1;
        public float currentXP = 0f;
        public float xpPerLevel = 1000f;
        public bool hasPremium = false;

        public List<BattlePassTier> tiers = new List<BattlePassTier>();

        private void Awake()
        {
            Instance = this;
        }

        public void AddXP(float amount)
        {
            currentXP += amount;
            if (currentXP >= xpPerLevel)
            {
                currentLevel++;
                currentXP -= xpPerLevel;
                Debug.Log($"[BattlePass] Новый уровень достигнут: {currentLevel}");
            }
        }

        public void ClaimReward(int level, bool premium)
        {
            if (level > currentLevel) return;
            if (premium && !hasPremium) return;

            Debug.Log($"[BattlePass] Получена награда за уровень {level} (Premium: {premium})");
        }
    }
}
