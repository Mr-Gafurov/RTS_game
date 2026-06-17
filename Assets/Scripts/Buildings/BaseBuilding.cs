using UnityEngine;
using System;

namespace Generals.Buildings
{
    using Generals.Units;
    using Generals.Core;

    /// <summary>
    /// Базовый класс для всех зданий.
    /// </summary>
    [Serializable]
    public abstract class BaseBuilding : MonoBehaviour
    {
        [Header("Базовые параметры")]
        public string buildingName;
        public FactionType faction;
        public float maxHealth = 500f;
        public float currentHealth;
        public int cost = 1000;
        public float energyConsumption = 10f; // Положительное - потребляет, отрицательное - производит

        public event Action<float> OnHealthChanged;
        public event Action OnDestroyed;

        protected virtual void Start()
        {
            currentHealth = maxHealth;
            if (ResourceManager.Instance != null)
            {
                ResourceManager.Instance.RegisterBuilding(this);
            }
        }

        public virtual void TakeDamage(float damage)
        {
            currentHealth -= damage;
            OnHealthChanged?.Invoke(currentHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            if (ResourceManager.Instance != null)
            {
                ResourceManager.Instance.UnregisterBuilding(this);
            }
            OnDestroyed?.Invoke();
            Destroy(gameObject);
        }

        protected virtual void OnDestroy()
        {
            if (ResourceManager.Instance != null)
            {
                ResourceManager.Instance.UnregisterBuilding(this);
            }
        }
    }
}
