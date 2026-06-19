using UnityEngine;

using Generals.Core;
namespace Generals.Units.GLA
{
    /// <summary>
    /// Террорист (ГЛА). Юнит-смертник.
    /// </summary>
    public class Terrorist : BaseUnit
    {
        public float explosionDamage = 200f;
        public float explosionRadius = 5f;

        protected override void Start()
        {
            unitName = "Terrorist";
            faction = FactionType.GLA;
            maxHealth = 30f;
            movementSpeed = 6f;
            cost = 200;
            base.Start();
        }

        public void Detonate()
        {
            Debug.Log("[Terrorist] БАБАХ!");
            // Логика взрыва по области
            Die();
        }
    }
}
