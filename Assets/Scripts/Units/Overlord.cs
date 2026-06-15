using UnityEngine;

namespace Generals.Units.China
{
    /// <summary>
    /// Танк Оверлорд (Китай). Медленный, но очень мощный.
    /// </summary>
    public class Overlord : BaseUnit
    {
        protected override void Start()
        {
            unitName = "Overlord Tank";
            faction = FactionType.China;
            maxHealth = 400f;
            movementSpeed = 3f;
            cost = 2000;
            base.Start();
        }

        // Специфическая логика (например, возможность установки бункера или вышки на башню)
    }
}
