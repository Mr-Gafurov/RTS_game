using UnityEngine;

namespace Generals.Buildings
{
    /// <summary>
    /// Электростанция. Производит энергию для базы.
    /// </summary>
    public class PowerPlant : BaseBuilding
    {
        [Header("Производство энергии")]
        public float energyProduction = 50f;

        protected override void Start()
        {
            buildingName = "Cold Fusion Reactor";
            maxHealth = 600f;
            cost = 800;
            energyConsumption = 0; // Не потребляет, а производит
            base.Start();

            UpdateGlobalEnergy();
        }

        private void UpdateGlobalEnergy()
        {
            // Сообщаем ResourceManager о вкладе в сеть
            Debug.Log($"[Power] Сеть пополнена на {energyProduction} ед.");
        }

        protected override void Die()
        {
            // При уничтожении энергия пропадает
            base.Die();
        }
    }
}
