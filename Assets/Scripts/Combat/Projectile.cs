using UnityEngine;
using System.Collections.Generic;

namespace Generals.Combat
{
    /// <summary>
    /// Базовый класс для всех снарядов в игре.
    /// </summary>
    public abstract class Projectile : MonoBehaviour
    {
        public float speed = 20f;
        public float damage = 10f;
        protected Transform target;

        public static List<Projectile> AllProjectiles = new List<Projectile>();

        protected virtual void OnEnable()
        {
            AllProjectiles.Add(this);
        }

        protected virtual void OnDisable()
        {
            AllProjectiles.Remove(this);
        }

        public virtual void Launch(Transform targetTransform)
        {
            target = targetTransform;
        }

        protected virtual void Update()
        {
            if (target == null)
            {
                Destroy(gameObject);
                return;
            }

            MoveTowardsTarget();
        }

        protected virtual void MoveTowardsTarget()
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(target);

            if (Vector3.Distance(transform.position, target.position) < 0.5f)
            {
                HitTarget();
            }
        }

        protected abstract void HitTarget();
    }
}
