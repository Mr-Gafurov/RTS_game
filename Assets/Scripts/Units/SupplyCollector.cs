using UnityEngine;

namespace Generals.Units
{
    using Generals.Core;

    /// <summary>
    /// Логика сборщика ресурсов.
    /// </summary>
    public class SupplyCollector : MonoBehaviour
    {
        public float cargoCapacity = 200f;
        public float currentCargo = 0f;
        public float collectionRate = 20f;

        public ResourceNode targetNode;
        public GameObject homeDepot;

        private UnitMovement _movement;

        private void Awake()
        {
            _movement = GetComponent<UnitMovement>();
        }

        private void Update()
        {
            if (currentCargo < cargoCapacity)
            {
                if (targetNode != null)
                {
                    _movement.MoveTo(targetNode.transform.position);
                    if (Vector3.Distance(transform.position, targetNode.transform.position) < 3f)
                    {
                        currentCargo += targetNode.Collect(collectionRate * Time.deltaTime);
                    }
                }
            }
            else
            {
                if (homeDepot != null)
                {
                    _movement.MoveTo(homeDepot.transform.position);
                    if (Vector3.Distance(transform.position, homeDepot.transform.position) < 5f)
                    {
                        ResourceManager.Instance.AddMoney(currentCargo);
                        currentCargo = 0;
                    }
                }
            }
        }
    }
}
