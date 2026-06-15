using UnityEngine;

namespace Generals.Units
{
    /// <summary>
    /// Артиллерия. Дальнобойный юнит.
    /// </summary>
    public class Artillery : BaseUnit
    {
        protected override void Start()
        {
            unitName = "Artillery";
            maxHealth = 60f;
            movementSpeed = 3f;
            cost = 1200;
            base.Start();
        }
    }
}
