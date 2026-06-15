using UnityEngine;

namespace Generals.Combat
{
    using Generals.Units;

    /// <summary>
    /// Система атаки для юнитов и зданий.
    /// </summary>
    public class AttackSystem : MonoBehaviour
    {
        [Header("Настройки атаки")]
        public float damage = 10f;
        public float attackRange = 15f;
        public float attackRate = 1f; // выстрелов в секунду

        [Header("Цель")]
        public GameObject currentTarget;

        private float _lastAttackTime;

        private void Update()
        {
            if (currentTarget != null)
            {
                float distance = Vector3.Distance(transform.position, currentTarget.transform.position);
                if (distance <= attackRange)
                {
                    TryAttack();
                }
            }
        }

        public void TryAttack()
        {
            if (Time.time - _lastAttackTime >= 1f / attackRate)
            {
                PerformAttack();
                _lastAttackTime = Time.time;
            }
        }

        protected virtual void PerformAttack()
        {
            if (currentTarget == null) return;

            // Базовая логика нанесения урона
            var targetUnit = currentTarget.GetComponent<BaseUnit>();
            if (targetUnit != null)
            {
                targetUnit.TakeDamage(damage);
            }
            else
            {
                var targetBuilding = currentTarget.GetComponent<Generals.Buildings.BaseBuilding>();
                if (targetBuilding != null)
                {
                    targetBuilding.TakeDamage(damage);
                }
            }

            Debug.Log($"[AttackSystem] {gameObject.name} атаковал {currentTarget.name}");
        }
    }
}
