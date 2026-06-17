using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Generals.Buildings
{
    using Generals.Units;
    using Generals.Core;

    /// <summary>
    /// Казармы: очередь производства пехоты.
    /// </summary>
    public class Barracks : BaseBuilding
    {
        [Header("Производство")]
        public List<GameObject> availableUnits; // Префабы юнитов
        public Transform spawnPoint;

        private Queue<int> _productionQueue = new Queue<int>();
        private bool _isProducing = false;

        protected override void Start()
        {
            buildingName = "USA Barracks";
            maxHealth = 800f;
            cost = 500;
            energyConsumption = 10f;
            base.Start();
        }

        public void EnqueueUnit(int index)
        {
            if (index < 0 || index >= availableUnits.Count) return;

            BaseUnit unitScript = availableUnits[index].GetComponent<BaseUnit>();
            if (unitScript != null && ResourceManager.Instance.SpendMoney(unitScript.cost))
            {
                _productionQueue.Enqueue(index);
                Debug.Log($"[Barracks] Юнит {unitScript.unitName} добавлен в очередь.");

                if (!_isProducing)
                {
                    StartCoroutine(ProductionRoutine());
                }
            }
        }

        private IEnumerator ProductionRoutine()
        {
            _isProducing = true;

            while (_productionQueue.Count > 0)
            {
                int unitIndex = _productionQueue.Dequeue();
                float productionTime = 5f; // Базовое время производства

                yield return new WaitForSeconds(productionTime);

                SpawnUnit(unitIndex);
            }

            _isProducing = false;
        }

        private void SpawnUnit(int index)
        {
            if (spawnPoint != null)
            {
                Instantiate(availableUnits[index], spawnPoint.position, spawnPoint.rotation);
                Debug.Log($"[Barracks] Юнит {availableUnits[index].name} произведен.");
            }
        }
    }
}
