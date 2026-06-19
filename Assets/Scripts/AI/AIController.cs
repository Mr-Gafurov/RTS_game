using UnityEngine;
using System.Collections.Generic;

namespace Generals.AI
{
    public enum AIPersonality
    {
        Aggressive,
        Defensive,
        Tactical
    }

    /// <summary>
    /// Главный контроллер ИИ.
    /// </summary>
    public class AIController : MonoBehaviour
    {
        [Header("Настройки ИИ")]
        public AIPersonality personality = AIPersonality.Tactical;
        public float difficultyMultiplier = 1.0f;

        private AIBuildingStrategy _buildingStrategy;
        private AIUnitCommander _unitCommander;

        private void Awake()
        {
            _buildingStrategy = GetComponent<AIBuildingStrategy>();
            _unitCommander = GetComponent<AIUnitCommander>();
        }

        private void Start()
        {
            InvokeRepeating("PerformTick", 1f, 2f);
        }

        private void PerformTick()
        {
            // Главный цикл принятия решений ИИ
            _buildingStrategy?.ExecuteStep();
            _unitCommander?.CommandUnits();
        }

        public void AdaptToPlayer(AIPersonality newPersonality)
        {
            personality = newPersonality;
            Debug.Log($"[AIController] Личность ИИ изменена на: {newPersonality}");
        }
    }
}
