using UnityEngine;

using Generals.Core;
namespace Generals.Units.USA
{
    /// <summary>
    /// Снайпер (США). Дальнобойный пехотинец, эффективен против пехоты.
    /// </summary>
    public class Sniper : BaseUnit
    {
        protected override void Start()
        {
            unitName = "Pathfinder Sniper";
            faction = FactionType.USA;
            maxHealth = 40f;
            movementSpeed = 4.5f;
            cost = 600;
            base.Start();
        }

        // Специфическая логика снайпера (например, невидимость в покое)
    }
}
