using UnityEngine;

namespace Generals.Core.VFX
{
    /// <summary>
    /// Эффект тряски камеры.
    /// </summary>
    public class CameraShake : MonoBehaviour
    {
        public static CameraShake Instance { get; private set; }

        private Vector3 _originalPos;
        private float _shakeAmount = 0f;
        private float _shakeDuration = 0f;

        private void Awake()
        {
            Instance = this;
        }

        public void Shake(float amount, float duration)
        {
            _shakeAmount = amount;
            _shakeDuration = duration;
            _originalPos = transform.localPosition;
        }

        private void Update()
        {
            if (_shakeDuration > 0)
            {
                transform.localPosition = _originalPos + Random.insideUnitSphere * _shakeAmount;
                _shakeDuration -= Time.deltaTime;
            }
            else if (_shakeDuration < 0)
            {
                _shakeDuration = 0f;
                transform.localPosition = _originalPos;
            }
        }
    }
}
