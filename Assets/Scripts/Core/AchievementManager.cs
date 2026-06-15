using UnityEngine;
using System.Collections.Generic;
using System;

namespace Generals.Core
{
    [Serializable]
    public class Achievement
    {
        public string id;
        public string title;
        public int targetCount;
        public int currentCount;
        public bool isUnlocked = false;
    }

    /// <summary>
    /// Менеджер достижений.
    /// </summary>
    public class AchievementManager : MonoBehaviour
    {
        public static AchievementManager Instance { get; private set; }

        public List<Achievement> achievements = new List<Achievement>();

        private void Awake()
        {
            Instance = this;
        }

        public void ProgressAchievement(string id, int amount = 1)
        {
            var achievement = achievements.Find(a => a.id == id);
            if (achievement != null && !achievement.isUnlocked)
            {
                achievement.currentCount += amount;
                if (achievement.currentCount >= achievement.targetCount)
                {
                    UnlockAchievement(achievement);
                }
            }
        }

        private void UnlockAchievement(Achievement achievement)
        {
            achievement.isUnlocked = true;
            Debug.Log($"[Achievement] Достижение разблокировано: {achievement.title}");
        }
    }
}
