using UnityEngine;

namespace Generals.AI
{
    /// <summary>
    /// Профиль личности ИИ-Генерала с уникальными бонусами и тактикой.
    /// </summary>
    [CreateAssetMenu(fileName = "AIGeneralProfile", menuName = "Generals/AI/GeneralProfile")]
    public class AIGeneralProfile : ScriptableObject
    {
        public string generalName;
        public FactionType faction;

        [Header("Экономические модификаторы")]
        public float unitCostMultiplier = 1.0f;
        public float buildingCostMultiplier = 1.0f;
        public float resourceCollectionMultiplier = 1.0f;

        [Header("Тактические предпочтения")]
        public float aggressionLevel = 0.5f; // 0 to 1
        public AIStrategyPattern preferredPattern = AIStrategyPattern.Turtle;
        public bool prioritizesAirForce = false;

        [Header("Спецспособности")]
        public string signatureAbilityId;
    }
}
