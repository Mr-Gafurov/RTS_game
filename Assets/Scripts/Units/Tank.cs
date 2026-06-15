using UnityEngine;

namespace Generals.Units
{
    /// <summary>
    /// Базовый класс для танков.
    /// </summary>
    public class Tank : BaseUnit
    {
        protected override void Start()
        {
            unitName = "Basic Tank";
            maxHealth = 120f;
            movementSpeed = 6f;
            cost = 800;
            base.Start();
        }
    }
}
