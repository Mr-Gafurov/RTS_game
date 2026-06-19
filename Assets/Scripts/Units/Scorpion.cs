using UnityEngine;
using Generals.Units;

using Generals.Core;
namespace Generals.Units.GLA
{
    /// <summary>
    /// Танк Скорпион (ГЛА). Быстрый и дешевый, улучшается запчастями.
    /// </summary>
    public class Scorpion : BaseUnit
    {
        [Header("Улучшения")]
        public bool hasRocketUpgrade = false;
        public int salvageLevel = 0;

        protected override void Start()
        {
            unitName = "Scorpion Tank";
            faction = FactionType.GLA;
            maxHealth = 100f;
            movementSpeed = 8f;
            cost = 600;
            base.Start();
        }

        public void CollectSalvage()
        {
            if (salvageLevel < 3)
            {
                salvageLevel++;
                maxHealth += 20f;
                currentHealth += 20f;
                Debug.Log($"[Scorpion] Уровень сбора запчастей: {salvageLevel}");
            }
        }
    }
}
