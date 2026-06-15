using UnityEngine;

namespace Generals.AI
{
    /// <summary>
    /// Автоматическая подстройка сложности под уровень игры пользователя.
    /// </summary>
    public class AIDifficultyScaler : MonoBehaviour
    {
        public float playerEfficiency = 1.0f;

        public void AdjustDifficulty(float playerWinRate)
        {
            if (playerWinRate > 0.8f)
            {
                Debug.Log("[DDA] Игрок слишком силен. Усиливаю ИИ.");
                // Увеличение ресурсов ИИ или скорости постройки
            }
            else if (playerWinRate < 0.3f)
            {
                Debug.Log("[DDA] Игроку трудно. Ослабляю ИИ.");
            }
        }
    }
}
