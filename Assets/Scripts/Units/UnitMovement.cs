using UnityEngine;
using UnityEngine.AI;

namespace Generals.Units
{
    /// <summary>
    /// Компонент движения юнита, использующий NavMesh.
    /// Поддерживает разные типы навигации (земля, вода).
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class UnitMovement : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private BaseUnit _unit;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _unit = GetComponent<BaseUnit>();
        }

        private void Start()
        {
            if (_unit != null)
            {
                _agent.speed = _unit.movementSpeed;
            }
        }

        public void MoveTo(Vector3 destination)
        {
            if (_agent.isOnNavMesh)
            {
                _agent.SetDestination(destination);
            }
        }

        public void Stop()
        {
            if (_agent.isOnNavMesh)
            {
                _agent.ResetPath();
            }
        }

        /// <summary>
        /// Переключение типа навигации (например, для авианосцев или амфибий)
        /// </summary>
        public void SetNavArea(int areaMask)
        {
            _agent.areaMask = areaMask;
        }
    }
}
