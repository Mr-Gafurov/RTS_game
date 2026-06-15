using UnityEngine;

namespace Generals.Units.USA
{
    /// <summary>
    /// Танк Паладин (США). Обладает лазерной защитой (в будущем).
    /// </summary>
    public class Paladin : BaseUnit
    {
        protected override void Start()
        {
            unitName = "Paladin Tank";
            faction = FactionType.USA;
            maxHealth = 150f;
            movementSpeed = 6f;
            cost = 1100;
            base.Start();
        }

        // Специфическая логика Паладина (например, сбивание ракет лазером)
    }
}
