using UnityEngine;

namespace Generals.Core
{
    using Generals.Units;

    /// <summary>
    /// Контейнер данных для характеристик конкретного юнита.
    /// </summary>
    [CreateAssetMenu(fileName = "UnitData", menuName = "Generals/UnitData")]
    public class UnitData : ScriptableObject
    {
        public string unitName;
        public FactionType faction;

        [Header("Боевые характеристики")]
        public float maxHealth = 100f;
        public float damage = 10f;
        public float attackRange = 15f;
        public float attackRate = 1f;
        public float movementSpeed = 5f;
        public float viewRange = 20f;

        [Header("Экономика")]
        public int cost = 100;
        public float buildTime = 5f;

        [Header("Визуал")]
        public GameObject prefab;
        public Sprite icon;
    }
}
