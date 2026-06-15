using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Глобальное звание игрока.
    /// </summary>
    public class GeneralsRankManager : MonoBehaviour
    {
        public static GeneralsRankManager Instance { get; private set; }

        public int currentRank = 1; // 1 to 5 Stars
        public int totalExp = 0;

        private void Awake()
        {
            Instance = this;
        }

        public void AddExp(int amount)
        {
            totalExp += amount;
            if (totalExp >= currentRank * 5000)
            {
                currentRank++;
                Debug.Log($"[Rank] Новое звание: {currentRank} Звезды!");
            }
        }
    }
}
