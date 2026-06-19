using UnityEngine;
using System;

namespace Generals.Units
{
    using Generals.Core;

    /// <summary>
    /// Базовый класс для всех юнитов в игре.
    /// </summary>
    [Serializable]
    public abstract class BaseUnit : MonoBehaviour
    {
        [Header("Базовые характеристики")]
        public string unitName;
        public FactionType faction;
        public float maxHealth = 100f;
        public float currentHealth;
        public float movementSpeed = 5f;
        public float viewRange = 20f;
        public int cost = 100;

        [Header("Состояние")]
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
            // Визуализация выделения
        }

        public virtual void OnDeselect()
        {
            isSelected = false;
            // Скрытие визуализации выделения
        }
    }
}
