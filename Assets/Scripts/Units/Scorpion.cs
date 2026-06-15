using UnityEngine;

namespace Generals.Units.GLA
{
    /// <summary>
    /// Танк Скорпион (ГЛА). Быстрый и дешевый.
    /// </summary>
    public class Scorpion : BaseUnit
    {
        protected override void Start()
        {
            unitName = "Scorpion Tank";
            faction = FactionType.GLA;
            maxHealth = 80f;
            movementSpeed = 8f;
            cost = 600;
            base.Start();
        }

        // Специфическая логика (например, установка ракеты после апгрейда)
    }
}
