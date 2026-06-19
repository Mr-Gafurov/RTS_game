using UnityEngine;
using UnityEngine.AI;
using Generals.Units;

namespace Generals.Core
{
    /// <summary>
    /// Система движения юнитов через NavMesh.
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
                _agent.acceleration = _unit.movementSpeed * 2f;
                _agent.angularSpeed = 120f;
            }
        }

        public void MoveTo(Vector3 targetPosition)
        {
            if (_agent != null && _agent.isOnNavMesh)
            {
                _agent.SetDestination(targetPosition);
            }
        }

        public void Stop()
        {
            if (_agent != null && _agent.isOnNavMesh)
            {
                _agent.isStopped = true;
                _agent.ResetPath();
            }
        }

        public bool IsAtDestination()
        {
            if (!_agent.pathPending)
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void SetNavArea(int areaMask)
        {
            if (_agent != null)
            {
                _agent.areaMask = areaMask;
            }
        }
    }
}
