using UnityEngine;
using Generals.Units;

using Generals.Core;
namespace Generals.Units.USA
{
    /// <summary>
    /// Танк Паладин (США). Оборудован лазером для сбивания ракет.
    /// </summary>
    public class Paladin : BaseUnit
    {
        [Header("Лазерная защита")]
        public float defenseRange = 10f;
        public float defenseCooldown = 2f;
        private float _lastDefenseTime;

        protected override void Start()
        {
            unitName = "Paladin Tank";
            faction = FactionType.USA;
            maxHealth = 150f;
            movementSpeed = 6f;
            cost = 1100;
            base.Start();
        }

        private void Update()
        {
            if (Time.time - _lastDefenseTime >= defenseCooldown)
            {
                DetectAndNeutralizeProjectiles();
            }
        }

        private void DetectAndNeutralizeProjectiles()
        {
            // Поиск снарядов ( projectiles ) в радиусе
            // В реальной игре здесь будет Physics.OverlapSphere
            // Если найден вражеский снаряд - уничтожаем его и ставим КД
        }
    }
}
