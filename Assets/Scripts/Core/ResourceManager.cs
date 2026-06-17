using UnityEngine;
using System;
using System.Collections.Generic;
using Generals.Buildings;

namespace Generals.Core
{
    /// <summary>
    /// Менеджер ресурсов игрока (Деньги, Энергия) с логикой энергопотребления.
    /// </summary>
    public class ResourceManager : MonoBehaviour
    {
        public static ResourceManager Instance { get; private set; }

        [Header("Текущие ресурсы")]
        [SerializeField] private float _money = 1000f;
        [SerializeField] private float _totalEnergyProduced = 0f;
        [SerializeField] private float _totalEnergyConsumed = 0f;

        public float Money => _money;
        public float EnergyRatio => _totalEnergyProduced > 0 ? _totalEnergyConsumed / _totalEnergyProduced : 0;
        public bool IsLowEnergy => _totalEnergyConsumed > _totalEnergyProduced;

        public event Action OnResourcesChanged;

        private List<BaseBuilding> _buildings = new List<BaseBuilding>();

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void AddMoney(float amount)
        {
            _money += amount;
            OnResourcesChanged?.Invoke();
        }

        public bool SpendMoney(float amount)
        {
            if (_money >= amount)
            {
                _money -= amount;
                OnResourcesChanged?.Invoke();
                return true;
            }
            return false;
        }

        public void RegisterBuilding(BaseBuilding building)
        {
            if (!_buildings.Contains(building))
            {
                _buildings.Add(building);
                RecalculateEnergy();
            }
        }

        public void UnregisterBuilding(BaseBuilding building)
        {
            if (_buildings.Contains(building))
            {
                _buildings.Remove(building);
                RecalculateEnergy();
            }
        }

        public void RecalculateEnergy()
        {
            _totalEnergyProduced = 0;
            _totalEnergyConsumed = 0;

            foreach (var building in _buildings)
            {
                if (building.energyConsumption < 0) // Производит энергию
                    _totalEnergyProduced += Mathf.Abs(building.energyConsumption);
                else
                    _totalEnergyConsumed += building.energyConsumption;
            }

            OnResourcesChanged?.Invoke();
            Debug.Log($"[Energy] Баланс: {_totalEnergyConsumed}/{_totalEnergyProduced}");
        }
    }
}
