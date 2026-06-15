using UnityEngine;
using System.Collections.Generic;

namespace Generals.Units
{
    /// <summary>
    /// Контроллер роя дронов.
    /// </summary>
    public class DroneSwarmController : MonoBehaviour
    {
        public List<GameObject> drones = new List<GameObject>();
        public Transform target;
        public float swarmRadius = 5f;

        public void AssignTarget(Transform newTarget)
        {
            target = newTarget;
            foreach (var drone in drones)
            {
                // Приказ каждому дрону в рое атаковать или следовать
            }
        }

        private void Update()
        {
            if (target != null)
            {
                // Логика кружения роя вокруг цели
            }
        }
    }
}
