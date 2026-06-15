using UnityEngine;
using System.Collections.Generic;

namespace Generals.Units
{
    /// <summary>
    /// Система Героя-Генерала с уровнями и талантами.
    /// </summary>
    public class GeneralHero : BaseUnit
    {
        [Header("Прогрессия")]
        public int level = 1;
        public float currentXP = 0f;
        public float xpToNextLevel = 1000f;

        [Header("Способности")]
        public List<string> unlockedAbilities = new List<string>();

        public void GainXP(float amount)
        {
            currentXP += amount;
            if (currentXP >= xpToNextLevel)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            level++;
            currentXP -= xpToNextLevel;
            xpToNextLevel *= 1.5f;

            Debug.Log($"[GeneralHero] Повышение уровня! Текущий уровень: {level}");
            // Логика разблокировки новых талантов
        }
    }
}
