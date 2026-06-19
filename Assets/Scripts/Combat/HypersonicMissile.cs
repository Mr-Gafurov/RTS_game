using UnityEngine;

namespace Generals.Combat
{
    /// <summary>
    /// Специальный тип ракеты, которую нельзя перехватить лазером.
    /// </summary>
    public class HypersonicMissile : Projectile
    {
        protected override void HitTarget()
        {
            // Логика взрыва
            Debug.Log("[Hypersonic] Цель поражена!");
            Destroy(gameObject);
        }
    }
}
