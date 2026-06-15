using UnityEngine;

namespace Generals.Units.Sea
{
    /// <summary>
    /// Авианосец. Мощный морской юнит, запускающий самолеты.
    /// </summary>
    public class AircraftCarrier : BaseUnit
    {
        [Header("Настройки авианосца")]
        public int maxPlanes = 4;
        public GameObject planePrefab;
        public Transform launchPoint;

        protected override void Start()
        {
            unitName = "Aircraft Carrier";
            maxHealth = 1000f;
            movementSpeed = 4f;
            cost = 3000;
            base.Start();

            // Настройка для движения по воде (через NavMesh Area Mask)
            var movement = GetComponent<UnitMovement>();
            if (movement != null)
            {
                // Предположим, что 4 - это слой воды в NavMesh
                movement.SetNavArea(1 << 3);
            }
        }

        public void LaunchPlanes()
        {
            Debug.Log($"[AircraftCarrier] Запуск самолетов!");
        }
    }
}
