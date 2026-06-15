using UnityEngine;

namespace Generals.Buildings
{
    /// <summary>
    /// Склад. Собирает ресурсы.
    /// </summary>
    public class SupplyDepot : BaseBuilding
    {
        protected override void Start()
        {
            buildingName = "Supply Depot";
            maxHealth = 800f;
            cost = 1500;
            energyConsumption = 5f;
            base.Start();
        }
    }
}
