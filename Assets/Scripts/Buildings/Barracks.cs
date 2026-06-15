using UnityEngine;
using System.Collections.Generic;

namespace Generals.Buildings
{
    using Generals.Units;

    /// <summary>
    /// Казарма. Производит пехоту.
    /// </summary>
    public class Barracks : BaseBuilding
    {
        [Header("Очередь производства")]
        public List<GameObject> unitPrefabs;

        protected override void Start()
        {
            buildingName = "Barracks";
            maxHealth = 800f;
            cost = 500;
            energyConsumption = 10f;
            base.Start();
        }

        public void ProduceUnit(int unitIndex)
        {
            if (unitIndex >= 0 && unitIndex < unitPrefabs.Count)
            {
                // Логика таймера производства и спавна юнита
                Debug.Log($"[Barracks] Производство юнита: {unitPrefabs[unitIndex].name}");
            }
        }
    }
}
