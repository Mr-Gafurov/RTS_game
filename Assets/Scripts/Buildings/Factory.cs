using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Generals.Buildings
{
    using Generals.Units;
    using Generals.Core;

    /// <summary>
    /// Завод: производство техники.
    /// </summary>
    public class Factory : BaseBuilding
    {
        [Header("Производство техники")]
        public List<GameObject> availableVehicles;
        public Transform spawnPoint;

        private Queue<int> _productionQueue = new Queue<int>();
        private bool _isProducing = false;

        protected override void Start()
        {
            buildingName = "China War Factory";
            maxHealth = 1500f;
            cost = 2000;
            energyConsumption = 50f;
            base.Start();
        }

        public void EnqueueVehicle(int index)
        {
            if (index < 0 || index >= availableVehicles.Count) return;

            BaseUnit unitScript = availableVehicles[index].GetComponent<BaseUnit>();
            if (unitScript != null && ResourceManager.Instance.SpendMoney(unitScript.cost))
            {
                _productionQueue.Enqueue(index);
                Debug.Log($"[Factory] Техника {unitScript.unitName} добавлена в очередь.");

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
                int vehicleIndex = _productionQueue.Dequeue();
                float productionTime = 10f;

                yield return new WaitForSeconds(productionTime);

                SpawnVehicle(vehicleIndex);
            }

            _isProducing = false;
        }

        private void SpawnVehicle(int index)
        {
            if (spawnPoint != null)
            {
                Instantiate(availableVehicles[index], spawnPoint.position, spawnPoint.rotation);
                Debug.Log($"[Factory] Техника {availableVehicles[index].name} произведена.");
            }
        }
    }
}
