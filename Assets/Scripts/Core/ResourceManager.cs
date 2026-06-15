using UnityEngine;
using System;

namespace Generals.Core
{
    /// <summary>
    /// Менеджер ресурсов игрока (Деньги, Энергия).
    /// </summary>
    [Serializable]
    public class ResourceManager : MonoBehaviour
    {
        public static ResourceManager Instance { get; private set; }

        [Header("Текущие ресурсы")]
        [SerializeField] private float _money = 1000f;
        [SerializeField] private float _currentEnergy = 0f;
        [SerializeField] private float _maxEnergy = 0f;

        public float Money => _money;
        public float EnergyRatio => _maxEnergy > 0 ? _currentEnergy / _maxEnergy : 0;

        public event Action OnResourcesChanged;

        private void Awake()
        {
            Instance = this;
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

        public void UpdateEnergy(float current, float max)
        {
            _currentEnergy = current;
            _maxEnergy = max;
            OnResourcesChanged?.Invoke();
        }

        public bool HasEnoughEnergy()
        {
            return _currentEnergy <= _maxEnergy;
        }
    }
}
