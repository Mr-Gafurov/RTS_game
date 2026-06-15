using UnityEngine;
using System.Collections.Generic;

namespace Generals.Core
{
    using Generals.Units;

    /// <summary>
    /// Контейнер данных для характеристик фракции.
    /// </summary>
    [CreateAssetMenu(fileName = "FactionData", menuName = "Generals/FactionData")]
    public class FactionData : ScriptableObject
    {
        public string factionName;
        public FactionType factionType;
        public Color factionColor;

        [Header("Стартовые бонусы")]
        public float initialMoney = 1000f;
        public float buildingHealthMultiplier = 1f;
        public float unitSpeedMultiplier = 1f;

        // Список префабов юнитов и зданий, доступных этой фракции
        // public List<GameObject> availableUnits;
        // public List<GameObject> availableBuildings;
    }
}
