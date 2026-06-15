using UnityEngine;

namespace Generals.Units
{
    /// <summary>
    /// Система ветеранства (ранги юнитов).
    /// </summary>
    public class UnitVeterancy : MonoBehaviour
    {
        public int rank = 0; // 0: Rookie, 1: Veteran, 2: Elite, 3: Heroic
        public float currentXP = 0f;
        public float[] xpThresholds = { 100f, 300f, 600f };

        private BaseUnit _unit;

        private void Awake()
        {
            _unit = GetComponent<BaseUnit>();
        }

        public void AddXP(float amount)
        {
            if (rank >= 3) return;

            currentXP += amount;
            if (currentXP >= xpThresholds[rank])
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            rank++;
            Debug.Log($"[Veterancy] {gameObject.name} повышен до ранга {rank}!");

            // Улучшение характеристик
            _unit.maxHealth *= 1.2f;
            _unit.currentHealth = _unit.maxHealth;

            // Визуальный эффект
            Generals.Core.EffectManager.Instance?.SpawnExplosion(transform.position, 0.5f);
        }
    }
}
