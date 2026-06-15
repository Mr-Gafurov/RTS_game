using UnityEngine;

namespace Generals.Combat
{
    /// <summary>
    /// Система спецспособностей генерала (Авиаудар, Ядерная ракета и т.д.).
    /// </summary>
    public class GeneralsPower : MonoBehaviour
    {
        public string powerName;
        public float cooldown = 60f;
        private float _lastUsedTime;

        public bool IsReady => Time.time - _lastUsedTime >= cooldown;

        public void Activate(Vector3 targetPosition)
        {
            if (!IsReady) return;

            Debug.Log($"[GeneralsPower] Активирована способность: {powerName} по координатам {targetPosition}");

            // Специфическая логика (спавн бомбардировщика, взрыв и т.д.)
            ExecutePower(targetPosition);

            _lastUsedTime = Time.time;
        }

        protected virtual void ExecutePower(Vector3 target)
        {
            // Переопределяется в подклассах
        }
    }
}
