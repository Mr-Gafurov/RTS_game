using UnityEngine;

namespace Generals.Combat
{
    using Generals.Units;
    using Generals.Buildings;
    using Generals.Core;

    /// <summary>
    /// Продвинутая система атаки с проверкой фракций.
    /// </summary>
    public class AttackSystem : MonoBehaviour
    {
        [Header("Настройки атаки")]
        public float damage = 10f;
        public float attackRange = 15f;
        public float attackRate = 1f;

        [Header("Цель")]
        public GameObject currentTarget;

        private float _lastAttackTime;
        private FactionType _myFaction;

        private void Start()
        {
            var unit = GetComponent<BaseUnit>();
            if (unit != null) _myFaction = unit.faction;
            else
            {
                var building = GetComponent<BaseBuilding>();
                if (building != null) _myFaction = building.faction;
            }
        }

        private void Update()
        {
            if (currentTarget != null)
            {
                if (IsEnemy(currentTarget))
                {
                    float distance = Vector3.Distance(transform.position, currentTarget.transform.position);
                    if (distance <= attackRange)
                    {
                        TryAttack();
                    }
                }
                else
                {
                    currentTarget = null;
                }
            }
        }

        private bool IsEnemy(GameObject target)
        {
            var targetUnit = target.GetComponent<BaseUnit>();
            if (targetUnit != null) return targetUnit.faction != _myFaction;

            var targetBuilding = target.GetComponent<BaseBuilding>();
            if (targetBuilding != null) return targetBuilding.faction != _myFaction;

            return false;
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

            var targetUnit = currentTarget.GetComponent<BaseUnit>();
            if (targetUnit != null)
            {
                targetUnit.TakeDamage(damage);
            }
            else
            {
                var targetBuilding = currentTarget.GetComponent<BaseBuilding>();
                if (targetBuilding != null)
                {
                    targetBuilding.TakeDamage(damage);
                }
            }

            Debug.Log($"[AttackSystem] {gameObject.name} атаковал врага {currentTarget.name}");
        }
    }
}
