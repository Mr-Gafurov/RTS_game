using UnityEngine;

namespace Generals.AI
{
    /// <summary>
    /// Логика строительства зданий ИИ.
    /// </summary>
    public class AIBuildingStrategy : MonoBehaviour
    {
        public void EvaluateBuildingNeeds()
        {
            // Простая логика: если мало денег - строим сборщик, если нет армии - бараки
            // Проверка ResourceManager
            Debug.Log("[AIBuildingStrategy] Анализ потребностей в строительстве...");
        }
    }
}
