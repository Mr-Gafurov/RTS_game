using UnityEngine;
using System;

namespace Generals.Buildings
{
    using Generals.Units;

    /// <summary>
    /// Базовый класс для всех зданий в игре.
    /// </summary>
    [Serializable]
    public abstract class BaseBuilding : MonoBehaviour
    {
        [Header("Характеристики здания")]
        public string buildingName;
        public FactionType faction;
        public float maxHealth = 500f;
        public float currentHealth;
        public int cost = 500;
        public float energyConsumption = 10f;
        public float buildTime = 10f;

        [Header("Состояние")]
        public bool isConstructed = false;
        public bool isSelected = false;

        public event Action OnDeath;
        public event Action<float> OnHealthChanged;

        protected virtual void Start()
        {
            currentHealth = maxHealth;
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
            OnDeath?.Invoke();
            Destroy(gameObject);
        }

        public virtual void OnSelect()
        {
            isSelected = true;
        }

        public virtual void OnDeselect()
        {
            isSelected = false;
        }
    }
}
