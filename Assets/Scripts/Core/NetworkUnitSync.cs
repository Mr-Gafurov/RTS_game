using UnityEngine;

namespace Generals.Core
{
    /// <summary>
    /// Сглаживание движения юнитов по сети (интерполяция).
    /// </summary>
    public class NetworkUnitSync : MonoBehaviour
    {
        private Vector3 _targetPosition;
        private Quaternion _targetRotation;
        public float lerpSpeed = 10f;

        public void UpdateState(Vector3 pos, Quaternion rot)
        {
            _targetPosition = pos;
            _targetRotation = rot;
        }

        private void Update()
        {
            // Плавное перемещение к целевой позиции, полученной от сервера
            transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * lerpSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.deltaTime * lerpSpeed);
        }
    }
}
