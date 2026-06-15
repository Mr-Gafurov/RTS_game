using UnityEngine;
using System.Collections.Generic;

namespace Generals.Units
{
    /// <summary>
    /// Дрон-камикадзе (FPV). Быстрый, маневренный, взрывается при контакте.
    /// </summary>
    public class FPVDrone : BaseUnit
    {
        public float explosionDamage = 150f;
        public float blastRadius = 3f;

        protected override void Start()
        {
            unitName = "FPV Kamikaze Drone";
            maxHealth = 20f;
            movementSpeed = 15f;
            cost = 300;
            base.Start();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Explode();
        }

        public void Explode()
        {
            Debug.Log("[Drone] Детонация FPV дрона!");
            // Логика AoE урона
            Die();
        }
    }
}
