using UnityEngine;

namespace Generals.Units.GLA
{
    /// <summary>
    /// Баллистическая установка СКАД (ГЛА).
    /// </summary>
    public class SCUDLauncher : BaseUnit
    {
        public float reloadTime = 10f;
        private float _lastFireTime;

        protected override void Start()
        {
            unitName = "SCUD Launcher";
            faction = FactionType.GLA;
            maxHealth = 100f;
            movementSpeed = 4f;
            cost = 1500;
            base.Start();
        }

        public void Launch(Vector3 target)
        {
            if (Time.time - _lastFireTime >= reloadTime)
            {
                Debug.Log("[SCUD] Запуск баллистической ракеты!");
                _lastFireTime = Time.time;
            }
        }
    }
}
