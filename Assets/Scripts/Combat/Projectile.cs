using UnityEngine;

namespace Generals.Combat
{
    using Generals.Units;

    /// <summary>
    /// Логика полета снаряда.
    /// </summary>
    public class Projectile : MonoBehaviour
    {
        public float speed = 50f;
        public float damage = 10f;
        public float splashRadius = 0f;
        public GameObject explosionEffect;

        private Vector3 _targetPos;
        private bool _isInitialized = false;

        public void Initialize(Vector3 target)
        {
            _targetPos = target;
            _isInitialized = true;
            transform.LookAt(target);
        }

        private void Update()
        {
            if (!_isInitialized) return;

            transform.position = Vector3.MoveTowards(transform.position, _targetPos, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _targetPos) < 0.1f)
            {
                Explode();
            }
        }

        private void Explode()
        {
            if (splashRadius > 0)
            {
                // Поиск целей в радиусе и нанесение урона
                Collider[] colliders = Physics.OverlapSphere(transform.position, splashRadius);
                foreach (var col in colliders)
                {
                    var unit = col.GetComponent<BaseUnit>();
                    if (unit != null) unit.TakeDamage(damage);
                }
            }

            if (explosionEffect != null)
                Instantiate(explosionEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
