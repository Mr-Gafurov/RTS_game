using UnityEngine;

namespace Generals.Units
{
    /// <summary>
    /// Базовый класс для пехоты.
    /// </summary>
    public class Infantry : BaseUnit
    {
        protected override void Start()
        {
            unitName = "Basic Infantry";
            maxHealth = 50f;
            movementSpeed = 4f;
            cost = 100;
            base.Start();
        }
    }
}
