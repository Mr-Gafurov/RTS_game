using UnityEngine;

namespace Generals.Combat
{
    /// <summary>
    /// Лазерная система защиты (ПВО).
    /// </summary>
    public class LaserDefense : MonoBehaviour
    {
        public float range = 25f;
        public float rechargeTime = 0.5f;
        private float _lastShotTime;

        private void Update()
        {
            if (Time.time - _lastShotTime >= rechargeTime)
            {
                TryInterception();
            }
        }

        private void TryInterception()
        {
            // Поиск входящих ракет (Projectile) в радиусе
            var targets = GameObject.FindObjectsOfType<Projectile>();
            foreach (var target in targets)
            {
                // Игнорирует гиперзвуковые ракеты
                if (target is HypersonicMissile) continue;

                if (Vector3.Distance(transform.position, target.transform.position) <= range)
                {
                    Destroy(target.gameObject);
                    _lastShotTime = Time.time;
                    Debug.Log("[Laser] Ракета перехвачена!");
                    break;
                }
            }
        }
    }
}
