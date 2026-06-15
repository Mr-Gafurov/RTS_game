using UnityEngine;

namespace Generals.Units.China
{
    /// <summary>
    /// Истребитель МиГ. Атакует напалмом.
    /// </summary>
    public class MiG : BaseUnit
    {
        public int ammo = 2;

        protected override void Start()
        {
            unitName = "MiG Fighter";
            faction = FactionType.China;
            maxHealth = 120f;
            movementSpeed = 25f;
            cost = 1000;
            base.Start();
        }

        public void FireMissile(Vector3 target)
        {
            if (ammo > 0)
            {
                ammo--;
                Debug.Log("[MiG] Пуск напалмовой ракеты!");
                // Спавн снаряда с огненным Splash
            }
            else
            {
                // Возвращение на аэродром для дозаправки
            }
        }
    }
}
