using UnityEngine;
using System.Collections.Generic;
using Generals.Core;
using Generals.Buildings;

namespace Generals.AI
{
    /// <summary>
    /// Продвинутая стратегия строительства ИИ.
    /// </summary>
    public class AIBuildingStrategy : MonoBehaviour
    {
        [Header("Префабы зданий")]
        public GameObject powerPlantPrefab;
        public GameObject supplyDepotPrefab;
        public GameObject barracksPrefab;
        public GameObject warFactoryPrefab;

        private List<BaseBuilding> _aiBuildings = new List<BaseBuilding>();

        public void ExecuteStep()
        {
            if (ResourceManager.Instance.Money < 500) return;

            if (ResourceManager.Instance.IsLowEnergy)
            {
                Build(powerPlantPrefab);
                return;
            }

            int depotCount = GetBuildingCount<SupplyDepot>();
            if (depotCount < 1)
            {
                Build(supplyDepotPrefab);
                return;
            }

            int barracksCount = GetBuildingCount<Barracks>();
            if (barracksCount < 1)
            {
                Build(barracksPrefab);
                return;
            }

            int factoryCount = GetBuildingCount<Factory>();
            if (factoryCount < 1)
            {
                Build(warFactoryPrefab);
            }
        }

        private void Build(GameObject prefab)
        {
            if (prefab == null) return;
            Vector3 buildPos = transform.position + new Vector3(Random.Range(20, 50), 0, Random.Range(20, 50));
            GameObject building = Instantiate(prefab, buildPos, Quaternion.identity);
            _aiBuildings.Add(building.GetComponent<BaseBuilding>());
            Debug.Log($"[AI] Построено здание: {prefab.name}");
        }

        private int GetBuildingCount<T>() where T : BaseBuilding
        {
            int count = 0;
            foreach (var b in _aiBuildings)
            {
                if (b != null && b is T) count++;
            }
            return count;
        }
    }
}
